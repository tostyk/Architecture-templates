using AutoMapper;
using MediatR;
using OnionArchitecture.Application.DTO;
using OnionArchitecture.Application.Exceptions;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class UpdateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapping)
        : IRequestHandler<UpdateArticleCommand, ArticleResponseDTO>
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IMapper _mapping = mapping;

        public async Task<ArticleResponseDTO> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            Article? article = await _articleRepository.GetByIdAsync(request.Id);

            if (article == null)
            {
                throw new NotFoundException("Article");
            }

            _mapping.Map(request.Article, article);

            article = _articleRepository.Update(article);
            await _articleRepository.SaveChangesAsync();

            ArticleResponseDTO output = _mapping.Map<ArticleResponseDTO>(article);

            return output;
        }
    }
}
