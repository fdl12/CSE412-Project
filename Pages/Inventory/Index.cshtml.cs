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
    public class IndexModel : PageModel
    {
        private readonly InventoryManagmentSystem.Models.WorkContext _context;

        public IndexModel(InventoryManagmentSystem.Models.WorkContext context)
        {
            _context = context;
        }

        public IList<Models.Inventory> Inventory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inventories != null)
            {
                Inventory = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.Supplier)
                .Include(i => i.Warehouse).ToListAsync();
            }
        }
    }
}
