using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Padarogga.Server.Services;
using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteTypesController : ControllerBase
    {

        private readonly ILogger<RouteTypesController> logger;
        private readonly IRouteTypeService routeTypeService;

        public RouteTypesController(ILogger<RouteTypesController> logger, IRouteTypeService routeTypeService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.routeTypeService = routeTypeService ?? throw new ArgumentNullException(nameof(routeTypeService));
        }

        [HttpGet]
        public async Task<IEnumerable<RouteTypeDto>> Get()
        {
            return await routeTypeService.GetAsync();
        }
    }
}
