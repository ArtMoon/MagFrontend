using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMaga.Data.DataModels
{
    public class ApparatusModel : ICloneable
    {
        public int ap_id { get; set; }
        public int? parent_ap_id { get; set; }
        public string short_name { get; set; }
        public string full_name { get; set; }

        public object Clone()
        {
            return new ApparatusModel() { ap_id = this.ap_id, full_name = this.full_name, parent_ap_id = this.parent_ap_id, short_name = this.short_name};
        }
    }
}
