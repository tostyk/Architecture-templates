using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Presentation.Middleware;
using OnionArchitecture.Services.Interfaces;
using OnionArchitecture.Services.Interfaces.DTO;

namespace OnionArchitecture.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesErrorResponseType(typeof(ErrorMessage))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ArticleController(IArticleService articleService) : ControllerBase
    {
        private readonly IArticleService _articleService = articleService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ArticleResponseDTO>))]
        public async Task<IActionResult> GetAllAsync(int offset, int count)
        {
            return Ok(await _articleService.GetAllAsync(offset, count));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _articleService.GetByIdAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync(ArticleRequestDTO articleRequestDTO)
        {
            ArticleResponseDTO articleResponseDTO = await _articleService.CreateAsync(articleRequestDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = articleResponseDTO.Id }, null);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync(Guid id, ArticleRequestDTO articleRequestDTO)
        {
            await _articleService.UpdateAsync(id, articleRequestDTO);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _articleService.DeleteAsync(id);

            return NoContent();
        }
    }
}
