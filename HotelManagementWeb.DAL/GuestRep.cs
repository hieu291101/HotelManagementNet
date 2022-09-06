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
