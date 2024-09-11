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
    public class DetalleOrdenesController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly DetalleOrdenesService _detalleDetalleOrdenesService;
        public DetalleOrdenesController(DetalleOrdenesService detalleDetalleOrdenesService)
        {
            _detalleDetalleOrdenesService = detalleDetalleOrdenesService;
        }

        // GET: api/<DetalleOrdenesController>
        //Proteger URL (Authorize)
        [HttpGet]
        //Ruta protegida por Cors
        //[EnableCors("AllowSpecificOrings")]
        public async Task<ActionResult<IEnumerable<DetalleOrdenes>>> Get()
        {   //Llamar a mi servicio
            return Ok(await _detalleDetalleOrdenesService.GetAll());
        }

        // GET api/<DetalleOrdenesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrdenes>> Get(int id)
        {
            return Ok(await _detalleDetalleOrdenesService.GetById(id));
        }

        // POST api/<DetalleOrdenesController>
        [HttpPost]
        public async Task<IActionResult> Post(DetalleOrdenes pais)
        {
            return Ok(await _detalleDetalleOrdenesService.Create(pais));
        }

        // PUT api/<DetalleOrdenesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DetalleOrdenes pais)
        {
            return Ok(await _detalleDetalleOrdenesService.Update(pais));
        }

        // DELETE api/<DetalleOrdenesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _detalleDetalleOrdenesService.Delete(id));
        }
    }
}
