using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOT.Models
{
    public class Turysta
    {
        [Key]
        public string Login { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Liczba_Punktow { get; set; }

        [Required]
        public bool Wiarygodny { get; set; } = true;

        public DaneUzytkownika DaneUzytkownika { get; set; }
    }

}
