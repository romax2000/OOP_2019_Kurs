using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int MasterId { get; set; }
        public string MasterName { get; set; }
        public int RequestId { get; set; }
        public string Specification { get; set; }
        public string Status { get; set; }
        public DateTime Start { get; set; }
        public string Finish { get; set; }
        public Single Cast { get; set; }

        public override string ToString()
        {
            return $"{OrderId}";
        }

        public virtual Master Master { get; set; }
        public virtual Request Request { get; set; }
    }
}
