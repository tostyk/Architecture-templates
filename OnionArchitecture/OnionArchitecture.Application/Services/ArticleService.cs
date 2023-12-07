using AutoMapper;
using OnionArchitecture.Application.DTO;
using OnionArchitecture.Application.Exceptions;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Domain.Core;
using OnionArchitecture.Domain.Interfaces;

namespace OnionArchitecture.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapping;

        public ArticleService(IArticleRepository articleRepository, IMapper mapping)
        {
            _articleRepository = articleRepository;
            _mapping = mapping;
        }

        public async Task<ArticleResponseDTO> CreateAsync(ArticleRequestDTO articleRequestDTO)
        {
            Article article = _mapping.Map<Article>(articleRequestDTO);

            article.Id = Guid.NewGuid();
            article.CreatedOnUtc = DateTime.UtcNow;

            article = await _articleRepository.CreateAsync(article);
            await _articleRepository.SaveChangesAsync();
            ArticleResponseDTO response = _mapping.Map<ArticleResponseDTO>(article);

            return response;
        }

        public async Task DeleteAsync(Guid id)
        {
            Article? article = await _articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                throw new NotFoundException("Article");
            }

            await _articleRepository.DeleteAsync(id);
            await _articleRepository.SaveChangesAsync();
        }

        public async Task<ICollection<ArticleResponseDTO>> GetAllAsync(int offset, int count)
        {
            List<Article> articles = await _articleRepository.GetAllAsync(offset, count);
            List<ArticleResponseDTO> response = _mapping.Map<List<Article>, List<ArticleResponseDTO>>(articles);

            return response;
        }

        public async Task<ArticleResponseDTO> GetByIdAsync(Guid id)
        {
            Article? article = await _articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                throw new NotFoundException("Article");
            }

            ArticleResponseDTO response = _mapping.Map<ArticleResponseDTO>(article);

            return response;
        }

        public async Task<ArticleResponseDTO> UpdateAsync(Guid id, ArticleRequestDTO input)
        {
            Article? article = await _articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                throw new NotFoundException("Article");
            }

            _mapping.Map(input, article);

            article = _articleRepository.Update(article);
            await _articleRepository.SaveChangesAsync();

            ArticleResponseDTO response = _mapping.Map<ArticleResponseDTO>(article);

            return response;
        }
    }
}
