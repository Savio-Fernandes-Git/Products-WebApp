using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Products
{
    public class DetailsWithPrice
    {
        public class Query : IRequest<ProductDetailsReadPriceDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDetailsReadPriceDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ProductDetailsReadPriceDto> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = await _context.Products
                        .FromSqlInterpolated<Product>($"EXECUTE [dbo].GetItemDetails {request.Id}")
                        .Select( x => new ProductDetailsReadPriceDto{
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Currency = x.Currency
                        }).FirstOrDefaultAsync();

                    return query;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}