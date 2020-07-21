using BetterDo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterDo.Data
{
    public class BetterDoDbContext : DbContext
    {
        public BetterDoDbContext()
        {

        }

        public BetterDoDbContext(DbContextOptions<BetterDoDbContext> options) : base(options) { }

        public virtual DbSet<TodoItem> TodoItems { get; set; }

        public virtual async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return await TodoItems
                .OrderBy(item => item.Title)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Initialize()
        {
            TodoItems.AddRange(GetSeedingTodoItems());
            SaveChanges();
        }

        public static List<TodoItem> GetSeedingTodoItems()
        {
            return new List<TodoItem>()
            {
                new TodoItem(){ Title = "You're standing on my scarf." },
                new TodoItem(){ Title = "Would you like a jelly baby?" },
                new TodoItem(){ Title = "To the rational mind, nothing is inexplicable; only unexplained." }
            };
        }
    }
}
