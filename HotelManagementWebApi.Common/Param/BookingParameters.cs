using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Param
{
    public class BookingParameters : QueryStringParameters
    {
        public DateTime bookingDate { get; set; } = DateTime.MinValue;
    }
}
