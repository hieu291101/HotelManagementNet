using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int Active { get; set; }
        public virtual Hotels Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual RoomBooked RoomBooked { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
