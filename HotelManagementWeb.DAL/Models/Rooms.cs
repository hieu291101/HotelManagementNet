using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    [Table("Rooms")]
    public partial class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int Active { get; set; }
        public virtual Hotels Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual RoomBooked RoomBooked { get; set; }

        public override string ToString()
        {
            return String.Format("P.{1}", RoomNumber);
        }
    }
}
