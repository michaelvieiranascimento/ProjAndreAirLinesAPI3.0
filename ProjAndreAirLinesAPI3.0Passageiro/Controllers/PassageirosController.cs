using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0Passageiro.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ProjAndreAirLinesAPI3._0Passageiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly PassageiroService _passageiroService;

        public PassageirosController(PassageiroService passageiroService)
        {
            _passageiroService = passageiroService;
        }

        [HttpGet]
        public ActionResult<List<Passageiro>> Get() =>
            _passageiroService.Get();


        [HttpGet("{id:length(24)}", Name = "Getpassageiro")]
        public ActionResult<Passageiro> Get(string id)
        {
            var passageiro = _passageiroService.Get(id);

            if (passageiro == null)
            {
                return NotFound();
            }

            return passageiro;
        }

        [HttpPost]
        public ActionResult<Passageiro> Create(Passageiro passageiro)
        {
            _passageiroService.Create(passageiro);

            return CreatedAtRoute("GetPassageiro", new { id = passageiro.Id.ToString() }, passageiro);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Passageiro passageiroIn)
        {
            var passageiro = _passageiroService.Get(id);

            if (passageiro == null)
            {
                return NotFound();
            }

            _passageiroService.Update(id, passageiroIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var passageiro = _passageiroService.Get(id);

            if (passageiro == null)
            {
                return NotFound();
            }

            _passageiroService.Remove(passageiro.Id);

            return NoContent();
        }
    }
}
