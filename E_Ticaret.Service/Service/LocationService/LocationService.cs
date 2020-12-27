using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.Service.Service.LocationService
{
    public class LocationService : BaseService<Location> , ILocationService
    {
        private readonly DataContext _db;
        public LocationService(DataContext db)
           : base(db)
        {
            _db = db;
        }

        public async Task<List<LocationSp>> GetSpecial()
        {
            var result = from l in _db.Set<Location>() 
                         join c in _db.Set<Country>() on l.CountryId equals c.Id
                         join r in _db.Set<Region>() on l.RegionId equals r.Id
                         select new LocationSp { 
                             Id = l.Id, Name = l.Name, CountryId = c.Id, CountryName = c.Name, RegionId = r.Id, RegionName = r.Name 
                         };
            return await result.ToListAsync();
        }
    }
}
