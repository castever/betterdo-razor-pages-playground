using BetterDo.Areas.TodoItems.Pages;
using BetterDo.Data;
using BetterDo.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BetterDo.Tests.Areas.TodoItems
{
    public class IndexPageTests
    {
        [Fact]
        public async Task OnGetAsync_PopulatesThePageModel_WithAListOfTodoItems()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<BetterDoDbContext>()
                .UseInMemoryDatabase("InMemoryDb");
            #region snippet1
            var mockAppDbContext = new Mock<BetterDoDbContext>(optionsBuilder.Options);
            var expectedMessages = BetterDoDbContext.GetSeedingTodoItems();
            mockAppDbContext.Setup(
                db => db.GetTodoItemsAsync()).Returns(Task.FromResult(expectedMessages));
            var pageModel = new IndexModel(mockAppDbContext.Object);
            #endregion

            #region snippet2
            // Act
            await pageModel.OnGetAsync();
            #endregion

            #region snippet3
            // Assert
            var actualMessages = Assert.IsAssignableFrom<List<TodoItem>>(pageModel.TodoItems);
            Assert.Equal(
                expectedMessages.OrderBy(m => m.ID).Select(m => m.Title),
                actualMessages.OrderBy(m => m.ID).Select(m => m.Title));
            #endregion
        }
    }
}
