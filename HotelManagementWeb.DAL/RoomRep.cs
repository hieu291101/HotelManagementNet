using HotelManagementWebApi.Common;
using HotelManagementWebApi.Common.DAL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagementWebApi.DAL
{
    public class RoomRep : GenericRep<HotelContext, Rooms>
    {
        #region -- Overide --
        public override Rooms Read(int id)
        {
            return All.FirstOrDefault(o => o.RoomId == id);
        }
        public Rooms ReadRoomActive(int active)
        {
            return All.FirstOrDefault(o => o.Active == active);
        }
        #endregion
        public SingleRsp GetAllRooms(QueryStringParameters roomParameters)
        {
            var res = new SingleRsp();
            var data =
                PagedList<Rooms>.ToPagedList(All, roomParameters.PageNumber, roomParameters.PageSize);

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

        public SingleRsp GetListRoomsByActive(RoomParameters roomParameters)
        {
            var rooms = All;
                rooms = Read(r => r.Active == roomParameters.roomActive);
            var res = new SingleRsp();
            var data =
                PagedList<Rooms>.ToPagedList(rooms, roomParameters.PageNumber, roomParameters.PageSize);

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

        public int GetRoomDeactive(int roomID)
        {
            //var res = new SingleRsp();
            var data = from r in Context.Rooms
                       where r.RoomId == roomID
                       select r.Active ;
                   
            return data.SingleOrDefault();
        }
    }
}
