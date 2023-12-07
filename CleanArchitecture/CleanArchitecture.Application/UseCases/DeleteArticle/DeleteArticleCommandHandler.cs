using MediatR;
using OnionArchitecture.Application.Exceptions;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.UseCases.DeleteArticle
{
    public class DeleteArticleCommandHandler(IArticleRepository articleRepository)
        : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository = articleRepository;

        public async Task Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            Article? article = await _articleRepository.GetByIdAsync(request.ArticleId);

            if (article == null)
            {
                throw new NotFoundException("Article");
            }

            await _articleRepository.DeleteAsync(request.ArticleId);
            await _articleRepository.SaveChangesAsync();
        }
    }
}
