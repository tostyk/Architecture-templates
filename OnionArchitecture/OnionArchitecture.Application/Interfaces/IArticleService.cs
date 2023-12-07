using OnionArchitecture.Application.DTO;

namespace OnionArchitecture.Application.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleResponseDTO> GetByIdAsync(Guid id);
        Task<ICollection<ArticleResponseDTO>> GetAllAsync(int offset, int count);
        Task DeleteAsync(Guid id);
        Task<ArticleResponseDTO> UpdateAsync(Guid id, ArticleRequestDTO input);
        Task<ArticleResponseDTO> CreateAsync(ArticleRequestDTO input);
    }
}
