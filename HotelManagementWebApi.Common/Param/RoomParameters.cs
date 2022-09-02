using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Param
{
    public class RoomParameters : QueryStringParameters
    {
        public int roomActive { get; set; } = 0;
    }
}
