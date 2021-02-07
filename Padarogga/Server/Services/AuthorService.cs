using Microsoft.EntityFrameworkCore;
using Padarogga.Server.Data;
using Padarogga.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly PadaroggaContext context;

        public AuthorService(PadaroggaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Author> GetByUserId(string userId)
        {
            var author = await context.Authors.FirstOrDefaultAsync(x => x.UserId == userId);
            if (author==null)
            {
                author = new Author()
                {
                    UserId = userId,
                    FirstName = "author1",
                    DateOfBirth = new DateTime(1980,1,1),
                };
                context.Authors.Add(author);
                await context.SaveChangesAsync();
            }
            return author;
        }
    }
}
