using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Schedule
    {
        DAL_Schedules dal_schedule = new DAL_Schedules();
        public DTO_Schedule GetScheduleByID(string ID)
        {
            DTO_Schedule schedule = new DTO_Schedule();
            DataTable dt = dal_schedule.GetScheduleTableByID(ID);
            DataRow dr = dt.Rows[0];

            schedule.ID = dr[0].ToString();
            schedule.Date = dr[1].ToString();
            schedule.Time = dr[2].ToString();
            schedule.AircraftID = dr[3].ToString();
            schedule.RouteID = dr[4].ToString();
            schedule.EconomyPrice = dr[5].ToString();
            schedule.Confirmed = dr[6].ToString();
            schedule.FlightNumber = dr[7].ToString();

            return schedule;
        }
    }
}
