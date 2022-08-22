using HotelManagementWebApi.BLL;
using HotelManagementWebApi.Common.Req;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetHotels()
        {
            var products = new SingleRsp();
            products = hotelSvc.GetAllHotels();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
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

        // POST api/Hotels
        [HttpPost]
        public IActionResult GetHotels([FromBody] SearchReq searhReq)
        {
            var hotels = new SingleRsp();
            hotels = hotelSvc.Search(searhReq);
            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);
        }

        [HttpPost("create-hotel")]
        public IActionResult CreateHotel([FromBody] HotelReq hotelReq)
        {
            var res = new SingleRsp();
            res = hotelSvc.createHotel(hotelReq);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
