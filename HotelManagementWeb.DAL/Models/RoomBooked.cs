using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class RoomBooked
    {
        public int RoomBookedId { get; set; }
        public int? BookingId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual Bookings Booking { get; set; }
        public virtual Rooms Room { get; set; }
    }
}
