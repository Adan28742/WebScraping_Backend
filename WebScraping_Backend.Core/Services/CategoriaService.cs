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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _repository = categoriaRepository;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            var categories = await _repository.GetAll();
            var categoriasDTO = new List<CategoriaDTO>();
            foreach (var category in categories)
            {
                var categoriaDTO = new CategoriaDTO();
                categoriaDTO.IdCategoria = category.IdCategoria;
                categoriaDTO.Descripcion = category.Descripcion;

                categoriasDTO.Add(categoriaDTO);
            }
            return categoriasDTO;
        }

        public async Task<CategoriaDTO?> GetById(int id)
        {
            var categoria = await _repository.GetById(id);
            if (categoria == null)
            {
                return null;
            }

            var categoriaDTO = new CategoriaDTO()
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion,
            };
            return categoriaDTO;
        }
        public async Task<bool> Insert(CategoriaInsertDTO categoriaInsertDTO)
        {
            var categoria = new Categoria();
            categoria.Descripcion = categoriaInsertDTO.Descripcion;

            var result = await _repository.Insert(categoria);
            return result;
        }
        public async Task<bool> Update(CategoriaDTO categoriaDTO)
        {
            var categoria = await _repository.GetById(categoriaDTO.IdCategoria);
            if (categoria == null)
                return false;
            categoria.IdCategoria = categoriaDTO.IdCategoria;
            categoria.Descripcion = categoriaDTO.Descripcion;

            var result = await _repository.Update(categoria);
            return result;
        }
        public async Task<bool> Delete(int id)
        {
            var categoria = await _repository.GetById(id);
            if (categoria == null) return false;
            var result = await _repository.Delete(id);
            return result;
        }
    }
}
