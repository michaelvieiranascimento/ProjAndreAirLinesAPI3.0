using System.Collections.Generic;
using ProjAndreAirLinesAPI3._0PrecoBase.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjAndreAirLinesAPI3._0Models;


namespace ProjAndreAirLinesAPI3._0PrecoBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecosBaseController : ControllerBase
    {
        private readonly PrecoBaseService _precobaseService;

        public PrecosBaseController(PrecoBaseService precobaseService)
        {
            _precobaseService = precobaseService;
        }

        [HttpGet]
        public ActionResult<List<PrecoBase>> Get() =>
            _precobaseService.Get();


        [HttpGet("{id:length(24)}", Name = "Getprecobase")]
        public ActionResult<PrecoBase> Get(string id)
        {
            var precobase = _precobaseService.Get(id);

            if (precobase == null)
            {
                return NotFound();
            }

            return precobase;
        }

        [HttpPost]
        public ActionResult<PrecoBase> Create(PrecoBase precobase)
        {
            _precobaseService.Create(precobase);

            return CreatedAtRoute("GetPrecoBase", new { id = precobase.Id.ToString() }, precobase);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PrecoBase precobaseIn)
        {
            var precobase = _precobaseService.Get(id);

            if (precobase == null)
            {
                return NotFound();
            }

            _precobaseService.Update(id, precobaseIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var precobase = _precobaseService.Get(id);

            if (precobase == null)
            {
                return NotFound();
            }

            _precobaseService.Remove(precobase.Id);

            return NoContent();
        }
    }
}
