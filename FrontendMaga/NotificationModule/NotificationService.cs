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
                if(val.val > maxValue)
                {
                    table.Rows.Add(minValue, maxValue, val.val_date, val.val, "Превышение нормы");
                }

                if (val.val < minValue)
                {
                    table.Rows.Add(minValue, maxValue, val.val_date, val.val, "Значение ниже нормы");
                }
            }

            return table;


        }

     
    }
}
