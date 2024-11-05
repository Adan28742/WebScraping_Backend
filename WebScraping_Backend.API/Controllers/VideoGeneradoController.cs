using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Core.Services;

namespace WebScraping_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGeneradoController : ControllerBase
    {
        private readonly IVideoGeneradoService _videogeneradoService;
        public VideoGeneradoController(IVideoGeneradoService videogeneradoService)
        {
            _videogeneradoService = videogeneradoService;
        }
        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var videogenerado = await _videogeneradoService.GetAll();
            return Ok(videogenerado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var videogenerado = await _videogeneradoService.GetById(id);
            if (videogenerado == null)
            {
                return NotFound();
            }

            return Ok(videogenerado);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(VideoGeneradoInsertDTO videogeneradoInsertDTO)
        {
            var result = await _videogeneradoService.Insert(videogeneradoInsertDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Update(VideoGeneradoDTO videogeneradoDTO)
        {
            var result = await _videogeneradoService.Update(videogeneradoDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _videogeneradoService.Delete(id);
            if (!result)
                return BadRequest();
            return Ok();
        }
    }
}
