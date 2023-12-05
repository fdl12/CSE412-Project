using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentSystem.Models;

namespace InventoryManagmentSystem.Pages.Inventory
{
    public class DeleteModel : PageModel
    {
        private readonly InventoryManagmentSystem.Models.WorkContext _context;

        public DeleteModel(InventoryManagmentSystem.Models.WorkContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Inventory Inventory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }
             var entries = id.Split(",");
            var warehouse = int.Parse(entries[0]);
            var product = int.Parse(entries[1]);
            var supplier = int.Parse(entries[2]);
            var inventory = await _context.Inventories.FirstOrDefaultAsync(m => m.WarehouseId == warehouse && m.SupplierId == supplier && m.ProductId == product);


            if (inventory == null)
            {
                return NotFound();
            }
            else 
            {
                Inventory = inventory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }
            var entries = id.Split(",");
            var warehouse = int.Parse(entries[0]);
            var product = int.Parse(entries[1]);
            var supplier = int.Parse(entries[2]);
            var inventory = await _context.Inventories.FirstOrDefaultAsync(m => m.WarehouseId == warehouse && m.SupplierId == supplier && m.ProductId == product);

            if (inventory != null)
            {
                Inventory = inventory;
                _context.Inventories.Remove(Inventory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
