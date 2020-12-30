using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Alexandru_Proiect_App_Web.Models
{
    public class Pack
    {
        public int ID { get; set; }
        public string PackName { get; set; }
        public ICollection<CarPack> CarPacks { get; set; }
    }
}
