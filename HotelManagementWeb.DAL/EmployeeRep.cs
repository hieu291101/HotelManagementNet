using HotelManagementWebApi.Common;
using HotelManagementWebApi.Common.DAL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Security.Cryptography;

namespace HotelManagementWebApi.DAL
{
    public class EmployeeRep : GenericRep<HotelContext, Employees>
    {
        public Employees ReadModel(int id)
        {
            var res = Context.Employees.Include(a => a.Address).FirstOrDefault(htl => htl.EmployeeId == id);
            return res;
        }
        public SingleRsp CreateEmployee(Employees employee)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Create(employee);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    res.SetError(e.StackTrace);
                }
            }
            return res;
        }
        public static string SHA1(string text)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("x2"));
            }
            return hashSb.ToString();
        }

        public SingleRsp ReadEmployeeLogin(EmployeeParameters employeeParameter)
        {
            var res = new SingleRsp();
            string employeeEmail = employeeParameter.EmployeeEmail.ToString();

            var data_Email = from e in Context.Employees
                             where e.EmployeeEmail == employeeEmail
                             select e.EmployeeEmail;
            var data_Password = data_Email;

            if (data_Email.Any())
            {
                string employeeEncryptPassword = SHA1(employeeParameter.EmployeePassword.ToString());
                data_Password = from e in Context.Employees
                                where e.EncryptPassword == employeeEncryptPassword
                                select e.EncryptPassword;
                if (data_Password.Any())
                {
                    res.SetMessage("Login successfully");
                    res.Success = true;
                }
                else
                {
                    res.SetMessage("Password incorrect");
                    res.Success = false;
                }
            }
            else
            {
                res.SetMessage("Email incorrect");
                res.Success = false;
            }

            return res;
        }
        public SingleRsp UpdateEmployee(Employees employee)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Update(employee);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    res.SetError(e.StackTrace);
                }
            }
            return res;
        }

        public SingleRsp DeleteEmployee(Employees employee)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Delete(employee);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    res.SetError(e.StackTrace);
                }
            }
            return res;
        }
        #region -- Overide --
        public override Employees Read(int id)
        {
            return All.FirstOrDefault(e => e.EmployeeId == id);
        }

        public SingleRsp ReadEmployeeByPhoneNumber(string numberPhone)
        {
            var res = new SingleRsp();
            var data = All.FirstOrDefault(e => e.EmployeeContactNumber.CompareTo(numberPhone) == 0);
            res.Data = data;
            return res;
        }


        public SingleRsp ReadRoomByPhoneNumber(string numberPhone)
        {
            var data = from e in Context.Employees
                       join b in Context.Bookings on e.EmployeeId equals b.EmployeeId
                       join h in Context.Hotels on b.HotelId equals h.HotelId
                       join r in Context.Rooms on b.RoomId equals r.RoomId
                       join rt in Context.RoomType on r.RoomTypeId equals rt.RoomTypeId
                       where e.EmployeeContactNumber == numberPhone
                       select new
                       {
                           b.EmployeeId
                       ,
                           b.RoomId
                       ,
                           r.RoomNumber
                       ,
                           rt.RoomTypeName
                       ,
                           b.HotelId
                       ,
                           h.HotelName
                       ,
                           b.BookingDate
                       ,
                           b.CheckInDate
                       ,
                           b.CheckOutDate
                       ,
                           r.Active
                       };

            var res = new SingleRsp();
            res.Data = data.SingleOrDefault();
            return res;
        }


        #endregion
    }
}

