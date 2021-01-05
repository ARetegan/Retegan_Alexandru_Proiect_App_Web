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

        [Display(Name = "Seller Name")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", 
        ErrorMessage = "Seller name must contain 2 words"), Required, StringLength(50, MinimumLength = 3)]
        public string Buyer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public int FuelID { get; set; }
        public Fuel Fuel { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Production Date")]
        public DateTime DeliveryDate { get; set; }
        public ICollection<CarPack> CarPacks { get; set; }


    }
}
