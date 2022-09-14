using HotelManagementWebApi.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Req;
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

        [HttpPost("guestLogin")]
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

        [HttpPost]
        public IActionResult CreateGuest([FromBody] GuestReq guestReq)
        {
            var res = new SingleRsp();
            res = guestSvc.CreateGuest(guestReq);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGuest(int id, [FromBody] GuestReq guestReq)
        {
            var res = new SingleRsp();

            try
            {
                if (id != guestReq.GuestId)
                    return BadRequest("Guest ID mismatch");

                var guest = guestSvc.ReadModel(id).Data;

                if (guest == null)
                {
                    return NotFound($"Guest with ID = {id} not found");
                }

                res = guestSvc.UpdateGuest(guestReq);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var res = new SingleRsp();

            try
            {
                var guest = guestSvc.Read(id).Data;

                if (guest == null)
                {
                    return NotFound($"Guest with ID = {id} not found");
                }

                res = guestSvc.DeleteGuest(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
