using Padarogga.Server.Models;
using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface ICommentService
    {
        Task<Comment> AddRouteCommentAsync(AddRouteCommentModel model);
        Task<List<RouteCommentDto>> GetRouteCommentsByCustomer(Guid authorId);
        Task<List<RouteCommentDto>> GetByRoute(Guid routeId);
    }
}