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
    public class ListaGuardadoService : ILista_GuardadoService
    {
        private readonly ILista_GuardadoRepository _repository;
        public ListaGuardadoService(ILista_GuardadoRepository listaguardadoRepository)
        {
            _repository = listaguardadoRepository;
        }

        public async Task<IEnumerable<Lista_GuardadoDTO>> GetAll()
        {
            var listasguardados = await _repository.GetAll();
            var listasguardadosDTO = new List<Lista_GuardadoDTO>();
            foreach (var listaguardado in listasguardados)
            {
                var listaguardadoDTO = new Lista_GuardadoDTO();
                listaguardadoDTO.IdVideoGenerado = (int)listaguardado.IdVideoGenerado;
                listaguardadoDTO.IdUsuario = (int)listaguardado.IdUsuario;
                listaguardadoDTO.FechaCreacion = listaguardado.FechaCreacion;
                listaguardadoDTO.Estado = listaguardado.Estado;
                listaguardadoDTO.IdTipoGuardado = listaguardado.IdTipoGuardado;

                listasguardadosDTO.Add(listaguardadoDTO);
            }
            return listasguardadosDTO;
        }

        public async Task<Lista_GuardadoDTO?> GetById(int id)
        {
            var listaguardado = await _repository.GetById(id);
            if (listaguardado == null)
            {
                return null;
            }

            var listaguardadoDTO = new Lista_GuardadoDTO()
            {
                IdVideoGenerado = (int)listaguardado.IdVideoGenerado,
                IdUsuario = (int)listaguardado.IdUsuario,
                FechaCreacion = listaguardado.FechaCreacion,
                Estado = listaguardado.Estado,
                IdTipoGuardado = listaguardado.IdTipoGuardado,

            };
            return listaguardadoDTO;
        }
        public async Task<bool> Insert(Lista_GuardadoInsertDTO listaguardadoInsertDTO)
        {
            var listaguardado = new ListaGuardado();
            listaguardado.IdVideoGenerado = listaguardadoInsertDTO.IdVideoGenerado;
            listaguardado.IdUsuario = listaguardadoInsertDTO.IdUsuario;
            listaguardado.FechaCreacion = listaguardadoInsertDTO.FechaCreacion;
            listaguardado.Estado = listaguardadoInsertDTO.Estado;
            listaguardado.IdTipoGuardado = listaguardadoInsertDTO.IdTipoGuardado;


            var result = await _repository.Insert(listaguardado);
            return result;
        }
        public async Task<bool> Update(Lista_GuardadoDTO listaguardadoDTO)
        {
            var listaguardado = await _repository.GetById(listaguardadoDTO.IdVideoGenerado);
            if (listaguardado == null)
                return false;
            listaguardado.IdVideoGenerado = listaguardadoDTO.IdVideoGenerado;
            listaguardado.IdUsuario = listaguardadoDTO.IdUsuario;
            listaguardado.FechaCreacion = listaguardadoDTO.FechaCreacion;
            listaguardado.Estado = listaguardadoDTO.Estado;
            listaguardado.IdTipoGuardado = listaguardadoDTO.IdTipoGuardado;
            var result = await _repository.Update(listaguardado);
            return result;
        }
        public async Task<bool> Delete(int id)
        {
            var listaguardado = await _repository.GetById(id);
            if (listaguardado == null) return false;
            var result = await _repository.Delete(id);
            return result;
        }
    }
}
