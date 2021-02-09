using Padarogga.Server.Models;
using Padarogga.Shared;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface IAuthorService
    {
        Task<Author> AddAsync(AddAuthorModel model);
        Task<Author> GetByUserId(string userId);
    }
}