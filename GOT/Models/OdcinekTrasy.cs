using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class OdcinekTrasy
    {
        [Required]
        public int Numer_Trasy { get; set; }
        public Trasa Trasa { get; set; }
    
        [Required]
        public int Numer_Odcinka { get; set; }

        public Odcinek Odcinek { get; set; }

        //Provided to achieve segment ordering
        [Range(1, 500)]
        [Required]
        public int Numer_Odcinka_Trasy { get; set; }
    }
}
