using Lab02_ODataBookAPI.Models;
using Lab02_ODataBookAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Lab02_ODataBookAPI.Controllers
{
    [Route("odata/[controller]")]
    public class PressesController : ODataController
    {
        private readonly IPressService _service;

        public PressesController(IPressService service)
        {
            _service = service;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public IActionResult Get(int key)
        {
            var press = _service.GetById(key);
            if (press == null) return NotFound();
            return Ok(press);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Press press)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = _service.Add(press);
            return Created(created);
        }

        [HttpPut("{key}")]
        public IActionResult Put(int key, [FromBody] Press press)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (key != press.PressId) return BadRequest("Key mismatch");

            var updated = _service.Update(key, press);
            if (updated == null) return NotFound();

            return Updated(updated);
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(int key)
        {
            var success = _service.Delete(key);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
