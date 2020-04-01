using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMaga.Data.DataModels.Knowledge
{
    public class Reason
    {
        public int rs_id { get; set; }
        public int pr_id { get; set; }
        public string rs_text { get; set; }
        public string rs_cond { get; set; }
        public float rs_value { get; set; }
        public int sens_id { get; set; }
        public string nn_rs { get; set; }
        public float rs_probability { get; set; }
    }
}
