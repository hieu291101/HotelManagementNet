using HotelManagementWebApi.Common.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.BLL
{
    public class GuestSvc : GenericSvc<GuestRep, Guests>
    {
        public SingleRsp getGuestByNumberPhone(string numberPhone)
        {
            var res = new SingleRsp();   // Tao mot cai response
            var data = _rep.ReadGuestByPhoneNumber(numberPhone);  // tao bien data va gan numberphone doc duoc
            res.Data = data;

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
