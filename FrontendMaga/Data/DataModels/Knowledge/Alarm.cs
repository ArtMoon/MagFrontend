using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMaga.Data.DataModels.Knowledge
{
    public class Alarm
    {
        public int al_id { get; set; }
        public DateTime al_date { get; set; }
        public float al_value { get; set; }
        public string al_text { get; set; }
        public string al_reason { get; set; }
        public string al_param { get; set; }
        public string sol_text { get; set; }
        public string sens_name { get; set; }
        public int sens_id { get; set; }
        public int ap_id { get; set; }
    }
}
