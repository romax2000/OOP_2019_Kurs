using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Master
    {
        public int MasterId { get; set; }
        public string Login { get; set; }
        public string FIO { get; set; }
        public string Spec { get; set; }
        public int Exp { get; set; }
        public string Phone { get; set; }
        public int WorkplaceId { get; set; }
        public string WorkplaseName { get; set; }
        public Single Salary { get; set; }

        public virtual Workplace Workplace { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
