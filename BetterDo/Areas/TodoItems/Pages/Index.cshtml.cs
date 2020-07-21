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
    public class IndexModel : PageModel
    {
        private readonly BetterDoDbContext _context;

        public IndexModel(BetterDo.Data.BetterDoDbContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItems { get; set; }

        public async Task OnGetAsync()
        {
            TodoItems = await _context.GetTodoItemsAsync();
        }

        
    }
}
