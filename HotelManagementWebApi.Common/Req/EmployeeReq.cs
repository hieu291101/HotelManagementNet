using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.Common.Req
{
    public class EmployeeReq
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeDesignation { get; set; }
        public int? EmployeeAddressId { get; set; }
        public string EmployeeContactNumber { get; set; }
        public string EmployeeEmail { get; set; }
        public int? DepartmentId { get; set; }
        public int? AddressId { get; set; }
        public int? HotelId { get; set; }
        public string EncryptPassword { get; set; }
    }
}
