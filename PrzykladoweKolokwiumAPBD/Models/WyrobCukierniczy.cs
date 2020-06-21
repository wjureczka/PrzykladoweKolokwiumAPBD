using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwiumAPBD.Models
{
    public class WyrobCukierniczy
    {

        [Key]
        public int IdWyrobuCukierniczego { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nazwa { get; set; }

        [Required]
        public float CenaZaSztuke { get; set; }

        [Required]
        [MaxLength(40)]
        public string Typ { get; set; }

        public ICollection<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
    }
}
