using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentSystem.Models;

namespace InventoryManagmentSystem.Pages.Warehouse
{
    public class DetailsModel : PageModel
    {
        private readonly InventoryManagmentSystem.Models.WorkContext _context;

        public DetailsModel(InventoryManagmentSystem.Models.WorkContext context)
        {
            _context = context;
        }

      public Models.Warehouse Warehouse { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Warehouses == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (warehouse == null)
            {
                return NotFound();
            }
            else 
            {
                Warehouse = warehouse;
            }
            return Page();
        }
    }
}
