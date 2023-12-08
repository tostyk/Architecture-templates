using OnionArchitecture.Services.Interfaces.DTO;

namespace OnionArchitecture.Services.Interfaces
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
