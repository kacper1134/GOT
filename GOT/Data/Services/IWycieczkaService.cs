using GOT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Data.Services
{
    public interface IWycieczkaService
    {
        Task<IEnumerable<Wycieczka>> GetAll();

        Task<Wycieczka> GetById(int id);

        Task<int> GetCount();

        Task<IEnumerable<Wycieczka>> GetByPageNumer(int pageNumber, int pageSize);

        void ChangeFilterAndOrderOptions(int filterOption, int orderOption);

        Task<(int, int, int)> GetPageNumbers(int currentPageNumber, int pageSize);

        Task<List<String>> GetTitlesForAll();

        Task<String> GetTitleById(int id);

        Task<List<String>> GetTitlesByPageNumber(int pageNumber, int pageSize);

        Task<String> GetTimeById(int id);

        Task<List<String>> GetTimeByPageNumber(int pageNumber, int pageSize);

        Task<List<String>> GetTimeForAll();

        Task<int> GetPointsById(int id);

        Task<List<Odcinek>> GetSegmentsById(int id);

        Task<List<Odcinek>> GetSegmentsByRouteId(int id);

        Task DeleteById(int id);

        Task Create(DateTime startDate, int tripDuration, int routeNumber);

        Task Update(int tripNumber, DateTime startDate, int tripDuration, int routeNumber);

        Task<bool> CheckTime(DateTime startDate, int tripDuration);

        Task<ICollection<PunktGeograficzny>> GetPointsForTrip(int tripNumber);

        Task<ICollection<Odcinek>> GetRoutesForTrip(int tripNumber);

        Task<ICollection<Tuple<int, string, string>>> GetAllRoutes();
    }
}
