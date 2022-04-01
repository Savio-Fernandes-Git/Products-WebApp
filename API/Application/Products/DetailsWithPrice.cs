using API.DTOs;
using API.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Products
{
    public class DetailsWithPrice
    {
        public class Query : IRequest<List<ProductDetailsReadPriceDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<ProductDetailsReadPriceDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<ProductDetailsReadPriceDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var query = await _context.Products
                        .FromSqlInterpolated($"EXEC GetItemDetails {request.Id}")
                        .ToListAsync();

                    return _mapper.Map<List<ProductDetailsReadPriceDto>>(query);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}