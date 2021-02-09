using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Padarogga.Server.Data;
using Padarogga.Server.Models;
using Padarogga.Server.Services;
using Mapster;
using Padarogga.Shared;

namespace Padarogga.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PadaroggaContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    o => o.UseNetTopologySuite()));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PadaroggaContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, PadaroggaContext>();

            services.AddHttpContextAccessor();

            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPaymentService, PaymentService>();

            TypeAdapterConfig<Route, AuthorRoute>.NewConfig()
                           .Map(dest => dest.CategoryName, src => src.Category.Name)
                           .Map(dest => dest.Rating, src => src.Ratings.Average(x => x.Rating))
                           .Map(dest => dest.Waypoints, src => src.Waypoints.Count())
                           .Map(dest => dest.Comments, src => src.Comments.Count())
                           .Map(dest => dest.Favorites, src => src.Favorites.Count())
                           .Map(dest => dest.Payments, src => src.Payments.Sum(x => x.Amount));

            TypeAdapterConfig<Comment, CommentDto>.NewConfig()
                        .Map(dest => dest.CustomerName, src => src.Customer.FirstName + " " + src.Customer.LastName);
                    

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
