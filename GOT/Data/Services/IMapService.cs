using GOT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOT.Data.Services
{
    public interface IMapService
    {
        public Task<ICollection<PunktGeograficzny>> getAllPoints();

        public Task<ICollection<Odcinek>> getAllRoutes();

        public int GetPointNumber(string name);

        public bool RouteExists(string beginning, string ending);

        public int GetRouteNumber(string beginning, string ending);

        public Odcinek GetRoute(string beginning, string ending);

        public Task<Odcinek> CreateRoute(Odcinek odcinek);

        public Task<bool> UpdateRoute(Odcinek odcinek);

        public Task<bool> DeleteRoute(int routeIdentifier);

        public Odcinek GetRouteByIdentifier(int routeIdentifier);
    }
}
