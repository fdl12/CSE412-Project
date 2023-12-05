using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentSystem.Models;

namespace InventoryManagmentSystem.Pages.Inventory
{
    public class EditModel : PageModel
    {
        private readonly InventoryManagmentSystem.Models.WorkContext _context;

        public EditModel(InventoryManagmentSystem.Models.WorkContext context)
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
            Inventory = inventory;
           ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
           ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
           ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists($"{Inventory.WarehouseId},{Inventory.ProductId},{Inventory.SupplierId}"))
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

        private bool InventoryExists(string? id)
        {
            var entries = id.Split(",");
            var warehouse = int.Parse(entries[0]);
            var product = int.Parse(entries[1]);
            var supplier = int.Parse(entries[2]);
            return (_context.Inventories?.Any(m => m.WarehouseId == warehouse && m.SupplierId == supplier && m.ProductId == product)).GetValueOrDefault();
        }
    }
}
