using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Storage
    {
        public int StorageId { get; set; }
        public int NumberProduct { get; set; }
        public string Product { get; set; }
        public int Number { get; set; }
        public int SupplyId { get; set; }
        public Single Cost { get; set; }
        

        public virtual Supply Supply { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
