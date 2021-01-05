using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Retegan_Alexandru_Proiect_App_Web.Models;

namespace Retegan_Alexandru_Proiect_App_Web.Data
{
    public class Retegan_Alexandru_Proiect_App_WebContext : DbContext
    {
        public Retegan_Alexandru_Proiect_App_WebContext (DbContextOptions<Retegan_Alexandru_Proiect_App_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Retegan_Alexandru_Proiect_App_Web.Models.Order> Order { get; set; }

        public DbSet<Retegan_Alexandru_Proiect_App_Web.Models.Fuel> Fuel { get; set; }

        public DbSet<Retegan_Alexandru_Proiect_App_Web.Models.Pack> Pack { get; set; }
    }
}
