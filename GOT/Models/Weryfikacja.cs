using GOT.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Weryfikacja
    {
        
        public int Numer_Wpisu { get; set; }
        public Wpis Wpis { get; set; }

        public string Login_Przodownika { get; set; }
        public Przodownik Przodownik { get; set; }

        [Required]
        public DateTime Data_Weryfikacji { get; set; }

        [Required]
        [MaxLength(2500, ErrorMessage = "To long justification, do not exceed {1}")]
        public string Uzasadnienie { get; set; }

        [Required]
        public Status Status { get; set; }

        public static string BorderColorForStatus(Status status)
        {
            if (status == Status.Zweryfikowany) return "#188C48";
            else if (status == Status.Weryfikowany) return "#f78000";
            else return "#a72c33";
        }
    
        public string GetDateInformation()
        {
            return "Wniosek został złożony " + Wpis.Data_Ukonczenia_Wycieczki.ToString("d MMMM yyyy");
        }

        public override bool Equals(object obj)
        {
            var other = obj as Weryfikacja;

            if (other == null)
            {
                return false;
            }

            return Numer_Wpisu.Equals(other.Numer_Wpisu) && Login_Przodownika.Equals(other.Login_Przodownika)
                && Data_Weryfikacji.Equals(other.Data_Weryfikacji) && Uzasadnienie.Equals(other.Uzasadnienie)
                && Status.Equals(other.Status);
        }

        public override int GetHashCode()
        {
            return Numer_Wpisu.GetHashCode() + Login_Przodownika.GetHashCode() + Data_Weryfikacji.GetHashCode();
        }
    }
}
