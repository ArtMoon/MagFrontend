using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMaga.Data.DataModels.Knowledge
{
    public class Problem
    {
        public int pr_id { get; set; }
        public string pr_cond { get; set; }
        public float pr_value { get; set; }
        public float? pr_bound_value { get; set; }
        public int sens_id { get; set; }
        public string pr_text { get; set; }
        public string pr_color { get; set; }
        public string pr_nn { get; set; }
        public int ap_id { get; set; }
    }
}
