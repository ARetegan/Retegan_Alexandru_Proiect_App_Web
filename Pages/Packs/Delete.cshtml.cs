using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Retegan_Alexandru_Proiect_App_Web.Data;
using Retegan_Alexandru_Proiect_App_Web.Models;

namespace Retegan_Alexandru_Proiect_App_Web.Pages.Packs
{
    public class DeleteModel : PageModel
    {
        private readonly Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext _context;

        public DeleteModel(Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarPack CarPack { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarPack = await _context.CarPack
                .Include(c => c.Order)
                .Include(c => c.Pack).FirstOrDefaultAsync(m => m.ID == id);

            if (CarPack == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarPack = await _context.CarPack.FindAsync(id);

            if (CarPack != null)
            {
                _context.CarPack.Remove(CarPack);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
