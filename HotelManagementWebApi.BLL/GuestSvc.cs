using HotelManagementWebApi.Common.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL;
using HotelManagementWebApi.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.BLL
{
    public class GuestSvc : GenericSvc<GuestRep, Guests>
    {
        public SingleRsp ReadModel(int id)
        {
            var res = new SingleRsp();
            var data = _rep.ReadModel(id);
            res.Data = data;
            Console.WriteLine("checking data " + res.Data);
            return res;
        }
        // Tim thong tin phong khach hang theo so dien thoai
        public SingleRsp getGuestByNumberPhone(string numberPhone)
        {
            var res = new SingleRsp();   // Tao mot cai response
            var data = _rep.ReadGuestByPhoneNumber(numberPhone);  // tao bien data va gan numberphone doc duoc
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

        public SingleRsp getGuestLogin(string guestEmail, string numberPhone)
        {
        

            return  _rep.ReadGuestLogin(guestEmail, numberPhone);  // tao bien data va gan numberphone doc duoc
        }

        // Khach hang book phong
        //public SingleRsp postGuestBookingRoom(string guestEmail, string numberPhone)
        //{
        //    var res = new SingleRsp();   
        //    var data = _rep.RegisterRoomByPhoneNumber(guestEmail, numberPhone);
        //    res.Data = data;

        //    return res;
        //}

        public SingleRsp CreateGuest(GuestReq guestReq)
        {
            var res = new SingleRsp();

            var guest = new Guests()
            {
                GuestFirstName = guestReq.GuestFirstName,
                GuestLastName = guestReq.GuestLastName,
                GuestContactNumber = guestReq.GuestContactNumber,
                GuestEmail = guestReq.GuestEmail,
                GuestCreditCard = guestReq.GuestCreditCard,
                GuestIdproof = guestReq.GuestIdproof,
                CreatedDateTime = DateTime.Now
            };

            var address = new Addresses();
            if (!guestReq.AddressLine1.Equals("") && !guestReq.AddressLine2.Equals("")
                && !guestReq.City.Equals("") && !guestReq.State.Equals("")
                && !guestReq.Country.Equals("") && !guestReq.ZipCode.Equals(""))
            {
                address.AddressLine1 = guestReq.AddressLine1;
                address.AddressLine2 = guestReq.AddressLine2;
                address.City = guestReq.City;
                address.State = guestReq.State;
                address.Country = guestReq.Country;
                address.ZipCode = guestReq.ZipCode;
                address.CreatedDateTime = DateTime.Now;
                guest.Address = address;
            }
            
            
            res = _rep.CreateGuest(guest);
            return res;
        }

        //public int UpdateGuestDeactive(int guestID)
        //{
        //    return _rep.GetGuestDeactive(guestID);
        //}


        public SingleRsp UpdateGuest(GuestReq guestReq)
        {
            var res = new SingleRsp();

            var guest = _rep.ReadModel(guestReq.GuestId);

            if (guest != null)
            {
                guest.GuestFirstName = guestReq.GuestFirstName;
                guest.GuestLastName = guestReq.GuestLastName;
                guest.GuestContactNumber = guestReq.GuestContactNumber;
                guest.GuestEmail = guestReq.GuestEmail;
                guest.GuestCreditCard = guestReq.GuestCreditCard;
                guest.GuestIdproof = guestReq.GuestIdproof;
            }

            var address = new Addresses();
            if (!guestReq.AddressLine1.Equals("") && !guestReq.AddressLine2.Equals("")
                && !guestReq.City.Equals("") && !guestReq.State.Equals("")
                && !guestReq.Country.Equals("") && !guestReq.ZipCode.Equals(""))
            {
                address.AddressLine1 = guestReq.AddressLine1;
                address.AddressLine2 = guestReq.AddressLine2;
                address.City = guestReq.City;
                address.State = guestReq.State;
                address.Country = guestReq.Country;
                address.ZipCode = guestReq.ZipCode;
                guest.Address = address;
            }

            res = _rep.UpdateGuest(guest);
            return res;
        }

        public SingleRsp DeleteGuest(int id)
        {
            var res = new SingleRsp();

            var guest = Read(id).Data;

            res = _rep.DeleteGuest(guest);
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

        //public override SingleRsp Create(Guests m)
        //{
        //    return base.Create(m);
        //}

        //public override MultipleRsp Create(List<Guests> l)
        //{
        //    return base.Create(l);
        //}

        public override SingleRsp Read(int id)
        {
            SingleRsp res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        // Tim 1 phong trong gan nhat (maybe re-use)
        //public override SingleRsp ReadRoomActive(RoomParameters roomParameters)
        //{
        //    SingleRsp res = new SingleRsp();
        //    res.Data = _rep.GetGuestsEmpty(active);
        //    return res;
        //}


        public override SingleRsp Read(string code)
        {
            return base.Read(code);
        }

        //public override SingleRsp Update(Guests m)
        //{
        //    return base.Update(m);
        //}

        //public override MultipleRsp Update(List<Guests> l)
        //{
        //    return base.Update(l);
        //}

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
