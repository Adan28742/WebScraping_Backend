using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Entities;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Infrastructure.Repositories;

namespace WebScraping_Backend.Core.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _repository;
        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _repository = tipoUsuarioRepository;
        }
        public async Task<IEnumerable<TipoUsuarioDTO>> GetAll()
        {
            var tiposUsuario = await _repository.GetAll();
            var tiposUsuarioDTO = new List<TipoUsuarioDTO>();

            foreach (var tipoUsuario in tiposUsuario)
            {
                var tipoUsuarioDTO = new TipoUsuarioDTO();
                tipoUsuarioDTO.IdTipoUsuario = tipoUsuario.IdTipoUsuario;
                tipoUsuarioDTO.Descripcion = tipoUsuario.Descripcion;

                tiposUsuarioDTO.Add(tipoUsuarioDTO);
            }
            return tiposUsuarioDTO;
        }

        public async Task<TipoUsuarioDTO?> GetById(int id)
        {
            var tipoUsuario = await _repository.GetById(id);
            if (tipoUsuario == null)
            {
                return null;
            }

            var tipoUsuarioDTO = new TipoUsuarioDTO()
            {
                IdTipoUsuario = tipoUsuario.IdTipoUsuario,
                Descripcion = tipoUsuario.Descripcion,
            };
            return tipoUsuarioDTO;
        }

        public async Task<bool> Insert(TipoUsuarioInsertDTO tipoUsuarioInsertDTO)
        {
            var tipoUsuario = new TipoUsuario();
            tipoUsuario.Descripcion = tipoUsuarioInsertDTO.Descripcion;

            var result = await _repository.Insert(tipoUsuario);
            return result;
        }

        public async Task<bool> Update(TipoUsuarioDTO tipoUsuarioDTO)
        {
            var tipoUsuario = await _repository.GetById(tipoUsuarioDTO.IdTipoUsuario);
            if (tipoUsuario == null)
                return false;
            tipoUsuario.IdTipoUsuario = tipoUsuarioDTO.IdTipoUsuario;
            tipoUsuario.Descripcion = tipoUsuarioDTO.Descripcion;

            var result = await _repository.Update(tipoUsuario);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var tipoUsuario = await _repository.GetById(id);
            if (tipoUsuario == null) return false;
            var result = await _repository.Delete(id);
            return result;
        }

    }
}
