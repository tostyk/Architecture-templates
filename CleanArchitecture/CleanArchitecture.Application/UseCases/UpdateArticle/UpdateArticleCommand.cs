using MediatR;
using OnionArchitecture.Application.DTO;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class UpdateArticleCommand(Guid id, ArticleRequestDTO article) : IRequest<ArticleResponseDTO>
    {
        public Guid Id { get; set; } = id;
        public ArticleRequestDTO Article { get; set; } = article;
    }
}
