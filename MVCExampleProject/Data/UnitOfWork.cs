using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        //change me todocontext
        private readonly TodoContext _context;

        public ITodoRepository Todos { get; private set; }

        // change me to todocontext
        public UnitOfWork(TodoContext context)
        {
            _context = context;
            Todos = new TodoRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
