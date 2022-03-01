using GOT.Data.Services;
using GOT.Exceptions;
using GOT.Models;
using GOT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Controllers
{
    public class HistoriaWycieczekController : Controller
    {
        private readonly IWpisService wpisService;
        private const int PAGE_SIZE = 3;

        public HistoriaWycieczekController(IWpisService wpisService)
        {
            this.wpisService = wpisService;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, string filterOption = "Pokaż wszystkie", string sortingOption = "Od najnowszych")
        {
            FilterOption filterType = getFilterOptionFromString(filterOption);
            SortingOption sortingType = getSortingOptionFromString(sortingOption);

            int numberOfPages = wpisService.GetNumberOfPages(PAGE_SIZE, filterType);

            ViewData["filter-options"] = new SelectList(getTranslatedFilterOptions(wpisService.getAllFilterOptions()));
            ViewData["sorting-options"] = new SelectList(getTranslatedSortingOptions(wpisService.getAllSortingOptions()));
            ViewData["current-page-number"] = pageNumber;
            ViewData["last-page-number"] = numberOfPages;
            ViewData["filter-option"] = filterOption;
            ViewData["sorting-option"] = sortingOption;

            if (numberOfPages == 0)
            {
                return View(new List<HistoriaWycieczekViewModel>());
            }

            IEnumerable<Wpis> wpisy = await wpisService.GetByPageNumber(pageNumber, PAGE_SIZE, filterType, sortingType);

            var viewModels = parseToViewModels(wpisy);

            return View(viewModels);
        }

        public async Task<IActionResult> Details(int entryNumber)
        {
            Wpis wpis = await wpisService.GetEntryByIdentifier(entryNumber);

            var viewModel = await parseToViewModel(wpis);

            return View(viewModel);
        }

        private IEnumerable<HistoriaWycieczekViewModel> parseToViewModels(IEnumerable<Wpis> wpisy)
        {
            List<HistoriaWycieczekViewModel> result = new List<HistoriaWycieczekViewModel>();

            foreach(var wpis in wpisy)
            {
                var viewModel = parseToViewModel(wpis).Result;

                result.Add(viewModel);
            }

            return result;
        }

        private async Task<HistoriaWycieczekViewModel> parseToViewModel(Wpis wpis)
        {
            var odcinkiTrasy = await wpisService.GetTripSegmentsByEntryIdentifier(wpis.Numer);

            var trasaWycieczki = odcinkiTrasy.First().Punkt_Poczatkowy.Nazwa + " - " + odcinkiTrasy.Last().Punkt_Koncowy.Nazwa;
            var regionWycieczki = odcinkiTrasy.First().Punkt_Poczatkowy.NazwaGrupyGorskiej;
            var sumaPodejsc = odcinkiTrasy.Sum(oT => oT.Podejscie);
            var dlugoscTrasy = odcinkiTrasy.Sum(oT => oT.Dlugosc);
            var zdjeciePoczatkowe = odcinkiTrasy.First().Zdjecie;
            var zdjecieKoncowe = odcinkiTrasy.Last().Zdjecie;
            var przyznanePunkty = wpisService.GetPointsForEntry(wpis.Numer);

            if (zdjeciePoczatkowe == null)
            {
                zdjeciePoczatkowe = "default.jpg";
            }

            if (zdjecieKoncowe == null)
            {
                zdjecieKoncowe = "default.jpg";
            }

            return new HistoriaWycieczekViewModel(wpis, przyznanePunkty, trasaWycieczki, regionWycieczki, sumaPodejsc, dlugoscTrasy, zdjeciePoczatkowe, zdjecieKoncowe);
        }

        private ICollection<string> getTranslatedFilterOptions(ICollection<FilterOption> filterOptions)
        {
            ICollection<string> result = new List<string>();

            foreach (FilterOption filterOption in filterOptions)
            {
                result.Add(getFilterOptionTranslation(filterOption));
            }

            return result;
        }

        private string getFilterOptionTranslation(FilterOption filterOption)
        {
            switch(filterOption)
            {
                case FilterOption.None:
                    return "Pokaż wszystkie";
                case FilterOption.Verified:
                    return "Zweryfikowane";
                case FilterOption.Pending:
                    return "W weryfikacji";
                case FilterOption.Rejected:
                    return "Odrzucone";
                default:
                    return "Nieznane";
            }
        }

        private ICollection<string> getTranslatedSortingOptions(ICollection<SortingOption> sortingOptions)
        {
            ICollection<string> result = new List<string>();

            foreach (SortingOption sortingOption in sortingOptions)
            {
                result.Add(getSortingOptionTranslation(sortingOption));
            }

            return result;
        }

        private string getSortingOptionTranslation(SortingOption sortingOption)
        {
            switch(sortingOption)
            {
                case SortingOption.Newest:
                    return "Od najnowszych";
                case SortingOption.Oldest:
                    return "Od najstarszych";
                case SortingOption.PointsDecreasing:
                    return "Liczba punktów: malejąco";
                case SortingOption.PointsIncreasing:
                    return "Liczba punktów: rosnąco";
                default:
                    return "Nieznane";
            }
        }

        private FilterOption getFilterOptionFromString(string filterOption)
        {
            string filterOptionString;

            switch(filterOption)
            {
                case "Pokaż wszystkie":
                    filterOptionString = "None";
                    break;
                case "Zweryfikowane":
                    filterOptionString = "Verified";
                    break;
                case "W weryfikacji":
                    filterOptionString = "Pending";
                    break;
                case "Odrzucone":
                    filterOptionString = "Rejected";
                    break;
                default:
                    throw new InvalidStateException("Unknown filter option!");
            }

            return (FilterOption)Enum.Parse(typeof(FilterOption), filterOptionString);
        }

        private SortingOption getSortingOptionFromString(string sortingOption)
        {
            string sortingOptionString;

            switch(sortingOption)
            {
                case "Od najnowszych":
                    sortingOptionString = "Newest";
                    break;
                case "Od najstarszych":
                    sortingOptionString = "Oldest";
                    break;
                case "Liczba punktów: malejąco":
                    sortingOptionString = "PointsDecreasing";
                    break;
                case "Liczba punktów: rosnąco":
                    sortingOptionString = "PointsIncreasing";
                    break;
                default:
                    throw new InvalidStateException("Unknown sorting option!");
            }

            return (SortingOption)Enum.Parse(typeof(SortingOption), sortingOptionString);
        }

    }
}
