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
    public class ClientesController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly ClientesService _clientesService;
        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        // GET: api/<ClientesController>
        //Proteger URL (Authorize)
        [HttpGet]
        //Ruta protegida por Cors
        //[EnableCors("AllowSpecificOrings")]
        public async Task<ActionResult<IEnumerable<Clientes>>> Get()
        {   //Llamar a mi servicio
            return Ok(await _clientesService.GetAll());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Get(int id)
        {
            return Ok(await _clientesService.GetById(id));
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post(Clientes pais)
        {
            return Ok(await _clientesService.Create(pais));
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Clientes pais)
        {
            return Ok(await _clientesService.Update(pais));
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _clientesService.Delete(id));
        }
    }
}
