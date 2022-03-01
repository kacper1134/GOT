using GOT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Data.Services
{
    public class MapService: IMapService
    {
        private MyDbContext _dbContext;


        public MapService(MyDbContext context)
        {
            _dbContext = context;
        }

        public async Task<ICollection<PunktGeograficzny>> getAllPoints()
        {
            return await _dbContext.PunktGeograficzny.Select(pG => pG).ToListAsync();
        }

        public async Task<ICollection<Odcinek>> getAllRoutes()
        {
            return await _dbContext.Odcinek.Select(o => o).ToListAsync();
        }

        public  Odcinek GetRouteByIdentifier(int routeIdentifier)
        {
            return _dbContext.Odcinek.Include(o => o.Punkt_Poczatkowy).Include(o => o.Punkt_Koncowy).First(o => o.Numer == routeIdentifier);
        }

        public int GetPointNumber(string name)
        {
            return _dbContext.PunktGeograficzny
                .Where(p => p.Nazwa == name)
                .Select(p => p.Numer)
                .FirstOrDefault();
        }

        public bool RouteExists(string beginning, string ending)
        {
            return _dbContext.Odcinek
                .Include(o => o.Punkt_Poczatkowy)
                .Include(o => o.Punkt_Koncowy)
                .Where(o => o.Punkt_Poczatkowy.Nazwa == beginning && o.Punkt_Koncowy.Nazwa == ending || (o.Punkt_Koncowy.Nazwa == beginning && o.Punkt_Poczatkowy.Nazwa == ending))
                .Any();
        }

        public int GetRouteNumber(string beginning, string ending)
        {
            return _dbContext.Odcinek
                .Include(o => o.Punkt_Poczatkowy)
                .Include(o => o.Punkt_Koncowy)
                .Where(o => o.Punkt_Poczatkowy.Nazwa == beginning && o.Punkt_Koncowy.Nazwa == ending || (o.Punkt_Koncowy.Nazwa == beginning && o.Punkt_Poczatkowy.Nazwa == ending))
                .Select(o => o.Numer)
                .FirstOrDefault();
        }

        public Odcinek GetRoute(string beginning, string ending)
        {
            return _dbContext.Odcinek
                .Include(o => o.Punkt_Poczatkowy)
                .Include(o => o.Punkt_Koncowy)
                .Where(o => o.Punkt_Poczatkowy.Nazwa == beginning && o.Punkt_Koncowy.Nazwa == ending || (o.Punkt_Koncowy.Nazwa == beginning && o.Punkt_Poczatkowy.Nazwa == ending))
                .First();
        }

        public async Task<Odcinek> CreateRoute(Odcinek odcinek)
        {
            _dbContext.Add(odcinek);
            await _dbContext.SaveChangesAsync();

            return odcinek;
        }

        public async Task<bool> UpdateRoute(Odcinek odcinek)
        {
            _dbContext.Update(odcinek);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRoute(int routeIdentifier)
        {
            _dbContext.Odcinek.Remove(GetRouteByIdentifier(routeIdentifier));
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
