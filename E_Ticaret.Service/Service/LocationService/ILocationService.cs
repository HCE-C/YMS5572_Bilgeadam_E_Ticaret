using E_Ticaret.Core.Service;
using E_Ticaret.Model.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Ticaret.Service.Service.LocationService
{
    public interface ILocationService : ICoreService<Location>
    {
        Task<List<LocationSp>> GetSpecial();
    }
}
