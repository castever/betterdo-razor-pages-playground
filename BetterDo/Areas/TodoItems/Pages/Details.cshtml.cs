using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetterDo.Data;
using BetterDo.Models;

namespace BetterDo.Areas.TodoItems.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly BetterDo.Data.BetterDoDbContext _context;

        public DetailsModel(BetterDo.Data.BetterDoDbContext context)
        {
            _context = context;
        }

        public TodoItem TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TodoItem = await _context.TodoItems.FirstOrDefaultAsync(m => m.ID == id);

            if (TodoItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
