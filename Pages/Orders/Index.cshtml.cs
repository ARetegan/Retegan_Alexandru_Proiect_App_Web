using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Retegan_Alexandru_Proiect_App_Web.Data;
using Retegan_Alexandru_Proiect_App_Web.Models;

namespace Retegan_Alexandru_Proiect_App_Web.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext _context;

        public IndexModel(Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }
        public OrderData OrderD { get; set; }
        public int OrderID { get; set; }
        public int PackID { get; set; }

        public async Task OnGetAsync(int? id, int? packID)
        {
            OrderD = new OrderData();
            OrderD.Orders = await _context.Order
                .Include(b => b.Fuel)
                .Include(b => b.CarPacks)
                .ThenInclude(b => b.Pack)
                .AsNoTracking().OrderBy(b => b.Model).ToListAsync();
            if (id != null) { OrderID = id.Value; 
                              Order order = OrderD.Orders.Where(i => i.ID == id.Value).Single();
                OrderD.Packs = order.CarPacks.Select(s => s.Pack); }
        }
    }
}
