using Microsoft.EntityFrameworkCore;
using MVCExampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Data
{
    public class TodoRepository : Repository<TodoItem>, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context)
        {
        }

        public IEnumerable<TodoItem> Take(int num)
        {
            return AppContext.Todos.Take(num);
        }

        public IEnumerable<TodoItem> GetAllWithComments()
        {
            return AppContext.Todos.Include(c => c.Comments);
        }

        private TodoContext AppContext
        {
            get { return Context as TodoContext; }
        }
    }
}
