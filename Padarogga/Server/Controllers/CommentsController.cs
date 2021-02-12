using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Padarogga.Server.Services;
using Padarogga.Shared;

namespace Padarogga.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly ICustomerService authorService;

        public CommentsController(ICommentService commentService, ICustomerService authorService)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            this.authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        string userId = "df9d86e4-3dad-40e1-8986-00bda7847b4f";

        /// <summary>
        /// Get comments by route
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/routes/{routeId}/comments")]
        public async Task<ActionResult> GetByRoute()
        {
            //TODO get userId by context
            var author = await authorService.GetByUserId(userId);
            var comments = await commentService.GetRouteCommentsByCustomer(author.Id);
            return Ok(comments);
        }

        /// <summary>
        /// Add route comment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/routes/{routeId}/comments")]
        public async Task<ActionResult> Add(AddRouteCommentModel model)
        {             
            var comment = await commentService.AddRouteCommentAsync(model);
            return Ok(comment);
        }
    }
}
