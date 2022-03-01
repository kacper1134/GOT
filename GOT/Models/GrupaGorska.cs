using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOT.Models
{
    public class GrupaGorska
    {
        [Key]
        [MinLength(4, ErrorMessage = "Too short mountain group name!")]
        [MaxLength(100, ErrorMessage = "Too long mountain group name!")]
        public string Nazwa { get; set; }

        [Required]
        public bool WPolsce { get; set; } = true;

        public ICollection<PunktGeograficzny> Punkty { get; set; }
    }
}
