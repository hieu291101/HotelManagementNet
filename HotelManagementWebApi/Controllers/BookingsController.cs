using HotelManagementWebApi.BLL;
using HotelManagementWebApi.Common.Param;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private RoomSvc roomSvc;
        public BookingsController()
        {
            bookingSvc = new BookingSvc();
            roomSvc = new RoomSvc();
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

        [HttpPost("bookingRoomByGuest")]
        public IActionResult PostBookingRoomByGuest(BookingParameters bookingParameters)
        {
            var res = new SingleRsp();
            res = bookingSvc.postGuestBookingRoomByGuest(bookingParameters);
            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpPost("bookingRoomByEmployee")]
        public async Task<IActionResult> PostBookingRoomByEmployee(BookingParameters bookingParameters)
        {
            SqlConnection sql = new SqlConnection("Data Source=HUYNHTANTU\\SQLSERVER;Initial Catalog=Hotel;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand("spBookingRoomByEmployee", sql);
            var res = new SingleRsp();
            int checkActiveRoom = roomSvc.GetRoomDeactive(bookingParameters.bpRoomID);
            try
            {    
                if (checkActiveRoom == 0)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@guestID", bookingParameters.bpGuestID));
                    cmd.Parameters.Add(new SqlParameter("@roomID", bookingParameters.bpRoomID));
                    cmd.Parameters.Add(new SqlParameter("@hotelID", bookingParameters.bpHotelID));
                    cmd.Parameters.Add(new SqlParameter("@checkInDate", bookingParameters.bpCheckInDate));
                    cmd.Parameters.Add(new SqlParameter("@checkOutDate", bookingParameters.bpCheckOutDate));
                    cmd.Parameters.Add(new SqlParameter("@employeeID", bookingParameters.bpEmployeeID));

                    await sql.OpenAsync();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        res.SetMessage("Booking successfully");
                        res.Success = true;
                    }
                    else
                    {
                        if ((bookingParameters.bpCheckInDate - DateTime.Now).TotalDays < 0)
                        {
                            res.SetMessage("CheckInDate might be greater or equal than current date");
                            res.Success = false;
                        }
                        else
                        {
                            res.SetMessage("FAILED");
                            res.Success = false;
                        }
                    }
                }
                else
                {
                    res.SetMessage("Room was booked");
                    res.Success = false;
                }
                
            } catch (Exception)
            {
                res.SetMessage("FAILED by foreign key");
                res.Success = false;
            }

            if (res == null)
                NotFound();
            return Ok(res);
        }
    }
}
