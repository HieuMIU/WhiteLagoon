using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.Services.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateBooking(Booking booking)
        {
            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();
        }

        public IEnumerable<Booking> GetAllBookings(string userId = "", string? statusFilterList = "")
        {
            IEnumerable<string> statusList = statusFilterList.ToLower().Split(',');

            if (!string.IsNullOrEmpty(statusFilterList) && !string.IsNullOrEmpty(userId))
            {
                return _unitOfWork.Booking.GetAll(u => statusList.Contains(u.Status.ToLower()) && u.UserId == userId, includeProperties: "User,Villa");
            }
            else
            {
                if (!string.IsNullOrEmpty(statusFilterList))
                {
                    return _unitOfWork.Booking.GetAll(u => statusList.Contains(u.Status.ToLower()), includeProperties: "User,Villa");
                }
                if (!string.IsNullOrEmpty(userId))
                {
                    return _unitOfWork.Booking.GetAll(u => u.UserId == userId, includeProperties: "User,Villa");
                }
            }
            return _unitOfWork.Booking.GetAll(includeProperties: "User,Villa");
        }

        public Booking GetBookingById(int id)
        {
            return _unitOfWork.Booking.Get(u => u.Id == id, includeProperties: "User,Villa");
        }

        public IEnumerable<int> GetCheckedInVillaNumbers(int villaId)
        {
            return _unitOfWork.Booking.GetAll(u => u.Status == SD.StatusCheckedIn && u.VillaId == villaId).Select(u => u.VillaNumber);
        }

        public void UpdateStatus(int bookingId, string orderStatus, int villaNumber = 0)
        {
            var bookingFromDb = _unitOfWork.Booking.Get(u => u.Id == bookingId);

            if (bookingFromDb is not null)
            {
                bookingFromDb.Status = orderStatus;
                if (orderStatus == SD.StatusCheckedIn)
                {
                    bookingFromDb.VillaNumber = villaNumber;
                    bookingFromDb.ActualCheckInDate = DateTime.Now;
                }
                if (orderStatus == SD.StatusCompleted)
                {
                    bookingFromDb.ActualCheckInDate = DateTime.Now;
                }
            }
            _unitOfWork.Save();
        }

        public void UpdateStripePaymentID(int bookingId, string sessionId, string paymentIntentId)
        {
            var bookingFromDb = _unitOfWork.Booking.Get(u => u.Id == bookingId);

            if (bookingFromDb is not null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    bookingFromDb.StripeSessionId = sessionId;
                }
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    bookingFromDb.StripePaymentIntentId = paymentIntentId;
                    bookingFromDb.PaymentDate = DateTime.Now;
                    bookingFromDb.IsPaymentSuccessful = true;
                }
            }
            _unitOfWork.Save();
        }
    }
}
