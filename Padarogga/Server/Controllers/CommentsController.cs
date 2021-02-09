using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Padarogga.Server.Services;

namespace Padarogga.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IAuthorService authorService;

        public CommentsController(ICommentService commentService, IAuthorService authorService)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            this.authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        string userId = "df9d86e4-3dad-40e1-8986-00bda7847b4f";

        [HttpGet("/api/routes/{routeId}/comments")]
        public async Task<ActionResult> Get()
        {
            var author = await authorService.GetByUserId(userId);
            var comments = await commentService.GetByAuthor(author.Id);
            return Ok(comments);
        }
    }
}
