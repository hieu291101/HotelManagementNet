using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Req
{
    public class GuestReq
    {
        public int GuestId { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string GuestContactNumber { get; set; }
        public string GuestEmail { get; set; }
        public string GuestCreditCard { get; set; }
        public string GuestIdproof { get; set; }
        public int? AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
