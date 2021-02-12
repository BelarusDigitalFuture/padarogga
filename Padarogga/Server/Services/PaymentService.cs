using Mapster;
using Microsoft.EntityFrameworkCore;
using Padarogga.Server.Data;
using Padarogga.Server.Models;
using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PadaroggaContext context;

        public PaymentService(PadaroggaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<RoutePayment> AddAsync(AddPaymentModel model)
        {
            var payment = model.Adapt<RoutePayment>();
            context.RoutePayments.Add(payment);
            await context.SaveChangesAsync();
            return payment;
        }

        public async Task<List<RoutePaymentDto>> GetByAuthorAsync(Guid authorId)
        {
            return await context.RoutePayments
            .Where(x => x.Route.CusomerId == authorId)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectToType<RoutePaymentDto>()
            .ToListAsync();
        }

        public async Task<List<RoutePaymentDto>> GetByCustomerAsync(Guid customerId)
        {
            return await context.RoutePayments
            .Where(x => x.CustomerId == customerId)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectToType<RoutePaymentDto>()
            .ToListAsync();
        }
    }
}
