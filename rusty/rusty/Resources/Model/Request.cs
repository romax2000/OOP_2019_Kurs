using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Request
    {
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Specification { get; set; }
        public string Imagie { get; set; }
        public int StorageId { get; set; }
        public string StorageName { get; set; }
        public string Status { get; set; }
        public string ImagieOn { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
