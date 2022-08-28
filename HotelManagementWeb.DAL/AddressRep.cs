using HotelManagementWebApi.Common.DAL;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.DAL
{
    public class AddressRep : GenericRep<HotelContext, Addresses>
    {
        public SingleRsp CreateAddress(Addresses address)
        {
            var res = new SingleRsp();
            
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    base.Create(address);
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
