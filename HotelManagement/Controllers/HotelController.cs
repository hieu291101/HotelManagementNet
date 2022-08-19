using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace HotelManagement.Controllers
{
    public class HotelController : ApiController
    {
        public IHttpActionResult GetAllHotels()
        {
            IList<Hotel> hotels = null;
            
            using(var ctx = new HotelEntities())
            {
                hotels = ctx.Hotels.Include(s => s.Address)
                                  .Include(s => s.Employees)
                                  .Include(s => s.HotelChainHasHotels)
                                  .Include(s => s.Rooms).AsNoTracking().Select(s => s).ToList();
            }

            if(hotels.Count == 0)
            {
                return NotFound();
            }

            return Ok(hotels);
        }

        public IHttpActionResult GetHotelByID(int id)
        {
            Hotel hotel = new Hotel(){HotelID = 1, HotelName = "Royal"};

            //using (var ctx = new HotelEntities())
            //{
            //    hotel = ctx.Hotels.Include("Address")
            //                      .Include("Employees")
            //                      .Include("HotelChainHasHotels")
            //                      .Include("Rooms").AsNoTracking().FirstOrDefault(s => s.HotelID == id);
            //}

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }
    }
}
