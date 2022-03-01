using GOT.Data;
using GOT.Exceptions;
using GOT.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Wpis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numer { get; set; }

        public int Numer_Ksiazecki { get; set; }
        public KsiazeckaGOT KsiazeckaGOT { get; set; }

        public int Numer_Wycieczki { get; set; }
        public Wycieczka Wycieczka { get; set; }

        [Required]
        public DateTime Data_Ukonczenia_Wycieczki { get; set; }

        public Weryfikacja Weryfikacja { get; set; }

        public ICollection<ZdjecieWpisu> ZdjecieWpisu { get; set; }

        public static string GetStatusDescription(Status status)
        {
            switch (status)
            {
                case Status.Zweryfikowany:
                    return "Wniosek został zweryfikowany pomyślnie";
                case Status.Weryfikowany:
                    return "Złożono wniosek o weryfikację";
                case Status.Odrzucony:
                    return "Wniosek o weryfikację został odrzucony";
                default:
                    throw new InvalidStateException("Unknown request status provided!");
            }
        }

        public override bool Equals(object other)
        {
            var otherEntry = other as Wpis;

            if (otherEntry == null)
            {
                return false;
            }


            return Numer.Equals(otherEntry.Numer) && Numer_Ksiazecki.Equals(otherEntry.Numer_Ksiazecki) && Numer_Wycieczki.Equals(otherEntry.Numer_Wycieczki)
                && Data_Ukonczenia_Wycieczki.Equals(otherEntry.Data_Ukonczenia_Wycieczki);
        }

        public override int GetHashCode()
        {
            return Numer.GetHashCode();
        }
    }
}
