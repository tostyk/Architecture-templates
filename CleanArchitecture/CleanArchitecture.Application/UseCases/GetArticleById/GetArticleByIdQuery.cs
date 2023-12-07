using MediatR;
using OnionArchitecture.Application.DTO;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class GetArticleByIdQuery(Guid articleId) : IRequest<ArticleResponseDTO>
    {
        public Guid ArticleId { get; set; } = articleId;
    }
}
