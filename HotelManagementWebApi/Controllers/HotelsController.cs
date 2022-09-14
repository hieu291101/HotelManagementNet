using HotelManagementWebApi.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Rsp;
//using HotelManagementWebApi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private HotelSvc hotelSvc;
        public HotelsController()
        {
            hotelSvc = new HotelSvc();
        }

        // GET: api/Hotels
        [HttpGet]
        public IActionResult GetHotels([FromQuery] QueryStringParameters hotelParameters)
        {
            var hotels = new SingleRsp();
            hotels = hotelSvc.GetAllHotels(hotelParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(hotels.Metadata));

            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels.Data);
        }

        [HttpGet("filter")] 
        public IActionResult GetHotels([FromQuery] HotelParameters hotelParameters)
        {
            var hotels = new SingleRsp();
            hotels = hotelSvc.GetHotelsByCondition(hotelParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(hotels.Metadata));

            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);
        }

        // GET: api/Hotels/id
        [HttpGet("{id}")]
        public IActionResult GetHotel(int id)
        {
            var hotels = new SingleRsp();
            hotels = hotelSvc.Read(id);

            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);
        }


        [HttpPost]
        public IActionResult CreateHotel([FromBody] HotelReq hotelReq)
        {
            var res = new SingleRsp();
            res = hotelSvc.CreateHotel(hotelReq);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, [FromBody] HotelReq hotelReq)
        {
            var res = new SingleRsp();

            try
            {
                if (id != hotelReq.HotelId)
                    return BadRequest("Hotel ID mismatch");

                var hotel = hotelSvc.ReadModel(id).Data;

                if (hotel == null)
                {
                    return NotFound($"Hotel with ID = {id} not found");
                }

                res = hotelSvc.UpdateHotel(hotelReq);
            }
            catch(Exception)
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
        public IActionResult DeleteHotel(int id)
        {
            var res = new SingleRsp();

            try
            {
                var hotel = hotelSvc.ReadModel(id).Data;

                if (hotel == null)
                {
                    return NotFound($"Hotel with ID = {id} not found");
                }

                res = hotelSvc.DeleteHotel(id);
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
