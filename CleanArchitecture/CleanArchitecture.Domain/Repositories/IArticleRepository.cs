using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Domain.Repositories
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
