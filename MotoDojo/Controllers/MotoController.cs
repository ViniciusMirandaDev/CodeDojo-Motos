using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoDojo.Entities;
using MotoDojo.Services;

namespace MotoDojo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        private IMotoService _service;

        public MotoController(IMotoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var motos = _service.GetAll();
            return Ok(motos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var moto = _service.GetById(id);

            if(moto == null) return NotFound();

            return Ok(moto);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Moto moto)
        {
            _service.Insert(moto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Moto moto)
        {
            _service.Update(moto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
