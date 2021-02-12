using Padarogga.Server.Models;
using Padarogga.Shared;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(AddCustomerModel model);
        Task<Customer> GetByUserId(string userId);
    }
}