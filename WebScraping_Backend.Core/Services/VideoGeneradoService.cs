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
    public class VideoGeneradoService : IVideoGeneradoService
    {
        private readonly IVideoGeneradoRepository _repository;
        public VideoGeneradoService(IVideoGeneradoRepository videogeneradoRepository)
        {
            _repository = videogeneradoRepository;
        }

        public async Task<IEnumerable<VideoGeneradoDTO>> GetAll()
        {
            var videogenerados = await _repository.GetAll();
            var videogeneradosDTO = new List<VideoGeneradoDTO>();
            foreach (var videogenerado in videogenerados)
            {
                var videogeneradoDTO = new VideoGeneradoDTO();
                videogeneradoDTO.IdVideoGenerado = videogenerado.IdVideoGenerado;
                videogeneradoDTO.IdCategoria = videogenerado.IdCategoria;
                videogeneradoDTO.FechaCreacion = videogenerado.FechaCreacion; 
                videogeneradoDTO.Estado = videogenerado.Estado;
                videogeneradoDTO.Duracion = videogenerado.Duracion;

                videogeneradosDTO.Add(videogeneradoDTO);
            }
            return videogeneradosDTO;
        }

        public async Task<VideoGeneradoDTO?> GetById(int id)
        {
            var videogenerado = await _repository.GetById(id);
            if (videogenerado == null)
            {
                return null;
            }

            var videogeneradoDTO = new VideoGeneradoDTO()
            {
                IdVideoGenerado = videogenerado.IdVideoGenerado,
                IdCategoria = videogenerado.IdCategoria,
                FechaCreacion = videogenerado.FechaCreacion,
                Estado = videogenerado.Estado,
                Duracion = videogenerado.Duracion,
            };
            return videogeneradoDTO;
        }
        public async Task<bool> Insert(VideoGeneradoInsertDTO videogeneradoInsertDTO)
        {
            var videogenerado = new VideoGenerado();
            videogenerado.IdCategoria = videogeneradoInsertDTO.IdCategoria;
            videogenerado.FechaCreacion = videogeneradoInsertDTO.FechaCreacion;
            videogenerado.Estado = videogeneradoInsertDTO.Estado;
            videogenerado.Duracion = videogeneradoInsertDTO.Duracion;

            var result = await _repository.Insert(videogenerado);
            return result;
        }
        public async Task<bool> Update(VideoGeneradoDTO videogeneradoDTO)
        {
            var videogenerado = await _repository.GetById(videogeneradoDTO.IdVideoGenerado);
            if (videogenerado == null)
                return false;
            videogenerado.IdCategoria = videogeneradoDTO.IdCategoria;
            videogenerado.FechaCreacion = videogeneradoDTO.FechaCreacion;
            videogenerado.Estado = videogeneradoDTO.Estado;
            videogenerado.Duracion = videogeneradoDTO.Duracion;

            var result = await _repository.Update(videogenerado);
            return result;
        }
        public async Task<bool> Delete(int id)
        {
            var videogenerado = await _repository.GetById(id);
            if (videogenerado == null) return false;
            var result = await _repository.Delete(id);
            return result;
        }
    }
}
