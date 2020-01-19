using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMaga.Data.DataModels
{
    public class ApparatusModel : ICloneable
    { 
        public int Id_Ap { get; set; }
        public string App_name { get; set; }
        public int? Parent_id { get; set; }

        public object Clone()
        {
            return new ApparatusModel() { Id_Ap = this.Id_Ap, App_name = this.App_name, Parent_id = this.Parent_id };
        }
    }
}
