using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwiumAPBD.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrzykladoweKolokwiumAPBD.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class ZamowieniaController : ControllerBase
    {

        private CukierniaContext _cukierniaContext;


        public ZamowieniaController(CukierniaContext cukierniaContext)
        {
            _cukierniaContext = cukierniaContext;
        }

        // GET: api/<CukierniaController>
        [HttpGet]
        public async Task<IActionResult> GetWithKlient([FromQuery(Name = "nazwiskoKlienta")] string nazwisko)
        {
            if(!String.IsNullOrEmpty(nazwisko))
            {
                var zamowieniaZNazwiskiem = await _cukierniaContext.Zamowienies
                .AsNoTracking()
                .Where(e => e.Klient.Nazwisko.Equals(nazwisko))
                .Select(zamowienie => new
                {
                    zamowienie.Klient,
                    zamowienie.Pracownik,
                    zamowienie.DataPrzyjecia,
                    zamowienie.DataRealizacji,
                    zamowienie.Uwagi,
                    skladZamówienia = zamowienie.Zamowienie_WyrobCukierniczy.Select(assoc => new { assoc.WyrobCukierniczy.Nazwa, assoc.WyrobCukierniczy.CenaZaSztuke }).ToList()
                })
                .ToListAsync();
                
                return Ok(zamowieniaZNazwiskiem);
            }

            var zamowienia = await _cukierniaContext.Zamowienies
                .AsNoTracking()
                .Select(zamowienie => new
                {
                    zamowienie.Klient,
                    zamowienie.Pracownik,
                    zamowienie.DataPrzyjecia,
                    zamowienie.DataRealizacji,
                    zamowienie.Uwagi,
                    skladZamówienia = zamowienie.Zamowienie_WyrobCukierniczy.Select(assoc => new { assoc.WyrobCukierniczy.Nazwa, assoc.WyrobCukierniczy.CenaZaSztuke }).ToList()
                })
                .ToListAsync();

            return Ok(zamowienia);
        }


        // GET api/<CukierniaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CukierniaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost("")]

        // PUT api/<CukierniaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CukierniaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
