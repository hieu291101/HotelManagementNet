using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class HotelChainHasHotel
    {
        public int HotelChainHasHotelId { get; set; }
        public int? HotelId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? HotelChainId { get; set; }

        public virtual Hotels Hotel { get; set; }
        public virtual HotelChain HotelChainHasHotelNavigation { get; set; }
    }
}
