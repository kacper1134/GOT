using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOT.Models
{
    public class Wycieczka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numer { get; set; }

        [Required]
        public int Numer_Trasy { get; set; }
        public Trasa Trasa { get; set; }

        [Required]
        public DateTime Data_Zgloszenia { get; set; }

        public string Login_Przodownika { get; set; }

        public Przodownik Przodownik { get; set; }

        public ICollection<Wpis> Wpis;
    }
}
