using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOT.Models
{
    public class DaneUzytkownika
    {
        [Key]
        [MinLength(4, ErrorMessage = "Too short login")]
        [MaxLength(50, ErrorMessage = "Too long login, do not exceed {1}")]
        public string Login { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "Too short password")]
        [MaxLength(100, ErrorMessage = "Too long password, do not exceed {1}")]
        public string Haslo { get; set; }

        [MinLength(9, ErrorMessage = "Too short email")]
        [MaxLength(100, ErrorMessage = "Too long email, do not exceed {1}")]
        public string Adres_Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Too short name")]
        [MaxLength(25, ErrorMessage = "Too long name, do not exceed {1}")]
        public string Imie { get; set; }

        [MinLength(2, ErrorMessage = "Too short name")]
        [MaxLength(50, ErrorMessage = "Too long name, do not exceed {1}")]
        public string Nazwisko { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Data_Urodzenia { get; set; }
       
        public ICollection<KsiazeckaGOT> KsiazeckaGOT { get; set; }

        public Turysta Turysta;

        public Przodownik Przodownik;
    }
}
