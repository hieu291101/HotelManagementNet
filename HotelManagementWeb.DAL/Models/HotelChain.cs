using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class HotelChain
    {
        public int HotelChainId { get; set; }
        public string HotelChainName { get; set; }
        public string HotelChainContactNumber { get; set; }
        public string HotelChainEmailAddress { get; set; }
        public string HotelChainWebsite { get; set; }
        public int? HotelChainHeadOfficeAddressId { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual Addresses HotelChainHeadOfficeAddress { get; set; }
    }
}
