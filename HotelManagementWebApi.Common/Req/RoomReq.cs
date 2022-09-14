using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Req
{
    public class RoomReq
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public int Active { get; set; }
    }
}
