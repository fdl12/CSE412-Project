using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentSystem.Models;

namespace InventoryManagmentSystem.Pages.Supplier
{
    public class IndexModel : PageModel
    {
        private readonly InventoryManagmentSystem.Models.WorkContext _context;

        public IndexModel(InventoryManagmentSystem.Models.WorkContext context)
        {
            _context = context;
        }

        public IList<Models.Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Suppliers != null)
            {
                Supplier = await _context.Suppliers.ToListAsync();
            }
        }
    }
}
