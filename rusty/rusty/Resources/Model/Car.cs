using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rusty.Resources.Model
{
    class Car
    {
        public int CarId {get; set; }
        public string CarMark { get; set; }
        public string CarModel { get; set; }
        public int Year { get; set; }
        public string Engine { get; set; }
        public string Body { get; set; }
        public string Color { get; set; }
        public string RegNummber { get; set; }

        public override string ToString()
        {
            return $"{CarId} - {CarMark}- {CarModel}";
        }

        public virtual ICollection<Request> Request { get; set; }
    }
}
