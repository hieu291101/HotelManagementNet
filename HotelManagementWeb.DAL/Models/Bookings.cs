using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string DurationStay { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string BookingPaymentType { get; set; }
        public int? TotalRoomsBooked { get; set; }
        public int? HotelId { get; set; }
        public int? GuestId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? RoomId { get; set; }
        public int? IsDeleted { get; set; }
        public int? IsProcessed { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Guests Guest { get; set; }
        public virtual Hotels Hotel { get; set; }
        public virtual Rooms Room { get; set; }
    }
}
