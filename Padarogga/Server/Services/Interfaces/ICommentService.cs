using Padarogga.Server.Models;
using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public interface ICommentService
    {
        Task<Comment> AddAsync(AddCommentModel model);
        Task<List<CommentDto>> GetByAuthor(Guid authorId);
        Task<List<CommentDto>> GetByRoute(Guid routeId);
    }
}