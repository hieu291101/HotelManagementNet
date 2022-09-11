using HotelManagementWebApi.Common.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL;
using HotelManagementWebApi.DAL.Models;
using HotelManagementWebApi.Common.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.BLL
{
    public class BookingSvc : GenericSvc<BookingRep, Bookings>
    {
        public SingleRsp getAllBookings(QueryStringParameters bookingParameters) 
        {
            return _rep.GetAllBookings(bookingParameters);
        }

        public SingleRsp GetBookingsByCondition(BookingParameters bookingParameters)
        {
            return _rep.GetBookingsByCondition(bookingParameters);
        }

        public SingleRsp postGuestBookingRoomByGuest(BookingParameters bookingParameters)
        {
            var res = new SingleRsp();
            string calculateDurationStay = (bookingParameters.bpCheckOutDate - bookingParameters.bpCheckInDate).TotalDays.ToString();

            var booking = new Bookings()
            {
                GuestId = bookingParameters.bpGuestID,
                RoomId = bookingParameters.bpRoomID,
                HotelId = bookingParameters.bpHotelID,
                CheckInDate = bookingParameters.bpCheckInDate,
                CheckOutDate = bookingParameters.bpCheckOutDate,
                DurationStay = calculateDurationStay,
                BookingDate = DateTime.Now
            };
            res = _rep.CreateBooking(booking);
            return res;
        }

        public SingleRsp postGuestBookingRoomByEmployee(BookingParameters bookingParameters)
        {
            var res = new SingleRsp();
            string calculateDurationStay = (bookingParameters.bpCheckOutDate - bookingParameters.bpCheckInDate).TotalDays.ToString();

            var booking = new Bookings()
            {
                GuestId = bookingParameters.bpGuestID,
                RoomId = bookingParameters.bpRoomID,
                HotelId = bookingParameters.bpHotelID,
                CheckInDate = bookingParameters.bpCheckInDate,
                CheckOutDate = bookingParameters.bpCheckOutDate,
                DurationStay = calculateDurationStay,
                BookingDate = DateTime.Now,
                EmployeeId = bookingParameters.bpEmployeeID
            };
            res = _rep.CreateBooking(booking);
            return res;
        }


        #region -- Overide --
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override SingleRsp Create(Bookings m)
        {
            return base.Create(m);
        }

        public override MultipleRsp Create(List<Bookings> l)
        {
            return base.Create(l);
        }

        public override SingleRsp Read(int id)
        {
            SingleRsp res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Read(string code)
        {
            return base.Read(code);
        }

        public override SingleRsp Update(Bookings m)
        {
            return base.Update(m);
        }

        public override MultipleRsp Update(List<Bookings> l)
        {
            return base.Update(l);
        }

        public override SingleRsp Delete(int id)
        {
            return base.Delete(id);
        }

        public override SingleRsp Delete(string code)
        {
            return base.Delete(code);
        }

        public override SingleRsp Restore(int id)
        {
            return base.Restore(id);
        }

        public override SingleRsp Restore(string code)
        {
            return base.Restore(code);
        }

        public override int Remove(int id)
        {
            return base.Remove(id);
        }
        #endregion
    }
}
