using MediatR;

using OneOf;

using Test_Backend.Application.Abstract.Commands;
using Test_Backend.Application.Commands;
using Test_Backend.Infrastructurre.Abstract;

namespace Test_Backend.Infrastructurre.CommandHandlers
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
                    ActionStartDate = DateTime.SpecifyKind(com.ActionStartDate, DateTimeKind.Utc),
                    ActionEndDate = DateTime.SpecifyKind(com.ActionEndDate, DateTimeKind.Utc),
                    CreationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    ModifiedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                });

                await _context.SaveChangesAsync();

                return "Success";
            });
        }
    }
}
