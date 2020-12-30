using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Alexandru_Proiect_App_Web.Models
{
    public class CarPack
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int PackID { get; set; }
        public Pack Pack { get; set; }
       
    }
}
