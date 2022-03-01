using GOT.Data.Services;
using GOT.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Controllers
{
    public class WycieczkaController : Controller
    {
        private readonly IWycieczkaService _service;
        private readonly int pageSize = 3;

        public WycieczkaController(IWycieczkaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int filterOption = 13, int orderOption = 1)
        {
            _service.ChangeFilterAndOrderOptions(filterOption, orderOption);

            ViewData["Titles"] = await _service.GetTitlesByPageNumber(pageNumber, pageSize);

            ViewData["Times"] = await _service.GetTimeByPageNumber(pageNumber, pageSize);

            (ViewData["CurrentPageNumber"], ViewData["NextPageNumber"], ViewData["MaxPageNumber"]) = await _service.GetPageNumbers(pageNumber, pageSize);

            ViewData["filterOptionNumber"] = filterOption;

            ViewData["orderOptionNumber"] = orderOption;

            return View(await _service.GetByPageNumer(pageNumber, pageSize));
        }

        public async Task<IActionResult> Details(int tripNumber)
        {
            ViewData["TripTitle"] = await _service.GetTitleById(tripNumber);


            var tripTime = (await _service.GetTimeById(tripNumber)).Split("-");
            (ViewData["TripStartTime"], ViewData["TripEndTime"]) = (tripTime[0], tripTime[1]);

            ViewData["TripPoints"] = await _service.GetPointsById(tripNumber);

            ViewData["TripSegments"] = await _service.GetSegmentsById(tripNumber);

            ViewData["TripNumber"] = tripNumber;

            return View();
        }

        public async Task<IActionResult> Delete(int tripNumber)
        {
            ViewData["TripTitle"] = await _service.GetTitleById(tripNumber);

            var tripTime = (await _service.GetTimeById(tripNumber)).Split("-");
            (ViewData["TripStartTime"], ViewData["TripEndTime"]) = (tripTime[0], tripTime[1]);

            ViewData["TripPoints"] = await _service.GetPointsById(tripNumber);

            ViewData["TripSegments"] = await _service.GetSegmentsById(tripNumber);

            return View(await _service.GetById(tripNumber));
        }

        public async Task<IActionResult> DeleteConfirm(int tripNumber)
        {
            await _service.DeleteById(tripNumber);
            return Redirect("Index");
        }
    
        public async Task<IActionResult> Create(bool error = false, int routeNumber = -1)
        {
            ViewData["TripSegments"] = await _service.GetSegmentsByRouteId(routeNumber);
            ViewData["CurrentDate"] = DateTime.Today.ToString("yyyy-MM-dd");
            ViewData["MaxData"] = DateTime.Today.AddYears(1).ToString("yyyy-MM-dd");
            ViewData["ErrorFunction"] = error ? "ErrorModal()" : "";
            ViewData["RouteNumber"] = routeNumber == -1 ? null : routeNumber;
            return View();
        }

        public async Task<IActionResult> CreateConfirm(DateTime startDate, int tripDuration, int routeNumber)
        {
            if (await _service.CheckTime(startDate, tripDuration))
            {
                return Redirect("Create?error=true");
            }

            await _service.Create(startDate, tripDuration, routeNumber);
            return Redirect("Index");
        }

        public async Task<IActionResult> Update(int tripNumber, int routeNumber = -1)
        {
            var trip = await _service.GetById(tripNumber);
            var numer = routeNumber == -1 ? trip.Numer_Trasy : routeNumber;

            ViewData["TripSegments"] = await _service.GetSegmentsByRouteId(numer);
            ViewData["CurrentDate"] = trip.Data_Zgloszenia.ToString("yyyy-MM-dd");
            ViewData["MaxData"] = DateTime.Today.AddYears(1).ToString("yyyy-MM-dd");
            ViewData["TripTitle"] = await _service.GetTitleById(tripNumber);
            ViewData["RouteNumber"] = numer;

            return View(trip);
        }

        public async Task<IActionResult> UpdateConfirm(int tripNumber, DateTime startDate, int tripDuration, int routeNumber)
        {
            await _service.Update(tripNumber, startDate, tripDuration, routeNumber);
            return Redirect("Index");
        }

        public async Task<IActionResult> ChooseRoute(int tripNumber=-1)
        {
            ViewData["TripNumber"] = tripNumber;
            ViewData["Routes"] = (await _service.GetAllRoutes()).ToList();
            
            return View("Route");
        }

        public async Task<IActionResult> DisplayRouteOnMap(int tripNumber, string callerController, string callerAction, int verificationNumber = -1)
        {
            var serializedPoints = SerializePoints(await _service.GetPointsForTrip(tripNumber));

            var serializedRoutes = SerializeRoutes(await _service.GetRoutesForTrip(tripNumber));

            ViewData["serialized-points"] = serializedPoints;
            ViewData["serialized-routes"] = serializedRoutes;
            ViewData["VerificationNumber"] = verificationNumber;
            ViewData["TripNumber"] = verificationNumber == -1 ? tripNumber: verificationNumber;
            ViewData["Controller"] = callerController;
            ViewData["Action"] = callerAction;

            return View("Map");
        }

        private string SerializePoints(ICollection<PunktGeograficzny> punktyGeograficzne)
        {
            return JsonConvert.SerializeObject(punktyGeograficzne);
        }

        private string SerializeRoutes(ICollection<Odcinek> odcinki)
        {
            return JsonConvert.SerializeObject(RemoveDependencyCycle(odcinki));
        }

        private ICollection<Odcinek> RemoveDependencyCycle(ICollection<Odcinek> odcinki)
        {
            foreach (Odcinek odcinek in odcinki)
            {
                odcinek.Punkt_Poczatkowy = null;
                odcinek.Punkt_Koncowy = null;
            }

            return odcinki;
        }
    }
}
