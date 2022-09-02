using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    [Table("Hotels")]
    public partial class Hotels
    {
        public Hotels()
        {
            Bookings = new HashSet<Bookings>();
            Employees = new HashSet<Employees>();
            Rooms = new HashSet<Rooms>();
        }
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelContactNumber { get; set; }
        public string HotelEmailAddress { get; set; }
        public string HotelWebsite { get; set; }
        public string HotelDescription { get; set; }
        public int? HotelFloorCount { get; set; }
        public int? HotelRoomCapacity { get; set; }
        public int? HotelChainId { get; set; }
        public int? AddressId { get; set; }
        public int? StarRatingId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        
        public virtual Addresses Address { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}
