using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using AutoMapper;
using MediatR;

namespace API.Application.Categories
{
    public class Create
    {
        public class Command : IRequest
        {
            public CategoriesReadWriteDto CategoryDto { get; set; }
            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                private readonly IMapper _mapper;
                public Handler(DataContext context)
                {
                    _context = context;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    var category = new Category{
                        CategoryName = request.CategoryDto.CategoryName
                    };
                    
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();

                    return Unit.Value;
                }
            }
        }
    }
}