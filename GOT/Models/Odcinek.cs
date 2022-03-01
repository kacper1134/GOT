using GOT.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Odcinek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numer { get; set; }

        [MaxLength(1000, ErrorMessage = "To long description, do not exceed {1}")]
        public string Opis { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Incorrect points")]
        public int Punkty { get; set; }

        [Required]
        public bool Zamkniety { get; set; }

        [Required]
        [Range(1, 1000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Dlugosc { get; set; }

        [Required]
        [Range(1, 100000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Podejscie { get; set; }

        [Required]
        public int Numer_Punktu_Poczatkowego { get; set; }
        public PunktGeograficzny Punkt_Poczatkowy { get; set; }

        [Required]
        public int Numer_Punktu_Koncowego { get; set; }
        public PunktGeograficzny Punkt_Koncowy { get; set; }

        public Kolor Kolor { get; set; }

        [Required]
        public bool Dwukierunkowy { get; set; } = false;

        [MaxLength(1000, ErrorMessage = "To long photo name, do not exceed {1}")]
        public string Zdjecie { get; set; }

        public ICollection<OdcinekTrasy> OdcinekTrasy { get; set; }
        
    }
}
