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

namespace Retegan_Alexandru_Proiect_App_Web.Pages.Orders
{
    public class EditModel : CarPacksPageModel
    {
        private readonly Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext _context;

        public EditModel(Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(b => b.Fuel)
                .Include(b => b.CarPacks)
                .ThenInclude(b => b.Pack)
                .AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Order == null)
            {
                return NotFound();
            }

            PopulateAssignedPackData(_context, Order);

            ViewData["FuelID"] = new SelectList(_context.Set<Fuel>(), "ID", "Type");
            return Page();
        }

            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://aka.ms/RazorPagesCRUD.

            public async Task<IActionResult> OnPostAsync(int? id, string[] selectedPacks)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var orderToUpdate = await _context.Order
                    .Include(i => i.Fuel)
                    .Include(i => i.CarPacks)
                        .ThenInclude(i => i.Pack)
                    .FirstOrDefaultAsync(s => s.ID == id);

                if (orderToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync<Order>(
                    orderToUpdate,
                    "Order",
                    i => i.Buyer, i => i.Brand, i => i.Model, i => i.Color, i => i.Fuel, i => i.Price, i => i.DeliveryDate))
                {
                    UpdateCarPacks(_context, selectedPacks, orderToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                UpdateCarPacks(_context, selectedPacks, orderToUpdate); 
                PopulateAssignedPackData(_context, orderToUpdate); 
                return Page();

                

            }
        }
    }



