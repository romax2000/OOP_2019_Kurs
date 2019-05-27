using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Single Cost { get; set; }
        
        public virtual ICollection<Request> Request { get; set; }
        public override string ToString()
        {
            return ServiceName;
        }
    }
}
