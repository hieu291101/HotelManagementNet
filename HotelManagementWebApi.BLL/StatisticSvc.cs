using HotelManagementWebApi.Common.BLL;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL;
using HotelManagementWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HotelManagementWebApi.BLL
{
    public class StatisticSvc : GenericSvc<StatisticRep, Bookings>
    {
       
        public SingleRsp getDaTaForStatistic(int hotelId, int year)
        {
            SingleRsp res = new SingleRsp();
            List<object> objects = new List<object>();
            DataTable data = _rep.getDaTaForStatistic(hotelId, year);
            foreach (DataRow item in data.Rows)
            {
                IDictionary<string, dynamic> record = new Dictionary<string, dynamic>();
               
                record.Add("hotelID", Convert.ToInt32(item["HotelID"]));
                record.Add("hotelName", item["HotelName"].ToString());
                record.Add("month", Convert.ToInt32(item["month"]));
                record.Add("totalAmount", Convert.ToDecimal(item["totalAmount"]));

                objects.Add(record);
            }

            res.Data = objects;
            return res;
        }

        public SingleRsp getDaTaForStatisticInPeriod(int hotelId, DateTime fromDate, DateTime toDate)
        {
            SingleRsp res = new SingleRsp();
            List<object> objects = new List<object>();
            DataTable data = _rep.getDaTaForStatisticInPeriod(hotelId, fromDate, toDate);
            foreach (DataRow item in data.Rows)
            {
                IDictionary<string, dynamic> record = new Dictionary<string, dynamic>();

                record.Add("hotelID", Convert.ToInt32(item["HotelID"]));
                record.Add("hotelName", item["HotelName"].ToString());
                record.Add("month",item["month"] + "/" + item["year"]);
                record.Add("totalAmount", Convert.ToDecimal(item["totalAmount"]));

                objects.Add(record);
            }

            res.Data = objects;
            return res;
        }
    }
}
