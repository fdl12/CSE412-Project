﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentSystem.Models;

namespace InventoryManagmentSystem.Pages.Order
{
    public class DetailsModel : PageModel
    {
        private readonly InventoryManagmentSystem.Models.WorkContext _context;

        public DetailsModel(InventoryManagmentSystem.Models.WorkContext context)
        {
            _context = context;
        }

        public Models.Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}
