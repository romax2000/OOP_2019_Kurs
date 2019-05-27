using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string Login { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Adres { get; set; }
        public string Person { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
