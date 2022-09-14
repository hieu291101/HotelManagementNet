using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Param
{
    public class BookingParameters : QueryStringParameters
    {
        public int bpGuestID { get; set; }
        public int bpRoomID { get; set; }
        public int bpHotelID { get; set; }
        public DateTime bpCheckInDate { get; set; } = DateTime.MinValue;
        public DateTime bpCheckOutDate { get; set; }
        public int bpEmployeeID { get; set; }

    }
}
