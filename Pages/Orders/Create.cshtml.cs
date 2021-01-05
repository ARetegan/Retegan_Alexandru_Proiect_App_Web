using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Retegan_Alexandru_Proiect_App_Web.Data;
using Retegan_Alexandru_Proiect_App_Web.Models;

namespace Retegan_Alexandru_Proiect_App_Web.Pages.Orders
{
    public class CreateModel : CarPacksPageModel
    {
        private readonly Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext _context;

        public CreateModel(Retegan_Alexandru_Proiect_App_Web.Data.Retegan_Alexandru_Proiect_App_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FuelID"] = new SelectList(_context.Set<Fuel>(), "ID", "Type");

            var order = new Order(); 
            order.CarPacks = new List<CarPack>();
            PopulateAssignedPackData(_context, order);


            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedPacks)
        {
            var newOrder = new Order(); if (selectedPacks != null)
            {
                newOrder.CarPacks = new List<CarPack>(); 
                foreach (var cat in selectedPacks)
                {
                    var catToAdd = new CarPack
                    {
                        PackID = int.Parse(cat)
                    }; 
                    newOrder.CarPacks.Add(catToAdd);
                }
            }

         
            if (await TryUpdateModelAsync<Order>(newOrder, "Order", i => i.Buyer, i => i.Brand, i => i.Model, i => i.Color, i => i.FuelID, i => i.Price, i => i.DeliveryDate)) 
            { _context.Order.Add(newOrder); 
                await _context.SaveChangesAsync(); 
                return RedirectToPage("./Index"); }

            
            PopulateAssignedPackData(_context, newOrder); return Page();
        }
    }
}
