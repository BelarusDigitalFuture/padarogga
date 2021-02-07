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
    public class CategoriesController : ControllerBase
    {

        private readonly ILogger<CategoriesController> logger;
        private readonly ICategoryService categoryService;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            return await categoryService.GetAsync();
        }
    }
}
