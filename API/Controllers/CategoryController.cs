using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Application.Categories;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAchievement([FromBody] Category category)
        {
            return Ok(await Mediator.Send(new Create.Command { Category = category }));
        }
    }
}