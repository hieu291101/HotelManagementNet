using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Rooms>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public decimal RoomCost { get; set; }
        public string RoomTypeDescription { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}
