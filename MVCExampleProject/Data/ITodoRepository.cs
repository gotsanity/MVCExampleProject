using MVCExampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Data
{
    public interface ITodoRepository : IRepository<TodoItem>
    {
        IEnumerable<TodoItem> Take(int num);
        IEnumerable<TodoItem> GetAllWithComments();
    }
}
