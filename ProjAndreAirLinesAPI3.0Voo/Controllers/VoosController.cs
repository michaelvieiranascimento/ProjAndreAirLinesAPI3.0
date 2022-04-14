using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0Voo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ProjAndreAirLinesAPI3._0Voo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoosController : ControllerBase
    {
        private readonly VooService _vooService;

        public VoosController(VooService vooService)
        {
            _vooService = vooService;
        }

        [HttpGet]
        public ActionResult<List<Voo>> Get() =>
            _vooService.Get();


        [HttpGet("{id:length(24)}", Name = "GetCliente")]
        public ActionResult<Voo> Get(string id)
        {
            var cliente = _vooService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public ActionResult<Voo> Create(Voo cliente)
        {
            _vooService.Create(cliente);

            return CreatedAtRoute("GetCliente", new { id = cliente.Id.ToString() }, cliente);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Voo vooIn)
        {
            var voo = _vooService.Get(id);

            if (voo == null)
            {
                return NotFound();
            }

            _vooService.Update(id, vooIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var voo = _vooService.Get(id);

            if (voo == null)
            {
                return NotFound();
            }

            _vooService.Remove(voo.Id);

            return NoContent();
        }
    }
}
