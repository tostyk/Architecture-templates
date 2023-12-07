using OnionArchitecture.Domain.Core;

namespace OnionArchitecture.Domain.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> GetByIdAsync(Guid id);
        Task<List<Article>> GetAllAsync(int count, int offset);
        Task<Article> CreateAsync(Article article);
        Task DeleteAsync(Guid id);
        Article Update(Article article);
        Task SaveChangesAsync();
    }
}
