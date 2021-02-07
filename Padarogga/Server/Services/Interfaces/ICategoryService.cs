using Padarogga.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAsync();
    }
}