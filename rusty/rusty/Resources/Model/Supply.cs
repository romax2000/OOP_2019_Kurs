using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Supply
    {
        public int SupplyId { get; set; }
        public string Product { get; set; }
        public int Number { get; set; }
        public DateTime DateOrder { get; set; }
        public int ShipperId { get; set; }
        public Single Cost { get; set; }
        public string ShipperName { get; set; }

        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<Storage> Storage { get; set; }
    }
}
