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
    public class ServiciosController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly ServiciosService _serviciosService;
        public ServiciosController(ServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }

        // GET: api/<ServiciosController>
        //Proteger URL (Authorize)
        [HttpGet]
        //Ruta protegida por Cors
        //[EnableCors("AllowSpecificOrings")]
        public async Task<ActionResult<IEnumerable<Servicios>>> Get()
        {   //Llamar a mi servicio
            return Ok(await _serviciosService.GetAll());
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicios>> Get(int id)
        {
            return Ok(await _serviciosService.GetById(id));
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public async Task<IActionResult> Post(Servicios pais)
        {
            return Ok(await _serviciosService.Create(pais));
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Servicios pais)
        {
            return Ok(await _serviciosService.Update(pais));
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _serviciosService.Delete(id));
        }
    }
}
