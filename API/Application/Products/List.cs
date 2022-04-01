using MediatR;
using API.Models;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using AutoMapper;

namespace API.Application.Products
{
    public class List
    {
        #region List for Random order requirements
        public class Query : IRequest<IOrderedEnumerable<ProductDetailsReadDto>> { }

        public class Handler : IRequestHandler<Query, IOrderedEnumerable<ProductDetailsReadDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<IOrderedEnumerable<ProductDetailsReadDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var rnd = new Random();
                var query = await _context.Products.ToListAsync();
                var result = _mapper.Map<List<ProductDetailsReadDto>>(query);

                return result.OrderBy(item => rnd.Next());
            }
        }
    }
    #endregion

    #region List for product details
    // public class List
    // {
    //     public class Query : IRequest<IOrderedEnumerable<ProductsReadWriteDto>> { }

    //     public class Handler : IRequestHandler<Query, IOrderedEnumerable<ProductsReadWriteDto>>
    //     {
    //         private readonly DataContext _context;
    //         private readonly IMapper _mapper;
    //         public Handler(DataContext context, IMapper mapper)
    //         {
    //             _mapper = mapper;
    //             _context = context;
    //         }

    //         public async Task<IOrderedEnumerable<ProductsReadWriteDto>> Handle(Query request, CancellationToken cancellationToken)
    //         {
    //             var rnd = new Random();
    //             var query = await _context.Products.ToListAsync();
    //             var result = _mapper.Map<List<ProductsReadWriteDto>>(query);

    //             return result.OrderBy(item => rnd.Next());
    //         }
    //     }
    // }
    #endregion
}