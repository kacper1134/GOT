using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Trasa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numer { get; set; }

        [MaxLength(500, ErrorMessage = "To long description, do not exceed {1}")]
        public string Opis { get; set; }

        public ICollection<Wycieczka> Wycieczka { get; set; }

        public ICollection<OdcinekTrasy> OdcinekTrasy { get; set; }
    }
}
