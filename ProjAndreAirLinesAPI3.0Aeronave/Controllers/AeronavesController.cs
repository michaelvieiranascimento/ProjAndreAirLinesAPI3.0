using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjAndreAirLinesAPI3._0Models;

namespace ProjAndreAirLinesAPI3._0Aeronave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeronavesController : ControllerBase
    {
        private readonly Services.AeronaveService _aeronaveService;

        public AeronavesController(Services.AeronaveService aeronaveService)
        {
            _aeronaveService = aeronaveService;
        }

        [HttpGet]
        public ActionResult<List<Aeronave>> Get() =>
            _aeronaveService.Get();


        [HttpGet("{id:length(60)}", Name = "GetAeronave")]
        public ActionResult<Aeronave> Get(string id)
        {
            var aeronave = _aeronaveService.Get(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            return aeronave;
        }

        [HttpPost]
        public ActionResult<Aeronave> Create(Aeronave aeronave)
        {
            _aeronaveService.Create(aeronave);

            return CreatedAtRoute("GetAeronave", new { id = aeronave.Id.ToString() }, aeronave);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Aeronave aeronaveIn)
        {
            var aeronave = _aeronaveService.Get(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            _aeronaveService.Update(id, aeronaveIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var aeronave = _aeronaveService.Get(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            _aeronaveService.Remove(aeronave.Id);

            return NoContent();
        }
    }
}
