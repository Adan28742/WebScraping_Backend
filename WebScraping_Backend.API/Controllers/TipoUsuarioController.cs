using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Core.Services;

namespace WebScraping_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _service;
        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            _service = tipoUsuarioService;
        }
        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var tipoUsuarios = await _service.GetAll();
            return Ok(tipoUsuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoUsuario = await _service.GetById(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return Ok(tipoUsuario);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(TipoUsuarioInsertDTO tipoUsuarioInsertDTO)
        {
            var result = await _service.Insert(tipoUsuarioInsertDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Update(TipoUsuarioDTO tipoUsuarioDTO)
        {
            var result = await _service.Update(tipoUsuarioDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
