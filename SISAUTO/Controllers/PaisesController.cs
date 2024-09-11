using DB;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SISAUTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly PaisesService _paisesService;
        public PaisesController(PaisesService paisesService)
        {
            _paisesService = paisesService;
        }

        // GET: api/<PaisesController>
        //Proteger URL (Authorize)
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Paises>>> Get()
        {   //Llamar a mi servicio
            return Ok(await _paisesService.GetAll());
        }

        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paises>> Get(int id)
        {
            return Ok(await _paisesService.GetById(id));
        }

        // POST api/<PaisesController>
        [HttpPost]
        public async Task<IActionResult> Post(Paises pais)
        {
            return Ok(await _paisesService.Create(pais));
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Paises pais)
        {
            return Ok(await _paisesService.Update(pais));
        }

        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _paisesService.Delete(id));
        }
    }
}
