using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontendMaga.Interfaces;
using FrontendMaga.Data.DataModels;

namespace FrontendMaga.NotificationModule
{
    public class SensorNotificationService : INotifyService<Sensor_Vals>
    {
        public DataTable GetNotification(List<Sensor_Vals> values, double maxValue, double minValue)
        {
            var table = new DataTable();
            table.Columns.Add("MinNorm");
            table.Columns.Add("MaxNorm");
            table.Columns.Add("DateTime");
            table.Columns.Add("Value");
            table.Columns.Add("Comment");

            foreach(Sensor_Vals val in values)
            {
                if(val.Sensor_value > maxValue)
                {
                    table.Rows.Add(minValue, maxValue, val.Date_time, val.Sensor_value, "Превышение нормы");
                }

                if (val.Sensor_value < minValue)
                {
                    table.Rows.Add(minValue, maxValue, val.Date_time, val.Sensor_value, "Значение ниже нормы");
                }
            }

            return table;


        }

     
    }
}
