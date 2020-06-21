using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwiumAPBD.DAL;
using PrzykladoweKolokwiumAPBD.DTO.Requests;
using PrzykladoweKolokwiumAPBD.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrzykladoweKolokwiumAPBD.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class KlientController : ControllerBase
    {

        private CukierniaContext _cukierniaContext;


        public KlientController(CukierniaContext cukierniaContext)
        {
            _cukierniaContext = cukierniaContext;
        }

        // GET: api/<KlientController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<KlientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<KlientController>
        [HttpPost("{klientId}/orders")]
        public async Task<IActionResult> Post(int klientId, [FromBody] NewOrderRequest request)
        {
            var klient = await _cukierniaContext.Klients.FindAsync(klientId);

            if(klient == null)
            {
                return NotFound("Klient nieznaleziony");
            }

            List<WyrobCukierniczy> wyroby = new List<WyrobCukierniczy>();

            var zamowienie = new Zamowienie
            {
                DataPrzyjecia = request.DataPrzyjecia,
                Klient = klient,
                IdPracownik = 1,
                Uwagi = request.Uwagi,
                Zamowienie_WyrobCukierniczy = new List<Zamowienie_WyrobCukierniczy>()
            };

            foreach (var wyrobRequest in request.Wyroby)
            {
                var wyrob = await _cukierniaContext.WyrobCukierniczies.Where(wyrob => wyrob.Nazwa.Equals(wyrobRequest.Wyrob)).FirstAsync();

                if (wyrob == null)
                {
                    return NotFound($"Wyrob nieznany: {wyrobRequest.Wyrob}");
                }

                zamowienie.Zamowienie_WyrobCukierniczy.Add(new Zamowienie_WyrobCukierniczy
                {
                    WyrobCukierniczy = wyrob,
                    Zamowienie = zamowienie,
                    Ilosc = wyrobRequest.Ilosc,
                    Uwagi = wyrobRequest.Uwagi
                });

                wyroby.Add(wyrob);
            }

            await _cukierniaContext.Zamowienies.AddAsync(zamowienie);
            await _cukierniaContext.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<KlientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KlientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
