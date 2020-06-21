using System.ComponentModel.DataAnnotations;

namespace PrzykladoweKolokwiumAPBD.Models
{
    public class Klient
    {
        [Key]
        public int IdKlient { get; set; }

        [Required]
        [MaxLength(50)]
        public string Imie { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nazwisko { get; set; } 
    }
}