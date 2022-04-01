using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Application.Categories;
using API.DTOs;
using API.Models;
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