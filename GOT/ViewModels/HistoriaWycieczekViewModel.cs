using GOT.Models;
using GOT.Models.Enums;
using System;
using System.Collections.Generic;

namespace GOT.ViewModels
{
    public class HistoriaWycieczekViewModel
    {

        public string Przyznane_Punkty { get; set; }

        public int Numer_Wpisu { get; set; }

        public int Numer_Ksiazecki { get; set; }

        public Wycieczka Wycieczka { get; set; }

        public DateTime Data_Ukonczenia_Wycieczki { get; set; }

        public Status Status_Weryfikacji { get; set; }

        public ICollection<ZdjecieWpisu> ZdjecieWpisu { get; set; }

        public string Trasa_Wycieczki { get; set; }

        public string Region_Wycieczki { get; set; }

        public string Suma_Podejsc { get; set; }

        public string Dlugosc_Trasy { get; set; }

        public string Zdjecie_Poczatkowe { get; set; }

        public string Zdjecie_Koncowe { get; set; }

        public HistoriaWycieczekViewModel(Wpis wpis, int przyznanePunkty, string trasaWycieczki, string regionWycieczki, decimal sumaPodejsc, decimal dlugoscTrasy, string zdjeciePoczatkowe, string zdjecieKoncowe)
        {
            this.Przyznane_Punkty = getProperConjugation(przyznanePunkty);
            this.Numer_Wpisu = wpis.Numer;
            this.Zdjecie_Poczatkowe = zdjeciePoczatkowe;
            this.Zdjecie_Koncowe = zdjecieKoncowe;
            this.Numer_Ksiazecki = wpis.Numer_Ksiazecki;
            this.Wycieczka = wpis.Wycieczka;
            this.Data_Ukonczenia_Wycieczki = wpis.Data_Ukonczenia_Wycieczki;
            this.Status_Weryfikacji = wpis.Weryfikacja.Status;
            this.ZdjecieWpisu = wpis.ZdjecieWpisu;
            this.Suma_Podejsc = getRouteApproachString(sumaPodejsc);
            this.Dlugosc_Trasy = getRouteLengthString(dlugoscTrasy);
            this.Trasa_Wycieczki = trasaWycieczki;
            this.Region_Wycieczki = regionWycieczki;
        }

        private string getProperConjugation(int przyznanePunkty)
        {
            switch(przyznanePunkty)
            {
                case int x when x == 1:
                    return x + " punkt";
                case int x when x % 10 > 1 && x % 10 < 5:
                    return x + " punkty";
                default:
                    return przyznanePunkty + " punktów";
            }
        }

        private string getRouteLengthString(decimal dlugoscTrasy)
        {
            if (dlugoscTrasy > 2000)
            {
                dlugoscTrasy = Decimal.Round(dlugoscTrasy / 1000, 1);

                return dlugoscTrasy + " kilometra";
            } else
            {
                dlugoscTrasy = Decimal.Round(dlugoscTrasy, 1);

                return dlugoscTrasy + " metra";
            }
        }

        private string getRouteApproachString(decimal sumaPodejsc)
        {
            if (sumaPodejsc > 2000)
            {
                sumaPodejsc = Decimal.Round(sumaPodejsc / 1000, 1);

                return sumaPodejsc + " kilometra";
            }
            else
            {
                sumaPodejsc = Decimal.Round(sumaPodejsc, 1);

                return sumaPodejsc + " metra";
            }
        }
    }
}
