using MediatR;
using OnionArchitecture.Application.DTO;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class CreateArticleCommand(ArticleRequestDTO article) : IRequest<ArticleResponseDTO>
    {
        public ArticleRequestDTO Article { get; set; } = article;
    }
}
