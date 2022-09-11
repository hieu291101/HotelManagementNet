using HotelManagementWebApi.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private RoomSvc roomSvc;
        public RoomsController()
        {
            roomSvc = new RoomSvc();
        }
        [HttpGet]
        public IActionResult GetBookings([FromQuery] QueryStringParameters roomParameter)
        {
            var res = new SingleRsp();
            res = roomSvc.getAllRooms(roomParameter);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var res = new SingleRsp();
            res = roomSvc.Read(id);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("room/listActive")]
        public IActionResult GetListRoomsByActive([FromQuery] RoomParameters roomParameter)
        {

            var res = new SingleRsp();
            res = roomSvc.GetListRoomsByActive(roomParameter);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        //[HttpGet("room/deactive")]
        //public IActionResult GetRoomDeactive(int roomID)
        //{

        //    var res = new SingleRsp();
        //    res = roomSvc.GetRoomDeactive(roomID);
        //    if (res == null)
        //        NotFound();
        //    return Ok(res);
        //}


        //[HttpGet("filter")]
        //public IActionResult GetRooms([FromQuery] RoomParameters RoomParameters)
        //{
        //    var rooms = new SingleRsp();
        //    rooms = roomSvc.GetRoomsByCondition(RoomParameters);

        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(rooms.Metadata));

        //    if (rooms == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(rooms);
        //}
    }
}
