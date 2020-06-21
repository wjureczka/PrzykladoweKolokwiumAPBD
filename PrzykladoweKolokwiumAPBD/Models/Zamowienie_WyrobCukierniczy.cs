using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrzykladoweKolokwiumAPBD.Models
{
    public class Zamowienie_WyrobCukierniczy
    {

        [Key]
        public int IdWyrobuCukierniczego { get; set; }

        [ForeignKey("IdWyrobuCukierniczego")]
        public WyrobCukierniczy WyrobCukierniczy { get; set; }

        [Key]
        public int IdZamowienia { get; set; }

        [ForeignKey("IdZamowienia")]
        public Zamowienie Zamowienie { get; set; }

        [Required]
        public int Ilosc { get; set; }

        [MaxLength(300)]
        public string Uwagi { get; set; }
    }
}
