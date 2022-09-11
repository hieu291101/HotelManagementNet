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
        SqlConnection sql = new SqlConnection("Data Source=HUYNHTANTU\\SQLSERVER;Initial Catalog=Hotel;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        public BookingsController()
        {
            bookingSvc = new BookingSvc();
            roomSvc = new RoomSvc();
            sql.OpenAsync();
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
        public IActionResult PostBookingRoomByEmployee(BookingParameters bookingParameters)
        {
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
                
            } catch (Exception e)
            {
                res.SetMessage("FAILED by foreign key");
                res.Success = false;
                Console.WriteLine(e);
            }

            if (res == null)
                NotFound();
            return Ok(res);
        }

         
        [HttpPut("updateBookingRoomByEmployee")]
        public IActionResult PutBookingRoomByEmployee(int bookingID, int newRoomID)
        {
            SqlCommand cmd = new SqlCommand("spUpdateBookingRoomByEmployee", sql);
            var res = new SingleRsp();
            int currentRoomID = bookingSvc.GetRoomIDByBookingID(bookingID);
            int checkActiveRoom = roomSvc.GetRoomDeactive(newRoomID);

            try
            {
                if (checkActiveRoom == 0)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@currentRoomID", currentRoomID));
                    cmd.Parameters.Add(new SqlParameter("@newRoomID", newRoomID));
                    cmd.Parameters.Add(new SqlParameter("@bookingID", bookingID));
    
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        res.SetMessage("Update booking successfully");
                        res.Success = true;
                    }
                    else
                    {
                        res.SetMessage("FAILED");
                        res.Success = false;
                    }
                }
                else
                {
                    res.SetMessage("Room was booked");
                    res.Success = false;
                }

            }
            catch (Exception e)
            {
                res.SetMessage("FAILED by foreign key");
                res.Success = false;
                Console.WriteLine(e);
            }

            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpPut("updateCheckOutRoom")]
        public IActionResult PutCheckOutRoom(int bookingID, DateTime checkOutDate, string bookingPaymentType, decimal totalAmount)
        {
            SqlCommand cmd = new SqlCommand("spCheckOutRoom", sql);
            var res = new SingleRsp();
            int checkBookingID = bookingSvc.GetBookingByID(bookingID);

            try
            {
                if (checkBookingID != 0)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@bookingID", bookingID));
                    cmd.Parameters.Add(new SqlParameter("@checkOutDate", checkOutDate));
                    cmd.Parameters.Add(new SqlParameter("@bookingPaymentType", bookingPaymentType));
                    cmd.Parameters.Add(new SqlParameter("@totalAmount", totalAmount));

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        res.SetMessage("Check out room successfully");
                        res.Success = true;
                    }
                    else
                    {
                        res.SetMessage("FAILED");
                        res.Success = false;
                    }
                }
                else
                {
                    res.SetMessage("Check out room failed");
                    res.Success = false;
                }

            }
            catch (Exception e)
            {
                res.SetMessage("FAILED by foreign key");
                res.Success = false;
                Console.WriteLine(e);
            }

            if (res == null)
                NotFound();
            return Ok(res);
        }

        [HttpDelete("deleteBookingRoomByEmployee")]
        public IActionResult DeleteBookingRoomByEmployee(int bookingID)
        {
            SqlCommand cmd = new SqlCommand("spDeleteBookingRoomByEmployee", sql);
            var res = new SingleRsp();
            int currentRoomID = bookingSvc.GetBookingByID(bookingID);

            try
            {
                if (currentRoomID != 0)
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@bookingID", bookingID));

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        res.SetMessage("Delete booking successfully");
                        res.Success = true;
                    }
                    else
                    {
                        res.SetMessage("FAILED");
                        res.Success = false;
                    }
                }
                else
                {
                    res.SetMessage("Delete booking failed");
                    res.Success = false;
                }

            }
            catch (Exception e)
            {
                res.SetMessage("FAILED by foreign key");
                res.Success = false;
                Console.WriteLine(e);
            }

            if (res == null)
                NotFound();
            return Ok(res);
        }

    }
}
