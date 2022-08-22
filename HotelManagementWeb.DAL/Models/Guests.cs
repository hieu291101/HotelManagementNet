using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class Guests
    {
        public Guests()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int GuestId { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public string GuestContactNumber { get; set; }
        public string GuestEmail { get; set; }
        public string GuestCreditCard { get; set; }
        public string GuestIdproof { get; set; }
        public int? AddressId { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
