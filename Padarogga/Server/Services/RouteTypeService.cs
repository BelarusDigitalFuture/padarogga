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
    public class RouteTypeService : IRouteTypeService
    {
        private readonly PadaroggaContext context;

        public RouteTypeService(PadaroggaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<RouteTypeDto>> GetAsync()
        {
            var routeTypes = await context.RouteTypes
                .ProjectToType<RouteTypeDto>()
                .ToListAsync();          

            return routeTypes;
        }
    }
}
