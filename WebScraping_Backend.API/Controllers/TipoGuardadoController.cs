using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Entities;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Core.Services;

namespace WebScraping_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGuardadoController : ControllerBase
    {
        private readonly ITipoGuardadoService _tipoGuardadoService;
        public TipoGuardadoController(ITipoGuardadoService tipoGuardadoService)
        {
            _tipoGuardadoService = tipoGuardadoService;
        }
        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var tipoGuardado = await _tipoGuardadoService.GetAll();
            return Ok(tipoGuardado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoGuardado = await _tipoGuardadoService.GetById(id);
            if (tipoGuardado == null)
            {
                return NotFound();
            }

            return Ok(tipoGuardado);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(TipoGuardadoInsertDTO tipoGuardadoInsertDTO)
        {
            var result = await _tipoGuardadoService.Insert(tipoGuardadoInsertDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Update(TipoGuardadoDTO tipoGuardadoDTO)
        {
            var result = await _tipoGuardadoService.Update(tipoGuardadoDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tipoGuardadoService.Delete(id);
            if (!result)
                return BadRequest();
            else
            {
                return Ok();
            }
            
        }
    }
}
