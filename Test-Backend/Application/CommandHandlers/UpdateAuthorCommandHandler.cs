using MediatR;

using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

using OneOf;
using Test_Backend.Application.Abstract;
using Test_Backend.Application.Abstract.Commands;
using Test_Backend.Application.Commands;
using Test_Backend.Infrastructurre;

namespace Test_Backend.Application.CommandHandlers
{
    public class UpdateAuthorCommandHandler : CommandHandlerBase,
        IRequestHandler<UpdateAuthorCommand, OneOf<string, CommandError<UpdateAuthorCommand>>>
    {
        private readonly ApplicationContext _context;
        public UpdateAuthorCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<string, CommandError<UpdateAuthorCommand>>> Handle(UpdateAuthorCommand request,
        CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {
                var author = await _context.Authors.FindAsync(com.AuthorId);

                author.FirstName = com.FirstName;
                author.LastName = com.LastName;

                _context.Authors.Attach(author);
                _context.Entry(author).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return "Success";
            });
        }
    }
}
