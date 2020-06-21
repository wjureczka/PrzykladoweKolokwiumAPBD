using System.ComponentModel.DataAnnotations;

namespace PrzykladoweKolokwiumAPBD.Models
{
    public class Pracownik
    {
        [Key]
        public int IdPracownik { get; set; }

        [Required]
        [MaxLength(50)]
        public string Imie { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nazwisko { get; set; }
    }
}