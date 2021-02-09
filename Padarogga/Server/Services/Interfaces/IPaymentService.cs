using Padarogga.Server.Models;
using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface IPaymentService
    {
        Task<List<RoutePaymentDto>> GetByAuthorAsync(Guid authorId);
        Task<RoutePayment> AddAsync(AddPaymentModel model);
        Task<List<RoutePaymentDto>> GetByCustomerAsync(Guid customerId);
    }
}