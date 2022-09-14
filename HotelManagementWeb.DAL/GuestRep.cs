﻿using HotelManagementWebApi.Common;
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
    public class GuestRep : GenericRep<HotelContext, Guests>
    {
        public Guests ReadModel(int id)
        {
            var res = Context.Guests.Include(a => a.Address).FirstOrDefault(htl => htl.GuestId == id);
            return res;
        }
        public SingleRsp CreateGuest(Guests guest)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Create(guest);
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

        public SingleRsp ReadGuestLogin(GuestParameters guestParameter)
        {
            var res = new SingleRsp();
            string guestEmail = guestParameter.GuestEmail.ToString();

            var data_Email = from g in Context.Guests
                             where g.GuestEmail == guestEmail
                             select g.GuestEmail;
            var data_Password = data_Email;

            if (data_Email.Any())
            {
                string guestEncryptPassword = SHA1(guestParameter.GuestPassword.ToString());
                data_Password = from g in Context.Guests
                                where g.EncryptPassword == guestEncryptPassword
                                select g.EncryptPassword;
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
        public SingleRsp UpdateGuest(Guests guest)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Update(guest);
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

        public SingleRsp DeleteGuest(Guests guest)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Delete(guest);
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
        public override Guests Read(int id)
        {
            return All.FirstOrDefault(g => g.GuestId == id);
        }

        public SingleRsp ReadGuestByPhoneNumber(string numberPhone)
        {
            var res = new SingleRsp();
            var data = All.FirstOrDefault(g => g.GuestContactNumber.CompareTo(numberPhone) == 0);
            res.Data = data;
            return res;
        }
   

        public SingleRsp ReadRoomByPhoneNumber(string numberPhone)
        {
            var data = from g in Context.Guests
                       join b in Context.Bookings on g.GuestId equals b.GuestId
                       join h in Context.Hotels on b.HotelId equals h.HotelId
                       join r in Context.Rooms on b.RoomId equals r.RoomId
                       join rt in Context.RoomType on r.RoomTypeId equals rt.RoomTypeId
                       where g.GuestContactNumber == numberPhone
                       select new { b.GuestId
                       , b.RoomId
                       , r.RoomNumber
                       , rt.RoomTypeName 
                       , b.HotelId
                       , h.HotelName
                       , b.BookingDate
                       , b.CheckInDate
                       , b.CheckOutDate 
                       , r.Active };

            var res = new SingleRsp();
            res.Data = data.SingleOrDefault();
            return res;
        }

        //public SingleRsp RegisterRoomByPhoneNumber(string guestEmail, string numberPhone)
        //{

        //    Context.Bookings.Add(new Bookings { });
        //    Context.SaveChanges();
            
        //    var res = new SingleRsp();
        //    //res.Data = data;
        //    return res;
        //}

        //public Dictionary<string, dynamic> ReadGuestByPhoneNumber(string numberPhone)   // dynamic là kiểu động (flexible)
        //{

        //Guests guest = All.FirstOrDefault(g => g.guests.GuestContactNumber.CompareTo(numberPhone) == 0).guests;
        //Bookings bookingInfo = null;
        //Rooms roomNumberBooking = null;
        //Hotels hotelBooking = null;

        //if (guest != null)
        //{
        //    bookingInfo = All.FirstOrDefault(b => b.bookings.GuestId == guest.GuestId).bookings;
        //    roomNumberBooking = All.FirstOrDefault(r => r.rooms.RoomId == bookingInfo.RoomID).rooms;
        //    hotelBooking = All.FirstOrDefault(h => h.hotels.HotelId == bookingInfo.HotelId).hotels;
        //}

        //return new Dictionary<string, dynamic>()
        //{
        //{ "guests" , guest },
        //{ "bookings" , bookingInfo },
        //{ "rooms" , roomNumberBooking },
        //{ "hotels" , hotelBooking }
        //};

        #endregion
    }
}
