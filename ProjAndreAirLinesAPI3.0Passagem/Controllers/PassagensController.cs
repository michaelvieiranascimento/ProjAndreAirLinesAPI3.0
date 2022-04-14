using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0Passagem.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ProjAndreAirLinesAPI3._0Passagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagensController : ControllerBase
    {

        private readonly PassagemService _passagemService;

        public PassagensController(PassagemService passagemService)
        {
            _passagemService = passagemService;
        }

        [HttpGet]
        public ActionResult<List<Passagem>> Get() =>
            _passagemService.Get();


        [HttpGet("{id:length(24)}", Name = "Getpassagem")]
        public ActionResult<Passagem> Get(string id)
        {
            var passagem = _passagemService.Get(id);

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        [HttpPost]
        public ActionResult<Passagem> Create(Passagem passagem)
        {
            _passagemService.Create(passagem);

            return CreatedAtRoute("GetPassagem", new { id = passagem.Id.ToString() }, passagem);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Passagem passagemIn)
        {
            var passagem = _passagemService.Get(id);

            if (passagem == null)
            {
                return NotFound();
            }

            _passagemService.Update(id, passagemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var passagem = _passagemService.Get(id);

            if (passagem == null)
            {
                return NotFound();
            }

            _passagemService.Remove(passagem.Id);

            return NoContent();
        }
    }
}
