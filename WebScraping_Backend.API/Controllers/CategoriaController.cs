using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Core.Services;

namespace WebScraping_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var categoria = await _categoriaService.GetAll();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(CategoriaInsertDTO categoriaInsertDTO)
        {
            var result = await _categoriaService.Insert(categoriaInsertDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Update(CategoriaDTO categoriaDTO)
        {
            var result = await _categoriaService.Update(categoriaDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoriaService.Delete(id);
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
