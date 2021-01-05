using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Retegan_Alexandru_Proiect_App_Web.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Retegan_Alexandru_Proiect_App_Web.Models
{
    public class CarPacksPageModel : PageModel
    {
        public List<AssignedPackData> AssignedPackDataList;
        public void PopulateAssignedPackData(Retegan_Alexandru_Proiect_App_WebContext context, Order order)
        {
            var allPacks = context.Pack; 
            var carPacks = new HashSet<int>(order.CarPacks.Select(c => c.OrderID)); 
            AssignedPackDataList = new List<AssignedPackData>(); 
            foreach (var cat in allPacks)
            {
                AssignedPackDataList.Add(new AssignedPackData 
                { 
                    PackID = cat.ID, 
                    Name = cat.PackName,
                    Assigned = carPacks.Contains(cat.ID)
                });
            }
        }
        public void UpdateCarPacks(Retegan_Alexandru_Proiect_App_WebContext context, string[] selectedPacks, Order orderToUpdate)
        {
            if (selectedPacks == null) { orderToUpdate.CarPacks = new List<CarPack>(); return; }

            var selectedPacksHS = new HashSet<string>(selectedPacks);
            var carPacks = new HashSet<int>(orderToUpdate.CarPacks.Select(c => c.Pack.ID));
            foreach (var cat in context.Pack)
            { if (selectedPacksHS.Contains(cat.ID.ToString()))
                { if (!carPacks.Contains(cat.ID))
                    { orderToUpdate.CarPacks.Add(new CarPack
                    { OrderID = orderToUpdate.ID, PackID = cat.ID });
                    }
                } else
                { if (carPacks.Contains(cat.ID))
                    { CarPack courseToRemove = orderToUpdate.CarPacks.SingleOrDefault(i => i.PackID == cat.ID);
                        context.Remove(courseToRemove); } } }
        } 
    }
    }
