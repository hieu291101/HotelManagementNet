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

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetHotels(int id)
        {
            var products = new SingleRsp();
            products = hotelSvc.Read(id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetHotels([FromBody]SearchReq searhReq)
        {
            var products = new SingleRsp();
            products = hotelSvc.Search(searhReq);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
