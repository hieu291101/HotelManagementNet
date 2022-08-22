using HotelManagementWebApi.Common.DAL;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HotelManagementWebApi.Common.Rsp;
using System.Linq.Expressions;
using HotelManagementWebApi.Common.Req;

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

        public override IQueryable<Hotels> Search(Expression<Func<Hotels, bool>> inStock)
        {
            return All.Where(inStock);
        }

        public override List<Hotels> limit(List<Hotels> Ts, int offset, int size)
        {
            if (offset == 0 || size == 0)
                return Ts;
            return Ts.Skip(offset).Take(size).ToList();
        }

        #endregion
        public List<Hotels> SearchHotelsByName(String keyword)
        {
            if (keyword == "string")
                keyword = "";
            return Search(hotels => hotels.HotelName.Contains(keyword)).ToList();
        }

        public SingleRsp CreateHotel(Hotels hotel)
        {
            var res = new SingleRsp();

            using(var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    base.Create(hotel);
                    tran.Commit();
                } catch (Exception e)
                {
                    tran.Rollback();
                    res.SetError(e.StackTrace);
                }
            }
            return res;
        }

        

    }
}
