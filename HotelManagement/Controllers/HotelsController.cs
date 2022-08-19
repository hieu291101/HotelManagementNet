using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class HotelsController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/Hotels
        public IQueryable<Hotels> GetHotels()
        {
            return db.Hotels;
        }

        // GET: api/Hotels/5
        [ResponseType(typeof(Hotels))]
        public IHttpActionResult GetHotels(int id)
        {
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);
        }

        // PUT: api/Hotels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotels(int id, Hotels hotels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotels.HotelID)
            {
                return BadRequest();
            }

            db.Entry(hotels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Hotels
        [ResponseType(typeof(Hotels))]
        public IHttpActionResult PostHotels(Hotels hotels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hotels.Add(hotels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hotels.HotelID }, hotels);
        }

        // DELETE: api/Hotels/5
        [ResponseType(typeof(Hotels))]
        public IHttpActionResult DeleteHotels(int id)
        {
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return NotFound();
            }

            db.Hotels.Remove(hotels);
            db.SaveChanges();

            return Ok(hotels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelsExists(int id)
        {
            return db.Hotels.Count(e => e.HotelID == id) > 0;
        }
    }
}