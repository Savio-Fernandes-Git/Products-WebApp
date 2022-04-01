using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Products
{
    public class Details
    {
        public class Query : IRequest<ProductDetailsReadDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDetailsReadDto>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<ProductDetailsReadDto> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = await _context.Products.Include(x => x.Category).Where(x => x.ProductId == request.Id).FirstOrDefaultAsync();

                    return new ProductDetailsReadDto()
                    {
                        Name = query.Name,
                        Description = query.Description,
                        CategoryName = query.Category.CategoryName
                    };
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}