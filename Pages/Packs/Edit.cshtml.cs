using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Retegan_Alexandru_Proiect_App_Web.Data;
using Retegan_Alexandru_Proiect_App_Web.Models;

namespace Retegan_Alexandru_Proiect_App_Web.Pages.Packs
{
    public class EditModel : PageModel
    {
        private readonly Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext _context;

        public EditModel(Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext context)
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
           ViewData["OrderID"] = new SelectList(_context.Order, "ID", "ID");
           ViewData["PackID"] = new SelectList(_context.Set<Pack>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarPack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarPackExists(CarPack.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarPackExists(int id)
        {
            return _context.CarPack.Any(e => e.ID == id);
        }
    }
}
