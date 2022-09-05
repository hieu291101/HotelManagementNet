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
    public class BookingRep : GenericRep<HotelContext,Bookings>
    {
        #region -- Overide --
        public override Bookings Read(int id)
        {
            return All.FirstOrDefault(o => o.BookingId == id);
        }
        #endregion
        public SingleRsp GetAllBookings(QueryStringParameters bookingParameters)
        {
            var res = new SingleRsp();
            var data =
                PagedList<Bookings>.ToPagedList(All, bookingParameters.PageNumber, bookingParameters.PageSize);

            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            res.Data = data;
            res.Metadata = metadata;
            return res;
        }

        public SingleRsp GetBookingsByCondition(BookingParameters bookingParameters)
        {
            var bookings = All;
            if (bookingParameters.bookingDate != DateTime.MinValue)
                bookings =
                    Read(b => b.BookingDate.Value.Date.CompareTo(bookingParameters.bookingDate.Date) == 0);
            var res = new SingleRsp();
            var data =
                PagedList<Bookings>.ToPagedList(bookings, bookingParameters.PageNumber, bookingParameters.PageSize);

            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            res.Data = data;
            res.Metadata = metadata;
            return res;
        }
    }
}
