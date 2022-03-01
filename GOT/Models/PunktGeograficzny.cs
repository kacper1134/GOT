using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class PunktGeograficzny
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; }

        [Required]
        [Range(0, 180)]
        public decimal Dlugosc_Geograficzna { get; set; }

        [Required]
        [Range(0, 90)]
        public decimal Szerokosc_Geograficzna { get; set; }

        [Required]
        [Range(-500, 9000)]
        public int Wysokosc { get; set; }

        [MaxLength(1000, ErrorMessage = "Too long photo identifier")]
        public string Zdjecie { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Invalid mountain group name!", MinimumLength = 3)]
        public string NazwaGrupyGorskiej { get; set; }

        public GrupaGorska GrupaGorska { get; set; }

        public ICollection<Odcinek> OdcinekPoczatkowy{ get; set; }

        public ICollection<Odcinek> OdcinekKoncowy { get; set; }
    }
}
