using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Retegan_Alexandru_Proiect_App_Web.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Display(Name = "Buyer Name")]
        public string Buyer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public int FuelID { get; set; }
        public Fuel Fuel { get; set; }

        [Display(Name = "Maximum Price")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Estimated Delivery Date")]
        public DateTime DeliveryDate { get; set; }
        public ICollection<CarPack> CarPacks { get; set; }


    }
}
