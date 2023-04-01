using MediatR;

using OneOf;
using Test_Backend.Application.Abstract;
using Test_Backend.Application.Abstract.Commands;
using Test_Backend.Application.Commands;
using Test_Backend.Infrastructurre;

namespace Test_Backend.Application.CommandHandlers
{
    public class RemoveAuthorCommandHandler : CommandHandlerBase,
        IRequestHandler<RemoveAuthorCommand, OneOf<string, CommandError<RemoveAuthorCommand>>>
    {
        private readonly ApplicationContext _context;
        public RemoveAuthorCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<string, CommandError<RemoveAuthorCommand>>> Handle(RemoveAuthorCommand request,
        CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {
                var author = await _context.Authors.FindAsync(com.AuthorId);

                _context.Remove(author);

                await _context.SaveChangesAsync();

                return "Success";
            });
        }
    }
}
