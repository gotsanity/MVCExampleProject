using System;
using System.Collections.Generic;
using System.Linq;
using MVCExampleProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MVCExampleProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoContext>
                    >()
                    )
                )
            {
                // are we already populated?
                if (context.Todos.Any())
                {
                    return;
                }

                if (context.Comments.Any())
                {
                    return;
                }

                List<TodoItem> todoItems = new List<TodoItem> {
                    new TodoItem
                    {
                        Description = "Grab Milk",
                        CompletedDate = DateTime.Now,
                    },
                    new TodoItem
                    {
                        Description = "Pickup kids",
                        CompletedDate = DateTime.Now
                    },
                    new TodoItem
                    {
                        Description = "Goto Bank",
                        CompletedDate = DateTime.Now
                    }
                };

                context.Todos.AddRange(todoItems);

                context.SaveChanges();

                foreach (TodoItem item in todoItems)
                {
                    context.Comments.Add(new Comment { Message = "Test Message", TodoItem = item });
                }

                context.SaveChanges();
            }
        }
    }
}
