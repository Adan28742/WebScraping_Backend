using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Core.Services;

namespace WebScraping_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaGuardadoController : ControllerBase
    {
        private readonly ILista_GuardadoService _listaguardadoService;
        public ListaGuardadoController(ILista_GuardadoService listaguardadoService)
        {
            _listaguardadoService = listaguardadoService;
        }
        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var listaguardadoService = await _listaguardadoService.GetAll();
            return Ok(listaguardadoService);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var listaguardado = await _listaguardadoService.GetById(id);
            if (listaguardado == null)
            {
                return NotFound();
            }

            return Ok(listaguardado);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Lista_GuardadoInsertDTO listaguardadoInsertDTO)
        {
            var result = await _listaguardadoService.Insert(listaguardadoInsertDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Update(Lista_GuardadoDTO listaguardadoDTO)
        {
            var result = await _listaguardadoService.Update(listaguardadoDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _listaguardadoService.Delete(id);
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
