using AutoMapper;
using MediatR;
using OnionArchitecture.Application.DTO;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class CreateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapping)
        : IRequestHandler<CreateArticleCommand, ArticleResponseDTO>
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IMapper _mapping = mapping;

        public async Task<ArticleResponseDTO> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            Article article = _mapping.Map<Article>(request.Article);

            article.Id = Guid.NewGuid();
            article.CreatedOnUtc = DateTime.UtcNow;

            article = await _articleRepository.CreateAsync(article);
            await _articleRepository.SaveChangesAsync();
            ArticleResponseDTO output = _mapping.Map<ArticleResponseDTO>(article);

            return output;
        }
    }
}
