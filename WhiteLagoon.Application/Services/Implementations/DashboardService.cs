﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.DTOs;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.Services.Interfaces;

namespace WhiteLagoon.Application.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        readonly DateTime currentMonthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        readonly DateTime previousMonthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PieChartDto> GetBookingPieChartData()
        {
            var totalBookings = _unitOfWork.Booking.GetAll(u => u.BookingDate >= DateTime.Now.AddDays(-30) && (u.Status != SD.StatusPending
                || u.Status != SD.StatusCancelled));

            var customerWithOneBooking = totalBookings.GroupBy(b => b.UserId).Where(x => x.Count() == 1).Select(x => x.Key).ToList();

            int bookingsByNewCustomer = customerWithOneBooking.Count();

            int bookingsByReturningCustomer = totalBookings.Count() - bookingsByNewCustomer;

            PieChartDto pieChartDto = new PieChartDto()
            {
                Labels = ["New Customer Bookings", "Returning Customer Bookings"],
                Series = [bookingsByNewCustomer, bookingsByReturningCustomer]
            };

            return pieChartDto;
        }

        public async Task<LineChartDto> GetMemberAndBookingLineChartData()
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

            LineChartDto lineChartDto = new LineChartDto()
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

            lineChartDto.Series = chartDataList;

            return lineChartDto;
        }

        public async Task<RadialBarChartDto> GetRegisteredUserRadialChartData()
        {
            var totalUsers = _unitOfWork.User.GetAll();

            var countByCurrentMonth = totalUsers.Count(u => u.CreatedAt >= currentMonthStartDate && u.CreatedAt <= DateTime.Now);

            var countByPreviousMonth = totalUsers.Count(u => u.CreatedAt >= previousMonthStartDate && u.CreatedAt < currentMonthStartDate);

            return SD.GetRadialChartDataModel(totalUsers.Count(), countByCurrentMonth, countByPreviousMonth);
        }

        public async Task<RadialBarChartDto> GetTotalBookingRadialChartData()
        {
            var totalBookings = _unitOfWork.Booking.GetAll(u => u.Status != SD.StatusPending
                || u.Status != SD.StatusCancelled);

            var countByCurrentMonth = totalBookings.Count(u => u.BookingDate >= currentMonthStartDate && u.BookingDate <= DateTime.Now);

            var countByPreviousMonth = totalBookings.Count(u => u.BookingDate >= previousMonthStartDate && u.BookingDate < currentMonthStartDate);

            return SD.GetRadialChartDataModel(totalBookings.Count(), countByCurrentMonth, countByPreviousMonth);
        }

        public async Task<RadialBarChartDto> GetTotalRevenueRadialChartData()
        {
            var totalBookings = _unitOfWork.Booking.GetAll(u => u.Status != SD.StatusPending
                || u.Status != SD.StatusCancelled);

            var sumByCurrentMonth = Convert.ToInt32(totalBookings.Where(u => u.BookingDate >= currentMonthStartDate && u.BookingDate <= DateTime.Now).Sum(u => u.TotalCost));

            var sumByPreviousMonth = Convert.ToInt32(totalBookings.Where(u => u.BookingDate >= previousMonthStartDate && u.BookingDate < currentMonthStartDate).Sum(u => u.TotalCost));

            return SD.GetRadialChartDataModel(Convert.ToInt32(totalBookings.Sum(u => u.TotalCost)), sumByCurrentMonth, sumByPreviousMonth);
        }       
    }
}
