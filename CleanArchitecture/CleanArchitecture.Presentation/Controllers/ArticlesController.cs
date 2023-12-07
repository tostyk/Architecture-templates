using CleanArchitecture.Application.UseCases.CreateArticle;
using CleanArchitecture.Application.UseCases.DeleteArticle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.DTO;
using OnionArchitecture.Presentation.Middleware;

namespace OnionArchitecture.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesErrorResponseType(typeof(ErrorMessage))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ArticleController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ArticleResponseDTO>))]
        public async Task<IActionResult> GetAllAsync(int offset, int count)
        {
            List<ArticleResponseDTO> articleResponseDTOs = await _sender.Send(new GetAllArticlesQuery(offset, count));

            return Ok(articleResponseDTOs);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _sender.Send(new GetArticleByIdQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync(ArticleRequestDTO articleRequestDTO)
        {
            ArticleResponseDTO articleResponseDTO = await _sender.Send(new CreateArticleCommand(articleRequestDTO));

            return CreatedAtAction(nameof(GetAsync), new { id = articleResponseDTO.Id }, null);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync(Guid id, ArticleRequestDTO articleRequestDTO)
        {
            await _sender.Send(new UpdateArticleCommand(id, articleRequestDTO));

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _sender.Send(new DeleteArticleCommand(id));

            return NoContent();
        }
    }
}
