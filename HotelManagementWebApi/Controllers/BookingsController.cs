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
    public class BookingsController : ControllerBase
    {
        private BookingSvc bookingSvc;
        public BookingsController()
        {
            bookingSvc = new BookingSvc();
        }
        [HttpGet]
        public IActionResult GetBookings([FromQuery] QueryStringParameters bookingsParameter)
        {
            var res = new SingleRsp();
            res = bookingSvc.getAllBookings(bookingsParameter);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var res = new SingleRsp();
            res = bookingSvc.Read(id);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("hotel/{id}")]
        public IActionResult GetBookingsByHotelId(int id)
        {
            var res = new SingleRsp();
            res = bookingSvc.Read(id);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpGet("filter")]
        public IActionResult GetBookings([FromQuery] BookingParameters BookingParameters)
        {
            var bookings = new SingleRsp();
            bookings = bookingSvc.GetBookingsByCondition(BookingParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(bookings.Metadata));

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }
    }
}
