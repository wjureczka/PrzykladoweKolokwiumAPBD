using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwiumAPBD.DTO.Requests
{
    public class NewOrderRequest
    {
        [Required]
        public DateTime DataPrzyjecia { get; set; }

        public string Uwagi { get; set; }

        [Required]
        public ICollection<WyrobNerOrderRequest> Wyroby { get; set; }
    }

    public class WyrobNerOrderRequest
    {
        [Required]
        public int Ilosc { get; set; }

        [Required]
        public string Wyrob { get; set; }

        public string Uwagi { get; set; }
    }
}
