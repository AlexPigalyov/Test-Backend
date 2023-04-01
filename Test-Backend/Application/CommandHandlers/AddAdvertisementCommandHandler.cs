using MediatR;

using OneOf;

using Test_Backend.Application.Abstract;
using Test_Backend.Application.Abstract.Commands;
using Test_Backend.Application.Commands;
using Test_Backend.Infrastructurre;

namespace Test_Backend.Application.CommandHandlers
{
    public class AddAdvertisementCommandHandler : CommandHandlerBase,
        IRequestHandler<AddAdvertisementCommand, OneOf<string, CommandError<AddAdvertisementCommand>>>
    {
        private readonly ApplicationContext _context;
        public AddAdvertisementCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<string, CommandError<AddAdvertisementCommand>>> Handle(AddAdvertisementCommand request,
        CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {

                var author = await _context.Authors.FindAsync(com.AuthorId);

                await _context.Advertisements.AddAsync(new Domain.Models.AdvertisementModel()
                {
                    AuthorId = author.AuthorId,
                    Title = com.Title,
                    Content = com.Content,
                    ActionStartDate = com.ActionStartDate,
                    ActionEndDate = com.ActionEndDate,
                    CreationDate = DateTime.Now,
                });

                await _context.SaveChangesAsync();

                return "Success";
            });
        }
    }
}
