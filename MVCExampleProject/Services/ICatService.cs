using MVCExampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Services
{
    public interface ICatService
    {
        Task<CatResponse> GetRandomCat();
    }
}
