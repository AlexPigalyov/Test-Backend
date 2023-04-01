using MediatR;

using OneOf;
using Test_Backend.Application.Abstract;
using Test_Backend.Application.Abstract.Commands;
using Test_Backend.Application.Commands;
using Test_Backend.Infrastructurre;

namespace Test_Backend.Application.CommandHandlers
{
    public class RemoveAdvertisementCommandHandler : CommandHandlerBase,
        IRequestHandler<RemoveAdvertisementCommand, OneOf<string, CommandError<RemoveAdvertisementCommand>>>
    {
        private readonly ApplicationContext _context;
        public RemoveAdvertisementCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<string, CommandError<RemoveAdvertisementCommand>>> Handle(RemoveAdvertisementCommand request,
        CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {
                var advertisement = await _context.Advertisements.FindAsync(com.AdvertisementId);

                _context.Remove(advertisement);

                await _context.SaveChangesAsync();

                return "Success";
            });
        }
    }
}
