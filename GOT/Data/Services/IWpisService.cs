using GOT.Exceptions;
using GOT.Models;
using GOT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOT.Data.Services
{
    public interface IWpisService
    {
        public Task<IEnumerable<Wpis>> GetAll(FilterOption filterOption, SortingOption sortingOption);

        public Task<Wpis> GetEntryByIdentifier(int entryIdentifier);

        public Task<IEnumerable<Odcinek>> GetTripSegmentsByEntryIdentifier(int entryIdentifier);

        public Task<IEnumerable<Wpis>> GetByPageNumber(int pageNumber, int pageSize, FilterOption filterOption, SortingOption sortingOption);

        public int GetNumberOfPages(int pageSize, FilterOption filterOption);

        public int GetCount(FilterOption filter);

        public ICollection<FilterOption> getAllFilterOptions()
        {
            return (ICollection<FilterOption>)Enum.GetValues(typeof(FilterOption));
        }

        public ICollection<SortingOption> getAllSortingOptions()
        {
            return (ICollection<SortingOption>)Enum.GetValues(typeof(SortingOption));
        }

        public int GetPointsForEntry(int entryIdentifier);


    }
}

public enum FilterOption
{
    None,
    Verified,
    Rejected,
    Pending
}

public enum SortingOption
{
    Newest,
    Oldest,
    PointsIncreasing,
    PointsDecreasing
}
