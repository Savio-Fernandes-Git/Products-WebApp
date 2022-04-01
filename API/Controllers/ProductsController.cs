using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Application.Products;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAchievement([FromBody] ProductsReadWriteDto productDto)
        {
            var newProduct = await Mediator.Send(new Create.Command { ProductDto = productDto });

            return Ok(newProduct);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsListRandomOrder()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailsById(int id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpGet("price/{productId}")]
        public async Task<IActionResult> GetProductDetailsByIdWithCurrency(int productId)
        {
            return Ok(await Mediator.Send(new DetailsWithPrice.Query { Id = productId }));
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(int id, Product product)
        {
            product.ProductId = id;
            return Ok(await Mediator.Send(new Edit.Command { Product = product }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievement(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}