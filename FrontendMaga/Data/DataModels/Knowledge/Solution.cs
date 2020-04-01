using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMaga.Data.DataModels.Knowledge
{
    public class Solution
    {
        public int sol_id { get; set; }
        public int rs_id { get; set; }
        public string sol_text { get; set; }
        public string sol_par { get; set; }
        public int sens_id { get; set; }
        public string sol_nn { get; set; }
    }
}
