using HotelManagementWebApi.Common.DAL;
using HotelManagementWebApi.Common.Rsp;
using HotelManagementWebApi.DAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HotelManagementWebApi.DAL
{
    public class StatisticRep : GenericRep<HotelContext, Bookings>
    {
        public DataTable getDaTaForStatistic(int hotelId, int year)
        {
            SqlConnection sql = new SqlConnection("Data Source=NEWBIE\\MYSQLS;Initial Catalog=Hotel;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            DataTable dt = new DataTable();
            SqlCommand sqlcmd = new SqlCommand("spHotelStatisticBySingleYear", sql);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add(new SqlParameter("@hotelID", hotelId));
            sqlcmd.Parameters.Add(new SqlParameter("@year", year));
            SqlDataAdapter sqldta = new SqlDataAdapter(sqlcmd);
            sqldta.Fill(dt);
            return dt;
        }
    }
}
