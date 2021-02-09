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
    public class CommentService : ICommentService
    {
        private readonly PadaroggaContext context;

        public CommentService(PadaroggaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Comment> AddAsync(AddCommentModel model)
        {
            var comment = model.Adapt<Comment>();
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment;
        }


        public async Task<List<CommentDto>> GetByAuthor(Guid authorId)
        {
            var comments = await context.Comments
                                .Where(x => x.Route.AuthorId == authorId)
                                .ProjectToType<CommentDto>()
                                .ToListAsync();

            return comments;
        }

        public async Task<List<CommentDto>> GetByRoute(Guid routeId)
        {
            var comments = await context.Comments
                                .Where(x => x.RouteId == routeId)
                                .ProjectToType<CommentDto>()
                                .ToListAsync();

            return comments;
        }
    }
}
