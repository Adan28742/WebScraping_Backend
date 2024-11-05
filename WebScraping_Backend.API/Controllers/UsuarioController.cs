using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Interfaces;

namespace WebScraping_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UsuarioAuthenticationDTO usuarioAuthenticationDTO)
        {
            var result = await _usuarioService.Validate(usuarioAuthenticationDTO.Email, usuarioAuthenticationDTO.Password);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UsuarioAuthRequestDTO usuarioAuthRequestDTO)
        {
            var result = await _usuarioService.Register(usuarioAuthRequestDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var search = await _usuarioService.GetAll();
            return Ok(search);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var search = await _usuarioService.GetById(id);
            return Ok(search);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            bool update = await _usuarioService.UpdateUser(usuarioDTO);
            return Ok(update);
        }
        [HttpPut("Actual_Contraseña")]
        public async Task<IActionResult> UpdatePassword(UsuarioUpdatePassDTO usuarioUpdatePassDTO)
        {
            bool update = await _usuarioService.UpdatePassword(usuarioUpdatePassDTO);
            if (update)
            {
                return Ok(update);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usuarioService.Delete(id);
            return Ok(result);
        }
     }
}
