using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjAndreAirLinesAPI3._0Models;

namespace ProjAndreAirLinesAPI3._0Aeroporto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportosController : ControllerBase
    {
        private readonly Services.AeroportoService _aeroportoService;

        public AeroportosController(Services.AeroportoService aeroportoService)
        {
            _aeroportoService = aeroportoService;
        }

        [HttpGet]
        public ActionResult<List<Aeroporto>> Get() =>
            _aeroportoService.Get();


        [HttpGet("{id:length(24)}", Name = "GetAeroporto")]
        public ActionResult<Aeroporto> Get(string id)
        {
            var aeroporto = _aeroportoService.Get(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        [HttpPost]
        public ActionResult<Aeronave> Create(Aeroporto aeroporto)
        {
            _aeroportoService.Create(aeroporto);

            return CreatedAtRoute("GetAeroporto", new { id = aeroporto.Id.ToString() }, aeroporto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Aeroporto aeroportoIn)
        {
            var aeroporto = _aeroportoService.Get(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            _aeroportoService.Update(id, aeroportoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var aeroporto = _aeroportoService.Get(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            _aeroportoService.Remove(aeroporto.Id);

            return NoContent();
        }
    }
}
