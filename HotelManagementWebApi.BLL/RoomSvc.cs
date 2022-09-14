using HotelManagementWebApi.Common.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementWebApi.BLL
{
    public class RoomSvc : GenericSvc<RoomRep, Rooms>
    {
        public SingleRsp getAllRooms(QueryStringParameters roomParameters)
        {
            return _rep.GetAllRooms(roomParameters);
        }

        public SingleRsp GetListRoomsByActive(RoomParameters roomParameters)
        {
            return _rep.GetListRoomsByActive(roomParameters);
        }
        public int GetRoomDeactive(int roomID)
        {
            return _rep.GetRoomDeactive(roomID);
        }


        public SingleRsp CreateRoom(RoomReq roomReq)
        {
            var res = new SingleRsp();

            var room = new Rooms()
            {
                RoomNumber = roomReq.RoomNumber,
                RoomTypeId = roomReq.RoomTypeId,
                HotelId = roomReq.HotelId,
                CreatedDateTime = DateTime.Now
            };
            res = _rep.CreateRoom(room);
            return res;
        }

        public int UpdateRoomDeactive(int roomID)
        {
            return _rep.GetRoomDeactive(roomID);
        }



       

        public SingleRsp UpdateRoom(RoomReq roomReq)
        {
            var res = new SingleRsp();

            var room = Read(roomReq.RoomId).Data;
            var address = new Addresses();
            if (room != null)
            {
                room.RoomNumber = roomReq.RoomNumber;
                room.RoomTypeId = roomReq.RoomTypeId;
            }

            res = _rep.UpdateRoom(room);
            return res;
        }

        public SingleRsp DeleteRoom(int id)
        {
            var res = new SingleRsp();

            var hotel = Read(id).Data;

            res = _rep.DeleteHotel(hotel);
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

        public override SingleRsp Create(Rooms m)
        {
            return base.Create(m);
        }

        public override MultipleRsp Create(List<Rooms> l)
        {
            return base.Create(l);
        }

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
        //    res.Data = _rep.GetRoomsEmpty(active);
        //    return res;
        //}


        public override SingleRsp Read(string code)
        {
            return base.Read(code);
        }

        public override SingleRsp Update(Rooms m)
        {
            return base.Update(m);
        }

        public override MultipleRsp Update(List<Rooms> l)
        {
            return base.Update(l);
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
