using Padarogga.Server.Models;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface IAuthorService
    {
        Task<Author> GetByUserId(string userId);
    }
}