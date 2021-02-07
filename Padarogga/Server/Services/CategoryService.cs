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
    public class CategoryService : ICategoryService
    {
        private readonly PadaroggaContext context;

        public CategoryService(PadaroggaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<CategoryDto>> GetAsync()
        {
            var categories = await context.Categories
                .ProjectToType<CategoryDto>()
                .ToListAsync();

            //TODO remove
            if (categories.Count == 0)
            {
                context.Categories.Add(new Category()
                {
                    Name = "Туристический"
                });
                await context.SaveChangesAsync();

                return await context.Categories
                .ProjectToType<CategoryDto>()
                .ToListAsync();
            }
            //

            return categories;
        }
    }
}
