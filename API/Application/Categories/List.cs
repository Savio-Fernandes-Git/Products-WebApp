using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Categories
{
    public class List
    {
        public class Query : IRequest<List<CategoriesReadWriteDto>> { }

        public class Handler : IRequestHandler<Query, List<CategoriesReadWriteDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<CategoriesReadWriteDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.Categories.ToListAsync();

                return _mapper.Map<List<CategoriesReadWriteDto>>(query);
            }
        }
    }
}