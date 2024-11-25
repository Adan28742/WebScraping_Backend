using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Entities;
using WebScraping_Backend.Core.Interfaces;

namespace WebScraping_Backend.Core.Services
{
    public class TipoGuardadoService : ITipoGuardadoService
    {
        private readonly ITipoGuardadoRepository _repository;
        public TipoGuardadoService(ITipoGuardadoRepository tipoGuardadoRepository)
        {
            _repository = tipoGuardadoRepository;
        }

        public async Task<IEnumerable<TipoGuardadoDTO>> GetAll()
        {
            var tipoGuardados = await _repository.GetAll();
            var tipoGuardadosDTO = new List<TipoGuardadoDTO>();
            foreach (var tipoGuardado in tipoGuardados)
            {
                var tipoGuardadoDTO = new TipoGuardadoDTO();
                tipoGuardadoDTO.IdTipoGuardado = tipoGuardado.IdTipoGuardado;
                tipoGuardadoDTO.Descripcion = tipoGuardado.Descripcion;

                tipoGuardadosDTO.Add(tipoGuardadoDTO);
            }
            return tipoGuardadosDTO;
        }

        public async Task<TipoGuardadoDTO?> GetById(int id)
        {
            var tipoGuardado = await _repository.GetById(id);
            if (tipoGuardado == null)
            {
                return null;
            }

            var tipoGuardadoDTO = new TipoGuardadoDTO()
            {
                IdTipoGuardado = tipoGuardado.IdTipoGuardado,
                Descripcion = tipoGuardado.Descripcion,
            };
            return tipoGuardadoDTO;
        }

        public async Task<bool> Insert(TipoGuardadoInsertDTO tipoGuardadoInsertDTO)
        {
            var tipoGuardado = new TipoGuardado();
            tipoGuardado.Descripcion = tipoGuardadoInsertDTO.Descripcion;

            var result = await _repository.Insert(tipoGuardado);
            return result;
        }

        public async Task<bool> Update(TipoGuardadoDTO tipoGuardadoDTO)
        {
            var tipoGuardado = await _repository.GetById(tipoGuardadoDTO.IdTipoGuardado);
            if (tipoGuardado == null)
                return false;
            tipoGuardado.IdTipoGuardado = tipoGuardadoDTO.IdTipoGuardado;
            tipoGuardado.Descripcion = tipoGuardadoDTO.Descripcion;

            var result = await _repository.Update(tipoGuardado);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var tipoGuardado = await _repository.GetById(id);
            if (tipoGuardado == null) return false;
            var result = await _repository.Delete(id);
            return result;
        }

    }
}
