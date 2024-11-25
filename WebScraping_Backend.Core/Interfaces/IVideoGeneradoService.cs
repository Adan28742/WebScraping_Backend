using WebScraping_Backend.Core.DTOs;

namespace WebScraping_Backend.Core.Interfaces;


    public interface IVideoGeneradoService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<VideoGeneradoDTO>> GetAll();
        Task<VideoGeneradoDTO> GetById(int id);
        Task<bool> Insert(VideoGeneradoInsertDTO videogeneradoInsertDTO);
        Task<bool> Update(VideoGeneradoDTO videogeneradoDTO);
    }

