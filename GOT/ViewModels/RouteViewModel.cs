using Microsoft.AspNetCore.Http;

namespace GOT.ViewModels
{
    public class RouteViewModel
    {
        public string Punkt_Poczatkowy { get; set; }

        public string Punkt_Koncowy { get; set; }

        public decimal Dlugosc { get; set; }

        public decimal Podejscie { get; set; }

        public int Punkty_GOT { get; set; }

        public int Kolor { get; set; }

        public IFormFile Zdjecie { get; set; }

        public string NazwaZdjecia { get; set; }

        public string Dwukierunkowy { get; set; } = "off";

        public string Zamkniety { get; set; } = "off";
    }
}