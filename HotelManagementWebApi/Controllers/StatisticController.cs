using HotelManagementWebApi.BLL;
using HotelManagementWebApi.Common.Rsp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebApi.Controllers
{
    public class StatisticController : Controller
    {
        private StatisticSvc statisticSvc;

        public StatisticController()
        {
            statisticSvc = new StatisticSvc();
        }
        [HttpPost("bookingRoomByEmployee")]
        public  IActionResult getHotelStatisticByYear(int hotelId, int year)
        {
 
            var res = new SingleRsp();

            try
            {
                if (hotelId != 0 && (year > 1900 && year <2100))
                {
                    res = statisticSvc.getDaTaForStatistic(hotelId, year);
                        
                }
                else
                {
                    res.SetMessage("Invalid input value");
                    res.Success = false;
                }

            }
            catch (Exception)
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
