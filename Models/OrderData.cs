using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Alexandru_Proiect_App_Web.Models
{
    public class OrderData
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Pack> Packs { get; set; }
        public IEnumerable<CarPack> CarPacks { get; set; }
    }
}
