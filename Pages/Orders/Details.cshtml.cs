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
    public class DetailsModel : PageModel
    {
        private readonly Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext _context;

        public DetailsModel(Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
