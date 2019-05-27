using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Shipper
    {
        public int ShipperId        { get; set; }
        public string CompanyName   { get; set; }
        public string Address       { get; set; }
        public string PhoneNumber   { get; set; }

        public virtual ICollection<Supply> Supply { get; set; }
    }
}
