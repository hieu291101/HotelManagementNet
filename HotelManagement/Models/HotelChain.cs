//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelChain
    {
        public int HotelChainID { get; set; }
        public string HotelChainName { get; set; }
        public string HotelChainContactNumber { get; set; }
        public string HotelChainEmailAddress { get; set; }
        public string HotelChainWebsite { get; set; }
        public Nullable<int> HotelChainHeadOfficeAddressID { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
    
        public virtual Addresses Addresses { get; set; }
        public virtual HotelChainHasHotel HotelChainHasHotel { get; set; }
    }
}
