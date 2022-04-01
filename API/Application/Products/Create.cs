using API.DTOs;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Products
{
    public class Create
    {
        public class Command : IRequest
        {
            public ProductsReadWriteDto ProductDto { get; set; }
            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                public Handler(DataContext context)
                {
                    _context = context;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    var category = await _context.Categories.Where(x => x.Categoryid == request.ProductDto.CategoryId).FirstOrDefaultAsync();

                    var product = new Product
                    {
                        Name = request.ProductDto.Name,
                        Price = request.ProductDto.Price,
                        ImageUrl = request.ProductDto.ImageUrl,
                        Category = category
                    };
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    return Unit.Value;
                }
            }
        }
    }
}