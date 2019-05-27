using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Workplace
    {
        public int WorkplaceId { get; set; }
        public string WorkplaceName { get; set; }
        public string Specification { get; set; }

        public virtual ICollection <Master> Master { get; set; }
    }
}
