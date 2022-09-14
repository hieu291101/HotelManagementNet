using HotelManagementWebApi.Common.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL;
using HotelManagementWebApi.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HotelManagementWebApi.BLL
{
    public class EmployeeSvc : GenericSvc<EmployeeRep, Employees>
    {
        public SingleRsp ReadModel(int id)
        {
            var res = new SingleRsp();
            var data = _rep.ReadModel(id);
            res.Data = data;
            return res;
        }
        // Tim thong tin phong khach hang theo so dien thoai
        public SingleRsp getEmployeeByNumberPhone(string numberPhone)
        {
            var res = new SingleRsp();   // Tao mot cai response
            var data = _rep.ReadEmployeeByPhoneNumber(numberPhone);  // tao bien data va gan numberphone doc duoc
            res.Data = data;

            return res;
        }

        // Tim thong tin phong khach san theo so dien thoai
        public SingleRsp getRoomByNumberPhone(string numberPhone)
        {
            //var res = _rep.ReadRoomByPhoneNumber(numberPhone);
            ////string resConvert = JsonConvert.SerializeObject(res.Data);
            //var resMap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(res.Data);
            //System.Diagnostics.Debug.WriteLine("check data converted :" + resMap);
            //Console.WriteLine("check data converted :" + resMap["RoomTypeName"]);
            return _rep.ReadRoomByPhoneNumber(numberPhone);  // tao bien data va gan numberphone doc duoc
        }

        public SingleRsp getEmployeeLogin(EmployeeParameters employeeParameters)
        {

            return _rep.ReadEmployeeLogin(employeeParameters);  // tao bien data va gan numberphone doc duoc
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
        public SingleRsp CreateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();

            var employee = new Employees()
            {
                EmployeeFirstName = employeeReq.EmployeeFirstName,
                EmployeeLastName = employeeReq.EmployeeLastName,
                EmployeeContactNumber = employeeReq.EmployeeContactNumber,
                EmployeeEmail = employeeReq.EmployeeEmail,
                EmployeeAddressId = employeeReq.EmployeeAddressId,
                DepartmentId = employeeReq.DepartmentId,
                EncryptPassword = SHA1(employeeReq.EmployeeContactNumber)
            };

            

            res = _rep.CreateEmployee(employee);
            return res;
        }



        public SingleRsp UpdateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();

            var employee = _rep.ReadModel(employeeReq.EmployeeId);

            if (employee != null)
            {
                employee.EmployeeFirstName = employeeReq.EmployeeFirstName;
                employee.EmployeeLastName = employeeReq.EmployeeLastName;
                employee.EmployeeContactNumber = employeeReq.EmployeeContactNumber;
                employee.EmployeeEmail = employeeReq.EmployeeEmail;
                employee.DepartmentId = employeeReq.DepartmentId;
                employee.HotelId = employeeReq.HotelId;
                employee.AddressId = employeeReq.AddressId;

            }

            

            res = _rep.UpdateEmployee(employee);
            return res;
        }

        public SingleRsp DeleteEmployee(int id)
        {
            var res = new SingleRsp();

            var employee = Read(id).Data;

            res = _rep.DeleteEmployee(employee);
            return res;
        }
        #region -- Overide --
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }


        public override SingleRsp Read(int id)
        {
            SingleRsp res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }



        public override SingleRsp Read(string code)
        {
            return base.Read(code);
        }


        public override SingleRsp Delete(int id)
        {
            return base.Delete(id);
        }

        public override SingleRsp Delete(string code)
        {
            return base.Delete(code);
        }

        public override SingleRsp Restore(int id)
        {
            return base.Restore(id);
        }

        public override SingleRsp Restore(string code)
        {
            return base.Restore(code);
        }

        public override int Remove(int id)
        {
            return base.Remove(id);
        }
        #endregion

    }
}
