using HotelManagementWebApi.Common;
using HotelManagementWebApi.Common.DAL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagementWebApi.DAL
{
    public class GuestRep : GenericRep<HotelContext, Guests>
    {
        #region -- Overide --
        public override Guests Read(int id)
        {
            return All.FirstOrDefault(g => g.GuestId == id);
        }

        public SingleRsp ReadGuestByPhoneNumber(string numberPhone)
        {
            var res = new SingleRsp();
            var data = All.FirstOrDefault(g => g.GuestContactNumber.CompareTo(numberPhone) == 0);
            res.Data = data;
            return res;
        }

        public SingleRsp ReadGuestLogin(string guestEmail, string numberPhone)
        {
            
            var data = from g in Context.Guests
                       where g.GuestContactNumber == numberPhone && g.GuestEmail == guestEmail
                       select new { g.GuestFirstName
                       , g.GuestLastName
                       , g.GuestContactNumber
                       };
            var res = new SingleRsp();
            res.Data = data;
            return res;
        }

        public SingleRsp ReadRoomByPhoneNumber(string numberPhone)
        {
            var data = from g in Context.Guests
                       join b in Context.Bookings on g.GuestId equals b.GuestId
                       join h in Context.Hotels on b.HotelId equals h.HotelId
                       join r in Context.Rooms on b.RoomId equals r.RoomId
                       join rt in Context.RoomType on r.RoomTypeId equals rt.RoomTypeId
                       where g.GuestContactNumber == numberPhone
                       select new { b.GuestId
                       , b.RoomId
                       , r.RoomNumber
                       , rt.RoomTypeName 
                       , b.HotelId
                       , h.HotelName
                       , b.BookingDate
                       , b.CheckInDate
                       , b.CheckOutDate 
                       , r.Active };

            var res = new SingleRsp();
            res.Data = data.SingleOrDefault();
            return res;
        }

        //public SingleRsp RegisterRoomByPhoneNumber(string guestEmail, string numberPhone)
        //{

        //    Context.Bookings.Add(new Bookings { });
        //    Context.SaveChanges();
            
        //    var res = new SingleRsp();
        //    //res.Data = data;
        //    return res;
        //}

        //public Dictionary<string, dynamic> ReadGuestByPhoneNumber(string numberPhone)   // dynamic là kiểu động (flexible)
        //{

        //Guests guest = All.FirstOrDefault(g => g.guests.GuestContactNumber.CompareTo(numberPhone) == 0).guests;
        //Bookings bookingInfo = null;
        //Rooms roomNumberBooking = null;
        //Hotels hotelBooking = null;

        //if (guest != null)
        //{
        //    bookingInfo = All.FirstOrDefault(b => b.bookings.GuestId == guest.GuestId).bookings;
        //    roomNumberBooking = All.FirstOrDefault(r => r.rooms.RoomId == bookingInfo.RoomID).rooms;
        //    hotelBooking = All.FirstOrDefault(h => h.hotels.HotelId == bookingInfo.HotelId).hotels;
        //}

        //return new Dictionary<string, dynamic>()
        //{
        //{ "guests" , guest },
        //{ "bookings" , bookingInfo },
        //{ "rooms" , roomNumberBooking },
        //{ "hotels" , hotelBooking }
        //};

        #endregion
    }
}
