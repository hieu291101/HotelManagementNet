using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Req
{
    public class HotelReq
    {
        public string HotelName { get; set; }
        public string HotelContactNumber { get; set; }
        public string HotelEmailAddress { get; set; }
        public string HotelWebsite { get; set; }
        public string HotelDescription { get; set; }
        public int? HotelFloorCount { get; set; }
        public int? HotelRoomCapacity { get; set; }
        public int? HotelChainId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int? StarRatingId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
