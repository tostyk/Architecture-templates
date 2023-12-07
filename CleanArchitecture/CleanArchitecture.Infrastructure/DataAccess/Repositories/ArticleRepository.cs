using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Repositories;
using OnionArchitecture.Infrastructure.DataAccess.Context;

namespace OnionArchitecture.Infrastructure.DataAccess.Repositories
{
    public class ArticleRepository(AppDBContext dbContext) : IArticleRepository
    {
        private readonly AppDBContext _dbContext = dbContext;

        public async Task<Article> CreateAsync(Article entity)
        {
            await _dbContext.Articles.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            Article entity = await _dbContext.Articles.FindAsync(id);
            _dbContext.Articles.Remove(entity);
        }

        public async Task<List<Article>> GetAllAsync(int offset, int count)
        {
            return await _dbContext.Articles
                .AsNoTracking()
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Articles
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Article Update(Article entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
