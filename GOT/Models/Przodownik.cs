using GOT.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Przodownik
    {
        [Key]
        public string Login { get; set; }

        public Wyksztalcenie Wyksztalcenie { get; set; }

        public DaneUzytkownika DaneUzytkownika { get; set; }

        public ICollection<Weryfikacja> Weryfikacja { get; set; }

        public ICollection<Wycieczka> Wycieczka { get; set; }
    }
}
