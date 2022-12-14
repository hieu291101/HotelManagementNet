using HotelManagementWebApi.Common.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagementWebApi.BLL
{
    public class HotelSvc : GenericSvc<HotelRep, Hotels>
    {
        public SingleRsp ReadModel(int id)
        {
            var res = new SingleRsp();
            var data = _rep.ReadModel(id);
            res.Data = data;
            Console.WriteLine("checking data " + res.Data);
            return res;
        }
        public SingleRsp GetAllHotels(QueryStringParameters hotelParameters)
        {
            return _rep.GetAllHotels(hotelParameters);
        }
        public SingleRsp GetHotelsByCondition(HotelParameters hotelParameters)
        {
            return _rep.GetHotelsByCondition(hotelParameters);
        }

    
        public SingleRsp CreateHotel(HotelReq hotelReq)
        {
            var res = new SingleRsp();
            var address = new Addresses()
            {
                AddressLine1 = hotelReq.AddressLine1,
                AddressLine2 = hotelReq.AddressLine2,
                City = hotelReq.City,
                State = hotelReq.State,
                Country = hotelReq.Country,
                ZipCode = hotelReq.ZipCode,
                CreatedDateTime = DateTime.Now
            };  
            var hotel = new Hotels() {
                HotelName = hotelReq.HotelName,
                HotelContactNumber = hotelReq.HotelContactNumber,
                HotelEmailAddress = hotelReq.HotelEmailAddress,
                HotelWebsite = hotelReq.HotelWebsite,
                HotelDescription = hotelReq.HotelDescription,
                HotelFloorCount = hotelReq.HotelFloorCount,
                HotelRoomCapacity = hotelReq.HotelRoomCapacity,
                HotelChainId = hotelReq.HotelChainId,
                Address = address,
                StarRatingId = hotelReq.StarRatingId,
                CheckInTime = hotelReq.CheckInTime,
                CheckOutTime = hotelReq.CheckOutTime,
                CreatedDateTime = DateTime.Now
        };
             
            res = _rep.CreateHotel(hotel);
            return res;
        }

        public SingleRsp UpdateHotel(HotelReq hotelReq)
        {
            var res = new SingleRsp();
            
            var hotel = ReadModel(hotelReq.HotelId).Data;
            var address = new Addresses();
            if (hotel != null)
            {
                if(hotel.Address != null)
                {
                    address = new Addresses()
                    {
                        AddressId = hotel.AddressId,
                        AddressLine1 = hotelReq.AddressLine1,
                        AddressLine2 = hotelReq.AddressLine2,
                        City = hotelReq.City,
                        State = hotelReq.State,
                        Country = hotelReq.Country,
                        ZipCode = hotelReq.ZipCode
                    };   
                }
                hotel.HotelId = hotelReq.HotelId;
                hotel.HotelName = hotelReq.HotelName;
                hotel.HotelContactNumber = hotelReq.HotelContactNumber;
                hotel.HotelEmailAddress = hotelReq.HotelEmailAddress;
                hotel.HotelWebsite = hotelReq.HotelWebsite;
                hotel.HotelDescription = hotelReq.HotelDescription;
                hotel.HotelFloorCount = hotelReq.HotelFloorCount;
                hotel.HotelRoomCapacity = hotelReq.HotelRoomCapacity;
                hotel.HotelChainId = hotelReq.HotelChainId;
                hotel.Address = address;
                hotel.StarRatingId = hotelReq.StarRatingId;
                hotel.CheckInTime = hotelReq.CheckInTime;
                hotel.CheckOutTime = hotelReq.CheckOutTime;
            }

            

            res = _rep.UpdateHotel(hotel);
            return res;
        }

        public SingleRsp DeleteHotel(int id)
        {
            var res = new SingleRsp();

            var hotel = ReadModel(id).Data;
            
            res = _rep.DeleteHotel(hotel);
            return res;
        }
        #region -- Overrides --
        public override SingleRsp Create(Hotels m)
        {
            return base.Create(m);
        }

        public override MultipleRsp Create(List<Hotels> l)
        {
            return base.Create(l);
        }

        public override SingleRsp Delete(int id)
        {
            return base.Delete(id);
        }

        public override SingleRsp Delete(string code)
        {
            return base.Delete(code);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var data = _rep.Read(id);
            res.Data = data;
            Console.WriteLine("checking data "+res.Data);
            return res;
        }

        public override SingleRsp Read(string code)
        {
            return base.Read(code);
        }

        public override int Remove(int id)
        {
            return base.Remove(id);
        }

        public override SingleRsp Restore(int id)
        {
            return base.Restore(id);
        }

        public override SingleRsp Restore(string code)
        {
            return base.Restore(code);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override SingleRsp Update(Hotels m)
        {
            return base.Update(m);
        }

        public override MultipleRsp Update(List<Hotels> l)
        {
            return base.Update(l);
        }
        
        #endregion
    }
}
