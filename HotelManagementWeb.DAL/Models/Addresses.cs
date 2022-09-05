using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            Guests = new HashSet<Guests>();
            Hotels = new HashSet<Hotels>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual Employees Employees { get; set; }
        public virtual HotelChain HotelChain { get; set; }
        public virtual ICollection<Guests> Guests { get; set; }
        public virtual ICollection<Hotels> Hotels { get; set; }
    }
}
