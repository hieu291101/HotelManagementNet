using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Req
{
    public class SearchReq
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public String Keyword { get; set; }
    }
}
