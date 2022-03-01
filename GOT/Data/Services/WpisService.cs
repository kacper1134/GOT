using GOT.Exceptions;
using GOT.Models;
using GOT.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Data.Services
{
    public class WpisService : IWpisService
    {

        private readonly MyDbContext _dbContext;

        public WpisService(MyDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Wpis>> GetAll(FilterOption filterOption = FilterOption.None, SortingOption sortingOption = SortingOption.Newest)
        {
            return OrderData(await FilterData(filterOption), sortingOption);
        }

        public int GetCount(FilterOption filterOption = FilterOption.None)
        {
            return GetFilterQuery(filterOption).Count();
        }

        public async Task<Wpis> GetEntryByIdentifier(int entryIdentifier)
        {
            var entry = await _dbContext.Wpis.Include(w => w.Weryfikacja)
                .Include(w => w.ZdjecieWpisu)
                .Include(w => w.Wycieczka)
                .SingleAsync(w => w.Numer == entryIdentifier);

            return entry;
        }

        public async Task<IEnumerable<Odcinek>> GetTripSegmentsByEntryIdentifier(int entryIdentifier)
        {
            var result = await _dbContext.Wpis.Include(w => w.Wycieczka)
                .Where(w => w.Numer == entryIdentifier)
                .Select(w => w.Wycieczka)
                .Select(w => w.Trasa)
                .Select(t => t.OdcinekTrasy)
                .SelectMany(o => o.Select(oT => oT))
                .OrderBy(oT => oT.Numer_Odcinka_Trasy)
                .Select(oT => oT.Odcinek)
                .ToListAsync();

            foreach (var odcinek in result)
            {
                odcinek.Punkt_Poczatkowy = _dbContext.PunktGeograficzny.First(pG => pG.Numer == odcinek.Numer_Punktu_Poczatkowego);
                odcinek.Punkt_Koncowy = _dbContext.PunktGeograficzny.First(pG => pG.Numer == odcinek.Numer_Punktu_Koncowego);
            }

            return result;
        }

        public int GetNumberOfPages(int pageSize, FilterOption filterOption = FilterOption.None)
        {
            if (pageSize < 1)
            {
                throw new InvalidPageSizeException($"page size of {pageSize} is invalid!");
            }

            int numberOfEntries = GetCount(filterOption);

            return (int)Math.Ceiling(numberOfEntries / (float)pageSize);
        }

        public async Task<IEnumerable<Wpis>> GetByPageNumber(int pageNumber, int pageSize, FilterOption filterOption = FilterOption.None, SortingOption sortingOption = SortingOption.Newest)
        {
            var numberOfPages = GetNumberOfPages(pageSize, filterOption);

            if (pageNumber < 1 || pageNumber > numberOfPages)
            {
                throw new InvalidPageNumberException($"Page {pageNumber} does not exist!");
            }

            var pageContent = GetOrderedFilteredQuery(filterOption, sortingOption).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return pageContent;
        }

        public int GetPointsForEntry(int entryIdentifier)
        {
            return _dbContext.Wpis.Include(w => w.Wycieczka)
                .Where(w => w.Numer == entryIdentifier)
                .Select(w => w.Wycieczka)
                .Select(w => w.Trasa)
                .Select(t => t.OdcinekTrasy)
                .SelectMany(o => o.Select(oT => oT))
                .OrderBy(oT => oT.Numer_Odcinka_Trasy)
                .Select(oT => oT.Odcinek)
                .Sum(o => o.Punkty);
        }

        private async Task<IEnumerable<Wpis>> FilterData(FilterOption filterOption)
        {
            return GetFilterQuery(filterOption).ToList();
        }

        private IQueryable<Wpis> GetFilterQuery(FilterOption filterOption)
        {
            if (filterOption != FilterOption.None)
            {
                return _dbContext.Wpis.Include(w => w.Weryfikacja).Include(w => w.ZdjecieWpisu).Include(w => w.Wycieczka).Where(w => w.Weryfikacja.Status == GetStatusFromFilterOption(filterOption));
            }
            else
            {
                return _dbContext.Wpis.Include(w => w.Weryfikacja).Include(w => w.ZdjecieWpisu).Include(w => w.Wycieczka);
            }
        }

        private IEnumerable<Wpis> GetOrderedFilteredQuery(FilterOption filterOption, SortingOption sortingOption)
        {
            switch (sortingOption) {
                case SortingOption.Newest:
                    return GetFilterQuery(filterOption).AsEnumerable().OrderByDescending(w => w.Data_Ukonczenia_Wycieczki);
                case SortingOption.Oldest:
                    return GetFilterQuery(filterOption).AsEnumerable().OrderBy(w => w.Data_Ukonczenia_Wycieczki);
                case SortingOption.PointsDecreasing:
                    return GetFilterQuery(filterOption).AsEnumerable().OrderByDescending(w => GetPointsForEntry(w.Numer));
                case SortingOption.PointsIncreasing:
                    return GetFilterQuery(filterOption).AsEnumerable().OrderBy(w => GetPointsForEntry(w.Numer));
                default:
                    throw new InvalidStateException("Unknown sorting option provided!");
            }
     
        }

        private Status GetStatusFromFilterOption(FilterOption filterOption)
        {
            switch (filterOption)
            {
                case FilterOption.Verified:
                    return Status.Zweryfikowany;
                case FilterOption.Rejected:
                    return Status.Odrzucony;
                case FilterOption.Pending:
                    return Status.Weryfikowany;
                default:
                    throw new InvalidStateException("Unknown filter option provided!");
            }
        }

        private IEnumerable<Wpis> OrderData(IEnumerable<Wpis> dataToOrder, SortingOption sortingOption)
        {
            switch(sortingOption)
            {
                case SortingOption.Newest:
                    return dataToOrder.OrderByDescending(w => w.Data_Ukonczenia_Wycieczki);
                case SortingOption.Oldest:
                    return dataToOrder.OrderBy(w => w.Data_Ukonczenia_Wycieczki);
                case SortingOption.PointsDecreasing:
                    return dataToOrder.OrderByDescending(w => GetPointsForEntry(w.Numer));
                case SortingOption.PointsIncreasing:
                    return dataToOrder.OrderBy(w => GetPointsForEntry(w.Numer));
                default:
                    throw new InvalidStateException("Unknown sorting option provided!");
            }
        }
    }
}
