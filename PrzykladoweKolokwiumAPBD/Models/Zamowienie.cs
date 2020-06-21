using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwiumAPBD.Models
{
    public class Zamowienie
    {

        [Key]
        public int IdZamowienia { get; set; }

        [Required]
        public DateTime DataPrzyjecia { get; set; }

        public DateTime? DataRealizacji { get; set; }

        [MaxLength(300)]
        public string Uwagi { get; set; }

        [Required]
        public int IdKlient { get; set; }

        [Required]
        [ForeignKey("IdKlient")]
        public Klient Klient { get; set; }

        [Required]
        public int IdPracownik { get; set; }

        [Required]
        [ForeignKey("IdPracownik")]
        public Pracownik Pracownik { get; set; }

        public ICollection<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
    }
}