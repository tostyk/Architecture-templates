using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteArticle
{
    public class DeleteArticleCommand(Guid articleId) : IRequest
    {
        public Guid ArticleId { get; set; } = articleId;
    }
}
