using Padarogga.Server.Models;
using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface IRouteService
    {
        Task<Route> AddAsync(Guid authorId, AddRouteModel model);
        Task<List<RouteDto>> GetByAuthorAsync(Guid authorId);
    }
}