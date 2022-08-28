using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelManagementWebApi.DAL.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Bookings = new HashSet<Bookings>();
        }

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
        public DateTime? CreatedDateTime { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Hotels Hotel { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", EmployeeFirstName, EmployeeLastName);
        }
    }
}
