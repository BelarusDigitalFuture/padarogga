using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Padarogga.Server.Services;
using Padarogga.Shared;

namespace Padarogga.Server.Controllers
{
    [Authorize]
    [Route("routes")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> logger;
        private readonly IRouteService routeService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAuthorService authorService;

        public RoutesController(ILogger<RoutesController> logger,
            IRouteService routeService,
            IHttpContextAccessor httpContextAccessor,
            IAuthorService authorService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.routeService = routeService ?? throw new ArgumentNullException(nameof(routeService));
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            this.authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddRouteModel model)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            //TODO get user Id
            //var userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var author = await authorService.GetByUserId("df9d86e4-3dad-40e1-8986-00bda7847b4f");
            var route = routeService.AddAsync(author.Id, model);
            return Ok(route.Id);
        }
    }
}
