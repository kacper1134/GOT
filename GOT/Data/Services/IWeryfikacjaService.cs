using GOT.Models;
using GOT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOT.Data.Services
{
    public interface IWeryfikacjaService
    {
        Task<IEnumerable<Weryfikacja>> GetAll();

        Task<Weryfikacja> GetById(int id);

        Task<int> GetCount();

        Task<IEnumerable<Weryfikacja>> GetByPageNumer(int pageNumber, int pageSize);

        Task<List<String>> GetTitlesForAll();

        Task<String> GetTitleById(int id);

        Task<List<String>> GetTitlesByPageNumber(int pageNumber, int pageSize);

        Task<(int, int, int)> GetPageNumbers(int currentPageNumber, int pageSize);

        void ChangeFilterAndOrderOptions(int filterOption, int orderOption);

        Task<(string, string)> GetTripDuration(int id);

        Task<IEnumerable<Odcinek>> GetTripSegments(int id);

        Task UpdateStatusById(int id, Status newStatus, string reason = "");

        Task<List<String>> GetImagesById(int id);

        int GetPointsForEntry(int entryIdentifier);
    }
}
