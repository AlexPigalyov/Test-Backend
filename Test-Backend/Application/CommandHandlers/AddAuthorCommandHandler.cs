using MediatR;

using OneOf;
using Test_Backend.Application.Abstract;
using Test_Backend.Application.Abstract.Commands;
using Test_Backend.Application.Commands;
using Test_Backend.Infrastructurre;

namespace Test_Backend.Application.CommandHandlers
{
    public class AddAuthorCommandHandler : CommandHandlerBase,
        IRequestHandler<AddAuthorCommand, OneOf<string, CommandError<AddAuthorCommand>>>
    {
        private readonly ApplicationContext _context;
        public AddAuthorCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<string, CommandError<AddAuthorCommand>>> Handle(AddAuthorCommand request,
        CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {
                await _context.AddAsync(new Domain.Models.AuthorModel
                {
                    FirstName = com.FirstName,
                    LastName = com.LastName,
                    Rating = 0
                });

                await _context.SaveChangesAsync();

                return "Success";
            });
        }
    }
}
