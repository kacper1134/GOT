using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class KsiazeckaGOT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numer { get; set; }

        public string Login { get; set; }

        public DaneUzytkownika DaneUzytkownika { get; set; }

        public ICollection<Wpis> Wpis { get; set; }
    }
}
