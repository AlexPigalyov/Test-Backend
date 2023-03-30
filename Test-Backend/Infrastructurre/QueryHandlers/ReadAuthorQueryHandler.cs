﻿using MediatR;
using OneOf;
using Test_Backend.Infrastructurre.Abstract;
using Test_Backend.Application.Queries;
using Test_Backend.Application.Abstract.Queries;
using Test_Backend.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Test_Backend.Infrastructurre.QueryHandlers
{
    public class ReadAuthorQueryHandler : QueryHandlerBase,
        IRequestHandler<ReadAuthorQuery, OneOf<List<AuthorDto>, QueryError<ReadAuthorQuery>>>
    {
        private readonly ApplicationContext _context;
        public ReadAuthorQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<List<AuthorDto>, QueryError<ReadAuthorQuery>>> Handle(ReadAuthorQuery request, CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {
                return await _context.Authors.Select(x =>
                    new AuthorDto()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Rating = x.Rating
                    })
                .ToListAsync();
            });
        }
    }
}
