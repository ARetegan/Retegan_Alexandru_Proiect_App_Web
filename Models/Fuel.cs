using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Alexandru_Proiect_App_Web.Models
{
    public class Fuel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
