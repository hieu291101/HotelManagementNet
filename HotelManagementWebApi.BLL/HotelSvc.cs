using HotelManagementWebApi.Common.BLL;
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
        public SingleRsp Search(SearchReq searhReq)
        {
            var res = new SingleRsp();
            var offset = (searhReq.Page - 1) * searhReq.Page;


            var hotels = new {
                Data = _rep.limit(_rep.SearchHotelsByName(searhReq.Keyword), offset, searhReq.Size),
                Page = searhReq.Page,
                Size = searhReq.Size
            };

            res.Data = hotels;

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
