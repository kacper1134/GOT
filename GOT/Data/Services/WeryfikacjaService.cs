using GOT.Exceptions;
using GOT.Models;
using GOT.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GOT.Data.Services
{
    public class WeryfikacjaService: IWeryfikacjaService
    {
        private readonly MyDbContext _context;

        private  int filterOption = 3;
        private  int orderOption = 1;

        public WeryfikacjaService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Weryfikacja>> GetAll()
        {
           return OrderData(await FilterData());
        }
        public async Task<Weryfikacja> GetById(int id)
        {
            if (id < 1)
            {
                throw new InvalidEntryIdentifierException();
            }

            return _context.Weryfikacja.Include(w => w.Przodownik).Include(w => w.Wpis).Where(w => w.Numer_Wpisu == id).First();
        }
        public async Task<IEnumerable<Weryfikacja>> GetByPageNumer(int pageNumber, int pageSize)
        {
            var verificationApplicationList = await GetAll();
            var result = new List<Weryfikacja>();

            int index = pageSize;

            foreach (var item in verificationApplicationList)
            {
                if(index / pageSize == pageNumber)
                {
                    result.Add(item);
                }
                else if(index / pageSize > pageNumber)
                {
                    return result;
                }

                index += 1;
            }

            return result;
        }

        public async Task<int> GetCount()
        {
            return _context.Weryfikacja.Count();
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

        public async Task<List<string>> GetTitlesForAll()
        {
            var listOfTitles = new List<string>();
            var data = await GetAll();

            foreach (var application in data)
            {
                listOfTitles.Add("TW"+application.Numer_Wpisu.ToString().PadLeft(5, '0') + " " + GetRouteForVerificationId(application.Numer_Wpisu));
            }

            return listOfTitles;
        }

        public async Task<string> GetTitleById(int id)
        {
            var data = await GetById(id);

            return "TW" + data.Numer_Wpisu.ToString().PadLeft(5, '0') + " " + GetRouteForVerificationId(data.Numer_Wpisu);
        }

        public async Task<(int, int, int)> GetPageNumbers(int currentPageNumber, int pageSize)
        {
            int countApplication = await GetCount();

            int maxPageNumber = Math.Max(1, (int)Math.Ceiling(countApplication / (float)pageSize));
            var pageNumber = Math.Max(1, Math.Max(Math.Min(currentPageNumber, maxPageNumber - 2), 1));
            int nextPageNumber = Math.Max(1, Math.Min(pageNumber + 1, maxPageNumber));

            return (pageNumber, nextPageNumber, maxPageNumber);
        }

        private string GetRouteForVerificationId(int id)
        {
            var sections = _context.Weryfikacja.Where(w => w.Numer_Wpisu == id).Select(w => w.Wpis).Select(w => w.Wycieczka).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).OrderBy(o => o.Numer);
            return sections.Select(o => o.Punkt_Poczatkowy.Nazwa).First() + " - " + sections.Select(o => o.Punkt_Koncowy.Nazwa).Last();
        }

        public void ChangeFilterAndOrderOptions(int filterOption, int orderOption)
        {
            this.filterOption = filterOption;
            this.orderOption = orderOption;
        }

        public async Task<(string, string)> GetTripDuration(int id)
        {
            var dates = await _context.Weryfikacja.Include(w => w.Przodownik).Include(w => w.Wpis).Where(w => w.Numer_Wpisu == id).Select(w => w.Wpis).Select(w => w.Wycieczka.Data_Zgloszenia).ToListAsync();
            var dateStart = dates[0].ToString("d MMMM yyyy");

            var application = await GetById(id);
            var dateEnd = application.Wpis.Data_Ukonczenia_Wycieczki.ToString("d MMMM yyyy");
            

            return (dateStart, dateEnd);
        }

        public async Task<IEnumerable<Odcinek>> GetTripSegments(int id)
        {
            return await _context.Weryfikacja.Include(w => w.Przodownik).Include(w => w.Wpis).Where(w => w.Numer_Wpisu == id).Select(w => w.Wpis).Select(w => w.Wycieczka).Select(w => w.Trasa).Select(t => t.OdcinekTrasy).SelectMany(o => o.Select(o => o.Odcinek)).
                Include(o => o.Punkt_Poczatkowy).Include(o => o.Punkt_Koncowy).ToListAsync();
        }

        public async Task UpdateStatusById(int id, Status newStatus, string reason="")
        {
            var updatedApplication = _context.Weryfikacja.Single(w => w.Numer_Wpisu == id);

            updatedApplication.Status = newStatus;
            updatedApplication.Uzasadnienie = reason;
            
            await _context.SaveChangesAsync();
        }

        public async Task<List<String>> GetImagesById(int id)
        {
            return await _context.Weryfikacja.Where(w => w.Numer_Wpisu == id).Select(w => w.Wpis).Select(w => w.ZdjecieWpisu).SelectMany(z => z.Select(z => z.Identyfikator)).ToListAsync();
        }

        public int GetPointsForEntry(int entryIdentifier)
        {
            return _context.Wpis.Include(w => w.Wycieczka)
                .Where(w => w.Numer == entryIdentifier)
                .Select(w => w.Wycieczka)
                .Select(w => w.Trasa)
                .Select(t => t.OdcinekTrasy)
                .SelectMany(o => o.Select(oT => oT))
                .OrderBy(oT => oT.Numer_Odcinka_Trasy)
                .Select(oT => oT.Odcinek)
                .Sum(o => o.Punkty);
        }

        private async Task<IEnumerable<Weryfikacja>> FilterData()
        {
            if (filterOption == 3) return await _context.Weryfikacja.Include(w => w.Przodownik).Include(w => w.Wpis).ToListAsync();
            else return await _context.Weryfikacja.Include(w => w.Przodownik).Include(w => w.Wpis).Where(w => (int) w.Status == filterOption).ToListAsync();
        }

        private IEnumerable<Weryfikacja> OrderData(IEnumerable<Weryfikacja> data)
        {
            if (orderOption == 1) return data.OrderByDescending(w => w.Wpis.Data_Ukonczenia_Wycieczki);
            else return data.OrderBy(w => w.Wpis.Data_Ukonczenia_Wycieczki);
        }
    
    }
}
