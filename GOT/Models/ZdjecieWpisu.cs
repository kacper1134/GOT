using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class ZdjecieWpisu
    {
        [Key]
        [MaxLength(250, ErrorMessage = "To long photo name, do not extend {1}")]
        public string Identyfikator { get; set; }

        [Required]
        public int Numer_Wpisu { get; set; }

        public Wpis Wpis { get; set; }
    }
}
