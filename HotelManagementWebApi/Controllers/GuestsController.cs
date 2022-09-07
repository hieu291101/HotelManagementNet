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
    public class GuestsController : ControllerBase
    {
        private GuestSvc guestSvc;
        public GuestsController()
        {
            guestSvc = new GuestSvc();
        }

        //[HttpGet]
        //public IActionResult GetGuests([FromQuery] QueryStringParameters guestParameter)
        //{
        //    var res = new SingleRsp();
        //    res = guestSvc.getAllRooms(guestParameter);
        //    if (res == null)
        //        NotFound();
        //    return Ok(res);
        //}

        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var res = new SingleRsp();
            res = guestSvc.Read(id);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("guestByNumberPhone")]
        public IActionResult GetGuestByNumberPhone(string numberPhone)
        {

            var res = new SingleRsp();
            res = guestSvc.getGuestByNumberPhone(numberPhone);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("roomByNumberPhone")]
        public IActionResult GetRoomByNumberPhone(string numberPhone)
        {

            var res = new SingleRsp();
            res = guestSvc.getRoomByNumberPhone(numberPhone);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("guestLogin")]
        public IActionResult GetGuestLogin(string guestEmail, string numberPhone)
        {

            var res = new SingleRsp();
            res = guestSvc.getGuestLogin(guestEmail, numberPhone);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        //[HttpPost("guestBookingRoom")]
        //public IActionResult PostGuestBookingRoom(string guestEmail, string numberPhone)
        //{

        //    var res = new SingleRsp();
        //    res = guestSvc.postGuestBookingRoom(guestEmail, numberPhone);
        //    if (res == null)
        //        NotFound();
        //    return Ok(res);
        //}


        //[HttpGet("filter")]
        //public IActionResult GetRooms([FromQuery] RoomParameters RoomParameters)
        //{
        //    var rooms = new SingleRsp();
        //    rooms = guestSvc.GetRoomsByCondition(RoomParameters);

        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(rooms.Metadata));

        //    if (rooms == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(rooms);
        //}
    }
}
