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
    public class CustomerService : ICustomerService
    {
        private readonly PadaroggaContext context;

        public CustomerService(PadaroggaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> AddAsync(AddCustomerModel model)
        {
            var customer = model.Adapt<Customer>();
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetByUserId(string userId)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x => x.UserId == userId);            
            return customer;
        }
    }
}
