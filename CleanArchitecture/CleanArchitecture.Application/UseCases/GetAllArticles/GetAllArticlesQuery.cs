using MediatR;
using OnionArchitecture.Application.DTO;

namespace CleanArchitecture.Application.UseCases.CreateArticle
{
    public class GetAllArticlesQuery(int offset, int count) : IRequest<List<ArticleResponseDTO>>
    {
        public int Offset { get; set; } = offset;
        public int Count { get; set; } = count;
    }
}
