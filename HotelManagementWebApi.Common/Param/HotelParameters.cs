using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Param
{
    public class HotelParameters : QueryStringParameters
    {
        public string Keyword { get; set; } = "";
        public string City { get; set; }
    }
}
