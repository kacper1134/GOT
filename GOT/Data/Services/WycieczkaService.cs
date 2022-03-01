using GOT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Data.Services
{
    public class WycieczkaService : IWycieczkaService
    {
        private readonly MyDbContext _context;

        private int filterOption = 13;
        private int orderOption = 1;

        public WycieczkaService(MyDbContext context)
        {
            _context = context;
        }

        public void ChangeFilterAndOrderOptions(int filterOption, int orderOption)
        {
            this.filterOption = filterOption;
            this.orderOption = orderOption;
        }

        public async Task<IEnumerable<Wycieczka>> GetAll()
        {
            return OrderData(await FilterData());
        }

        public async Task<Wycieczka> GetById(int id)
        {
            return await _context.Wycieczka.Where(w => w.Numer == id).FirstAsync();
        }

        public async Task<IEnumerable<Wycieczka>> GetByPageNumer(int pageNumber, int pageSize)
        {
            var trips = await GetAll();
            var result = new List<Wycieczka>();

            int index = pageSize;

            foreach (var trip in trips)
            {
                if (index / pageSize == pageNumber)
                {
                    result.Add(trip);
                }
                else if (index / pageSize > pageNumber)
                {
                    return result;
                }

                index += 1;
            }

            return result;
        }

        public async Task<int> GetCount()
        {
            var data = await GetAll();

            return data.Count();
        }

        public async Task<(int, int, int)> GetPageNumbers(int currentPageNumber, int pageSize)
        {
            int countApplication = await GetCount();

            int maxPageNumber = Math.Max(1, (int)Math.Ceiling(countApplication / (float)pageSize));
            var pageNumber = Math.Max(1, Math.Max(Math.Min(currentPageNumber, maxPageNumber - 2), 1));
            int nextPageNumber = Math.Max(1, Math.Min(pageNumber + 1, maxPageNumber));

            return (pageNumber, nextPageNumber, maxPageNumber);
        }

        public async Task<List<string>> GetTitlesForAll()
        {
            var listOfTitles = new List<string>();
            var trips = await GetAll();

            foreach (var trip in trips)
            {
                listOfTitles.Add(await GetRouteForTrip(trip.Numer));
            }

            return listOfTitles;
        }

        public async Task<string> GetTitleById(int id)
        {
            return await GetRouteForTrip(id);
        }

        public async Task<List<string>> GetTitlesByPageNumber(int pageNumber, int pageSize)
        {
            var titlesList = await GetTitlesForAll();
            var result = new List<string>();

            int index = pageSize;

            foreach (var item in titlesList)
            {
                if (index / pageSize == pageNumber)
                {
                    result.Add(item);
                }
                else if (index / pageSize > pageNumber)
                {
                    return result;
                }

                index += 1;
            }

            return result;
        }

        public async Task<List<String>> GetTimeForAll()
        {
            var listOfTimes = new List<string>();
            var trips = await GetAll();

            foreach (var trip in trips)
            {
                listOfTimes.Add(await GetTimeForTrip(trip.Numer));
            }

            return listOfTimes;
        }

        public async Task<List<string>> GetTimeByPageNumber(int pageNumber, int pageSize)
        {
            var titlesList = await GetTimeForAll();
            var result = new List<string>();

            int index = pageSize;

            foreach (var item in titlesList)
            {
                if (index / pageSize == pageNumber)
                {
                    result.Add(item);
                }
                else if (index / pageSize > pageNumber)
                {
                    return result;
                }

                index += 1;
            }

            return result;
        }

        public async Task<string> GetTimeById(int id)
        {
            return await GetTimeForTrip(id);
        }

        public async Task<int> GetPointsById(int id)
        {
            return await _context.Wycieczka.Where(w => w.Numer == id).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).SumAsync(o => o.Punkty);
        }

        public async Task<List<Odcinek>> GetSegmentsById(int id)
        {
            return await _context.Wycieczka.Where(w => w.Numer == id).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).Include(o => o.Punkt_Poczatkowy).Include(o => o.Punkt_Koncowy).ToListAsync();
        }

        public async Task<List<Odcinek>> GetSegmentsByRouteId(int id)
        {
            return await _context.Trasa.Where(w => w.Numer == id).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).Include(o => o.Punkt_Poczatkowy).Include(o => o.Punkt_Koncowy).ToListAsync();
        }

        public async Task DeleteById(int id)
        {
            var trip = await GetById(id);
            _context.Wycieczka.Remove(trip);
            await _context.SaveChangesAsync();
        }

        public async Task Create(DateTime startDate, int tripDuration, int routeNumber)
        {
            DateTime start = startDate;
            DateTime end = startDate.AddDays(tripDuration - 1);

            var trip = new Wycieczka
            {
                Numer_Trasy = routeNumber,
                Data_Zgloszenia = start
            };

            await _context.Wycieczka.AddAsync(trip);
            await _context.SaveChangesAsync();

            await CreateEntry(end);
            await CreateVerification();
        }

        public async Task Update(int tripNumber, DateTime startDate, int tripDuration, int routeNumber)
        {
            DateTime end = startDate.AddDays(tripDuration - 1);

            var trip = await GetById(tripNumber);

            trip.Numer_Trasy = routeNumber;
            trip.Data_Zgloszenia = startDate;

            var entry = _context.Wpis.Where(w => w.Numer_Wycieczki == tripNumber).First();

            entry.Data_Ukonczenia_Wycieczki = end;

            _context.Update(trip);
            _context.Update(entry);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckTime(DateTime startDate, int tripDuration)
        {
            DateTime end = startDate.AddDays(tripDuration - 1);

            foreach(var trip in await GetAll())
            {
                if(trip.Data_Zgloszenia >= startDate && trip.Data_Zgloszenia <= end || trip.Wpis.First().Data_Ukonczenia_Wycieczki >= startDate && trip.Wpis.First().Data_Ukonczenia_Wycieczki <= end)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<ICollection<PunktGeograficzny>> GetPointsForTrip(int tripNumber)
        {
            var punktyPoczatkowe = _context.Wycieczka.Where(w => w.Numer == tripNumber).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).Select(o => o.Punkt_Poczatkowy);
            var punktyKoncowe = _context.Wycieczka.Where(w => w.Numer == tripNumber).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).Select(o => o.Punkt_Koncowy);

            var punkty = await punktyPoczatkowe.Concat(punktyKoncowe).ToListAsync();

            return punkty;
        }

        public async Task<ICollection<Odcinek>> GetRoutesForTrip(int tripNumber)
        {
            return await _context.Wycieczka.Where(w => w.Numer == tripNumber).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).ToListAsync();
        }

        public async Task<ICollection<Tuple<int, string, string>>> GetAllRoutes()
        {
            return await _context.Trasa.Select(t => new Tuple<int,string,string>(t.Numer, t.OdcinekTrasy.First().Odcinek.Punkt_Poczatkowy.Nazwa, t.OdcinekTrasy.OrderBy(o => o.Numer_Odcinka_Trasy).Last().Odcinek.Punkt_Koncowy.Nazwa)).ToListAsync();
        }

        private async Task CreateEntry(DateTime end)
        {
            var entry = new Wpis
            {
                Numer_Ksiazecki = 2,
                Numer_Wycieczki = _context.Wycieczka.OrderBy(w => w.Numer).Last().Numer,
                Data_Ukonczenia_Wycieczki = end
            };

            await _context.Wpis.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        private async Task CreateVerification()
        {
            var verification = new Weryfikacja
            {
                Numer_Wpisu = _context.Wpis.OrderBy(w => w.Numer).Last().Numer,
                Login_Przodownika = "kacper1134",
                Data_Weryfikacji = DateTime.Today,
                Uzasadnienie = "",
                Status = Models.Enums.Status.Weryfikowany
            };

            await _context.Weryfikacja.AddAsync(verification);
            await _context.SaveChangesAsync();
        }

        private async Task<String> GetTimeForTrip(int tripNumber)
        {
            var startTime = await _context.Wycieczka.Where(w => w.Numer == tripNumber).Select(w => w.Data_Zgloszenia).FirstAsync();
            var endTime = await _context.Wycieczka.Where(w => w.Numer == tripNumber).Select(w => w.Wpis.First()).Select(w => w.Data_Ukonczenia_Wycieczki).FirstAsync();
            return startTime.ToString("d MMMM yyyy") + " - " + endTime.ToString("d MMMM yyyy");
        }

        private async Task<string> GetRouteForTrip(int tripNumber)
        {
            var sections = _context.Wycieczka.Where(w => w.Numer == tripNumber).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).OrderBy(o => o.Numer);
            return await sections.Select(o => o.Punkt_Poczatkowy.Nazwa).FirstAsync() + " - " + await sections.Select(o => o.Punkt_Koncowy.Nazwa).LastAsync();
        }

        private async Task<IEnumerable<Wycieczka>> FilterData()
        {
            if (filterOption == 13) return await _context.Wycieczka.Include(w => w.Wpis).ToListAsync();
            else return await _context.Wycieczka.Where(w => w.Data_Zgloszenia.Month == filterOption).Include(w => w.Wpis).ToListAsync();
        }

        private IEnumerable<Wycieczka> OrderData(IEnumerable<Wycieczka> data)
        {
            if (orderOption == 1) return data.OrderByDescending(w => w.Data_Zgloszenia);
            else return data.OrderBy(w => w.Data_Zgloszenia);
        }
    }
}
