using API.Application.Categories;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAchievement([FromBody] CategoriesReadWriteDto categoryDto)
        {
            return Ok(await Mediator.Send(new Create.Command { CategoryDto = categoryDto }));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }
    }
}