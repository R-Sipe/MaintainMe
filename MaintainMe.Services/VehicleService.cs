using MaintainMe.Data;
using MaintainMe.Models.VehicleModel;
using MaintainMeMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintainMe.Services
{
    public class VehicleService
    {
        public bool CreateVehicle(VehicleCreate create)
        {
            var entity =
                new Vehicle()
                {
                    Make = create.Make,
                    Model = create.Model,
                    Year = create.Year,
                    Type = create.Type
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vehicles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VehicleListItem> GetVehicles()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vehicles
                        .Select(
                        e =>
                        new VehicleListItem
                        {
                            Id = e.Id,
                            Make = e.Make,
                            Model = e.Model,
                            Year = e.Year
                        });
                return query.ToArray(); 
            }
        }

        public VehicleDetail GetVehicleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Vehicles
                    .Single(e => e.Id == id);
                return
                    new VehicleDetail
                    {
                        Id = entity.Id,
                        Make = entity.Make,
                        Model = entity.Model,
                        Year = entity.Year,
                        Type = entity.Type
                    };
            }
        }

        public bool UpdateVehicle(VehicleEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Vehicles
                    .Single(e => e.Id == edit.Id);

                entity.Make = edit.Make;
                entity.Model = edit.Model;
                entity.Year = edit.Year;
                entity.Type = edit.Type;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVehicle(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Vehicles
                    .Single(e => e.Id == id);
                ctx.Vehicles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
