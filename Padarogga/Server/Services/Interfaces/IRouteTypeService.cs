using Padarogga.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface IRouteTypeService
    {
        Task<List<RouteTypeDto>> GetAsync();
    }
}