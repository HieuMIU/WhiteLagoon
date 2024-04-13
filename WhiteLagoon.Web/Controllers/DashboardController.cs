using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Web.ViewModel;

namespace WhiteLagoon.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        readonly DateTime currentMonthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        readonly DateTime previousMonthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTotalBookingRadialChartData()
        {
            var totalBookings = _unitOfWork.Booking.GetAll(u => u.Status != SD.StatusPending 
                || u.Status != SD.StatusCancelled);

            var countByCurrentMonth = totalBookings.Count(u => u.BookingDate >= currentMonthStartDate && u.BookingDate <= DateTime.Now);

            var countByPreviousMonth = totalBookings.Count(u => u.BookingDate >= previousMonthStartDate && u.BookingDate < currentMonthStartDate);

            return Json(GetRadialChartDataModel(totalBookings.Count(), countByCurrentMonth, countByPreviousMonth));
        }

        public async Task<IActionResult> GetRegisteredUserRadialChartData()
        {
            var totalUsers = _unitOfWork.User.GetAll();

            var countByCurrentMonth = totalUsers.Count(u => u.CreatedAt >= currentMonthStartDate && u.CreatedAt <= DateTime.Now);

            var countByPreviousMonth = totalUsers.Count(u => u.CreatedAt >= previousMonthStartDate && u.CreatedAt < currentMonthStartDate);

            return Json(GetRadialChartDataModel(totalUsers.Count(), countByCurrentMonth, countByPreviousMonth));
        }

        public async Task<IActionResult> GetTotalRevenueRadialChartData()
        {
            var totalBookings = _unitOfWork.Booking.GetAll(u => u.Status != SD.StatusPending
                || u.Status != SD.StatusCancelled);

            var sumByCurrentMonth = Convert.ToInt32(totalBookings.Where(u => u.BookingDate >= currentMonthStartDate && u.BookingDate <= DateTime.Now).Sum(u => u.TotalCost));

            var sumByPreviousMonth = Convert.ToInt32(totalBookings.Where(u => u.BookingDate >= previousMonthStartDate && u.BookingDate < currentMonthStartDate).Sum(u => u.TotalCost));

            return Json(GetRadialChartDataModel(Convert.ToInt32(totalBookings.Sum(u => u.TotalCost)), sumByCurrentMonth, sumByPreviousMonth));
        }

        public async Task<IActionResult> GetBookingPieChartData()
        {
            var totalBookings = _unitOfWork.Booking.GetAll(u => u.BookingDate >= DateTime.Now.AddDays(-30) && (u.Status != SD.StatusPending
                || u.Status != SD.StatusCancelled));

            var customerWithOneBooking = totalBookings.GroupBy(b => b.UserId).Where(x => x.Count() == 1).Select(x => x.Key).ToList();

            int bookingsByNewCustomer = customerWithOneBooking.Count();

            int bookingsByReturningCustomer = totalBookings.Count() - bookingsByNewCustomer;

            PieChartVM pieChartVM = new PieChartVM()
            {
                Labels = ["New Customer Bookings", "Returning Customer Bookings"],
                Series = [bookingsByNewCustomer, bookingsByReturningCustomer]
            };

            return Json(pieChartVM);
        }

        public async Task<IActionResult> GetMemberAndBookingLineChartData()
        {
            var bookingData = _unitOfWork.Booking.GetAll(u => u.BookingDate >= DateTime.Now.AddDays(-30) && u.BookingDate <= DateTime.Now
                                        && (u.Status != SD.StatusPending || u.Status != SD.StatusCancelled))
                                .GroupBy(b => b.BookingDate.Date)
                                .Select(u => new
                                {
                                    DateTime = u.Key,
                                    NewBookingCount = u.Count()
                                });

            var customerData = _unitOfWork.User.GetAll(u => u.CreatedAt >= DateTime.Now.AddDays(-30))
                                .GroupBy(b => b.CreatedAt.Date)
                                .Select(u => new
                                {
                                    DateTime = u.Key,
                                    NewCustomerCount = u.Count()
                                });

            var leftJoin = bookingData.GroupJoin(customerData, booking => booking.DateTime, customer => customer.DateTime,
                (booking, customer) => new
                {
                    booking.DateTime,
                    booking.NewBookingCount,
                    NewCustomerCount = customer.Select(x => x.NewCustomerCount).FirstOrDefault()
                });

            var rightJoin = customerData.GroupJoin(bookingData, customer => customer.DateTime, booking => booking.DateTime,
                (customer, booking) => new
                {
                    customer.DateTime,
                    NewBookingCount = booking.Select(x => x.NewBookingCount).FirstOrDefault(),
                    customer.NewCustomerCount
                });

            var mergedData = leftJoin.Union(rightJoin).OrderBy(u => u.DateTime).ToList();

            var newBookingData = mergedData.Select(x => x.NewBookingCount).ToArray();
            var newCustomerData = mergedData.Select(x => x.NewCustomerCount).ToArray();
            var categories = mergedData.Select(x => x.DateTime.ToString("MM/dd/yyyy")).ToArray();

            LineChartVM lineChartVM = new LineChartVM()
            {
                Categories = categories
            };

            List<ChartData> chartDataList = new List<ChartData>()
            {
                new ChartData
                {
                    Name = "New Bookings",
                    Data = newBookingData
                },
                new ChartData
                {
                    Name = "New Members",
                    Data = newCustomerData
                }
            };

            lineChartVM.Series = chartDataList;

            return Json(lineChartVM);

        }

            private static RadialBarChartVM GetRadialChartDataModel(int totalCount, int countInCurentMonth, int  countInPreviousMonth)
        {
            int increateDescreaRatio = 100;

            if (countInPreviousMonth != 0)
            {
                increateDescreaRatio = Convert.ToInt32((countInCurentMonth - countInPreviousMonth) / countInPreviousMonth * 100);
            }

            RadialBarChartVM radialBarChartVM = new RadialBarChartVM()
            {
                TotalCount = totalCount,
                CountInCurrentMonth = countInCurentMonth,
                HasRatioIncreased = countInCurentMonth > countInPreviousMonth,
                Series = [increateDescreaRatio]
            };

            return radialBarChartVM;
        }
    }
}
