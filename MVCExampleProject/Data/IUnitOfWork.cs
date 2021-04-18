using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Data
{
    public interface IUnitOfWork
    {
        ITodoRepository Todos { get; }
        int Complete();
    }
}
