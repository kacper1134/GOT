using GOT.Data.Services;
using GOT.Models;
using GOT.Models.Enums;
using GOT.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GOT.Controllers
{
    public class MapController : Controller
    {
        private IMapService mapService;
        private IWebHostEnvironment webHostEnvironment;

        public MapController(IMapService mapService, IWebHostEnvironment hostEnvironment)
        {
            this.mapService = mapService;
            webHostEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> Index()
        {

            var serializedPoints = SerializePoints(await mapService.getAllPoints());

            var serializedRoutes = SerializeRoutes(await mapService.getAllRoutes());

            ViewData["serialized-points"] = serializedPoints;
            ViewData["serialized-routes"] = serializedRoutes;

            return View();
        }

        public async Task<IActionResult> CreateNewRoute(RouteViewModel routeViewModel)
        {
            var beginningPointNumber = mapService.GetPointNumber(routeViewModel.Punkt_Poczatkowy);

            if(beginningPointNumber == 0)
            {
                return Content($"Podany przez Ciebie punkt początkowy {routeViewModel.Punkt_Poczatkowy} nie istnieje!");
            }

            var endingPointNumber = mapService.GetPointNumber(routeViewModel.Punkt_Koncowy);

            if(endingPointNumber == 0)
            {
                return Content($"Podany przez Ciebie punkt końcowy {routeViewModel.Punkt_Koncowy} nie istnieje!");
            }

            if(beginningPointNumber == endingPointNumber)
            {
                return Content("Punkt początkowy i punkt końcowy nie mogą być identyczne");
            }

            if (mapService.RouteExists(routeViewModel.Punkt_Poczatkowy, routeViewModel.Punkt_Koncowy))
            {
                return Content($"Odcinek {routeViewModel.Punkt_Poczatkowy} - {routeViewModel.Punkt_Koncowy} już istnieje w systemie!");
            }

            Odcinek createdRoute = await MapToRoute(routeViewModel, beginningPointNumber, endingPointNumber);

            await mapService.CreateRoute(createdRoute);

            return Content($"Odcinek {routeViewModel.Punkt_Poczatkowy} - {routeViewModel.Punkt_Koncowy} został utworzony");
        }

        public async Task<IActionResult> ModifyExistingRoute(RouteViewModel routeViewModel)
        {
            Odcinek updatedRoute = await UpdateToRoute(routeViewModel);

            await mapService.UpdateRoute(updatedRoute);

            return Content($"Odcinek {routeViewModel.Punkt_Poczatkowy} - {routeViewModel.Punkt_Koncowy} został zmodyfikowany");
        }

        public async Task<IActionResult> DeleteExistingRoute(RouteViewModel routeViewModel)
        {
            await DeleteUserPhoto(routeViewModel.NazwaZdjecia);

            int routeIdentifier = mapService.GetRouteNumber(routeViewModel.Punkt_Poczatkowy, routeViewModel.Punkt_Koncowy);

            await mapService.DeleteRoute(routeIdentifier);

            return Content($"Odcinek {routeViewModel.Punkt_Poczatkowy} - {routeViewModel.Punkt_Koncowy} został usunięty");
        }

        public IActionResult GetRouteDataByIdentifier(int routeNumber)
        {
            var routeData = mapService.GetRouteByIdentifier(routeNumber);

            return Json(MapToRouteViewModel(routeData));
        }

        public IActionResult GetRouteData(string beginning, string ending)
        {
            var routeData = mapService.GetRoute(beginning, ending);

            routeData.Punkt_Poczatkowy.OdcinekKoncowy = null;
            routeData.Punkt_Poczatkowy.OdcinekPoczatkowy = null;
            routeData.Punkt_Koncowy.OdcinekPoczatkowy = null;
            routeData.Punkt_Koncowy.OdcinekKoncowy = null;

            return Json(JsonConvert.SerializeObject(routeData));
        }

        private RouteViewModel MapToRouteViewModel(Odcinek route)
        {
            return new RouteViewModel
            {
                Punkt_Poczatkowy = route.Punkt_Poczatkowy.Nazwa,
                Punkt_Koncowy = route.Punkt_Koncowy.Nazwa,
                Dlugosc = route.Dlugosc,
                Podejscie = route.Podejscie,
                Punkty_GOT = route.Punkty,
                Kolor = (int)route.Kolor,
                NazwaZdjecia = route.Zdjecie != null ? route.Zdjecie : "images/default.jpg",
                Dwukierunkowy = route.Dwukierunkowy ? "on" : "off",
                Zamkniety = route.Zamkniety ? "on" : "off"
            };
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
            foreach(Odcinek odcinek in odcinki)
            {
                odcinek.Punkt_Poczatkowy = null;
                odcinek.Punkt_Koncowy = null;
            }

            return odcinki;
        } 

        private async Task<Odcinek> MapToRoute(RouteViewModel routeViewModel, int beginningPointNumber, int endingPointNumber)
        {
            Odcinek createdRoute = new Odcinek
            {
                Zamkniety = routeViewModel.Zamkniety == "on",
                Dlugosc = routeViewModel.Dlugosc,
                Podejscie = routeViewModel.Podejscie,
                Numer_Punktu_Poczatkowego = beginningPointNumber,
                Numer_Punktu_Koncowego = endingPointNumber,
                Kolor = (Kolor)routeViewModel.Kolor,
                Punkty = routeViewModel.Punkty_GOT,
                Dwukierunkowy = routeViewModel.Dwukierunkowy == "on",
                Zdjecie = await SaveUserPhoto(routeViewModel.Zdjecie)
            };

            return createdRoute;
        }

        private async Task<Odcinek> UpdateToRoute(RouteViewModel routeViewModel)
        {
            Odcinek updatedRoute = new Odcinek
            {
                Numer = mapService.GetRouteNumber(routeViewModel.Punkt_Poczatkowy, routeViewModel.Punkt_Koncowy),
                Zamkniety = routeViewModel.Zamkniety == "on",
                Dlugosc = routeViewModel.Dlugosc,
                Podejscie = routeViewModel.Podejscie,
                Numer_Punktu_Poczatkowego = mapService.GetPointNumber(routeViewModel.Punkt_Poczatkowy),
                Numer_Punktu_Koncowego = mapService.GetPointNumber(routeViewModel.Punkt_Koncowy),
                Kolor = (Kolor)routeViewModel.Kolor,
                Punkty = routeViewModel.Punkty_GOT,
                Dwukierunkowy = routeViewModel.Dwukierunkowy == "on",
                Zdjecie = await SaveUserPhoto(routeViewModel.Zdjecie)
            };

            return updatedRoute;
        }

        private async Task<string> SaveUserPhoto(IFormFile userPhoto)
        {
            string dbFilePath = null;

            if (userPhoto != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");

                var uniqueFilename = Guid.NewGuid().ToString() + "_" + userPhoto.FileName;

                dbFilePath = Path.Combine("uploads", uniqueFilename).Replace('\\', '/');

                string filepath = Path.Combine(uploadsFolder, uniqueFilename);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await userPhoto.CopyToAsync(stream);
                }
            } else
            {
                dbFilePath = Path.Combine("images", "default.jpg").Replace('\\', '/');
            }

            return dbFilePath;
        }

        private async Task<string> DeleteUserPhoto(string photoPath)
        {
            string defaultPhotoPath = "images/default.jpg";

            if (photoPath != defaultPhotoPath)
            {
                string imageName = photoPath[8..];

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");

                string filepath = Path.Combine(uploadsFolder, imageName);

                if (System.IO.File.Exists(filepath))
                {
                    try
                    {
                        System.IO.File.Delete(filepath);
                    } catch(IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                return filepath;
            }

            return defaultPhotoPath;
        }

    }
}
