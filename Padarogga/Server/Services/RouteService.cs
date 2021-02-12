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
    public class RouteService : IRouteService
    {
        private readonly PadaroggaContext context;

        public RouteService(PadaroggaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Route> AddAsync(Guid authorId, AddRouteModel model)
        {
            TimeSpan duration = new TimeSpan();
            switch (model.DurationPeriod)
            {
                case DurationPeriod.Hours:
                    duration = TimeSpan.FromHours(model.Duration);
                    break;
                case DurationPeriod.Days:
                    duration = TimeSpan.FromDays(model.Duration);
                    break;
                case DurationPeriod.Month:
                    duration = TimeSpan.FromDays(model.Duration * 30);
                    break;
                default:
                    break;
            }

            var route = new Route()
            {
                CusomerId = authorId,
                Name = model.Name,
                TypeId = 1,//TODO get categoryId
                Difficulty = model.Difficulty,
                Duration = duration,
                Description = model.Description,
                Waypoints = new List<RouteWaypoints>()
            };

            foreach (var addWaypointModel in model.Waypoints)
            {
                var waypoint = addWaypointModel.Adapt<Waypoint>();
                waypoint.Location = new NetTopologySuite.Geometries.Point(addWaypointModel.Latitude, addWaypointModel.Longitude);

                route.Waypoints.Add(new RouteWaypoints()
                {
                    Waypoint = waypoint                  
                });
            }

            context.Routes.Add(route);
            await context.SaveChangesAsync();
            return route;
        }

        public async Task<List<RouteDto>> GetByAuthorAsync(Guid authorId)
        {
            return await context.Routes
                .Where(x => x.CusomerId == authorId)
                .OrderByDescending(x => x.CreatedAt)
                .ProjectToType<RouteDto>()
                .ToListAsync();
        }


    }
}
