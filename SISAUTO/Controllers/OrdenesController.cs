using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Metodo protegido por Cors
    [EnableCors("AllowSpecificOrings")]
    public class OrdenesController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly OrdenesService _ordenesService;
        public OrdenesController(OrdenesService ordenesService)
        {
            _ordenesService = ordenesService;
        }

        // GET: api/<OrdenesController>
        //Proteger URL (Authorize)
        [HttpGet]
        //Ruta protegida por Cors
        //[EnableCors("AllowSpecificOrings")]
        public async Task<ActionResult<IEnumerable<Ordenes>>> Get()
        {   //Llamar a mi servicio
            return Ok(await _ordenesService.GetAll());
        }

        // GET api/<OrdenesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> Get(int id)
        {
            return Ok(await _ordenesService.GetById(id));
        }

        // POST api/<OrdenesController>
        [HttpPost]
        public async Task<IActionResult> Post(Ordenes pais)
        {
            return Ok(await _ordenesService.Create(pais));
        }

        // PUT api/<OrdenesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ordenes pais)
        {
            return Ok(await _ordenesService.Update(pais));
        }

        // DELETE api/<OrdenesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _ordenesService.Delete(id));
        }
    }
}
