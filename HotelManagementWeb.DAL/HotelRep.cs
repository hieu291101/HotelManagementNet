using HotelManagementWebApi.Common.DAL;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HotelManagementWebApi.Common.Rsp;
using System.Linq.Expressions;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementWebApi.DAL
{
    public class HotelRep : GenericRep<HotelContext, Hotels>
    {
        #region -- Overide --
        public override Hotels Read(int id)
        {
            var res = All.FirstOrDefault(htl => htl.HotelId == id);
            return res;
        }
        #endregion

        public Hotels ReadModel(int id)
        {
            var res = Context.Hotels.Include(a => a.Address).FirstOrDefault(htl => htl.HotelId == id);
            return res;
        }
        public SingleRsp GetAllHotels(QueryStringParameters hotelParameters)
        {
            var res = new SingleRsp();
            var data = PagedList<Hotels>.ToPagedList(All, hotelParameters.PageNumber, hotelParameters.PageSize);

            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            res.Data = data;
            res.Metadata = metadata;
            return res;
        }


        public SingleRsp GetHotelsByCondition(HotelParameters hotelParameters)
        {
            var hotels = Read(o => o.HotelName.Contains(hotelParameters.Keyword));

            if (hotelParameters.City != null)
                hotels = hotels.Where(o => o.Address.City.Equals(hotelParameters.City));

            var res = new SingleRsp();
            var data =
                PagedList<Hotels>.ToPagedList(hotels, hotelParameters.PageNumber, hotelParameters.PageSize);

            var metadata = new
            {
                data.TotalCount,
                data.PageSize,
                data.CurrentPage,
                data.TotalPages,
                data.HasNext,
                data.HasPrevious
            };
            res.Data = data;
            res.Metadata = metadata;
            return res;
        }

        public SingleRsp CreateHotel(Hotels hotel)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Create(hotel);
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

        public SingleRsp UpdateHotel(Hotels hotel)
        {
            var res = new SingleRsp();

            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Update(hotel);
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

        public SingleRsp DeleteHotel(Hotels hotel)
        {
            var res = new SingleRsp();
            
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    Delete(hotel);
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
    }
}
