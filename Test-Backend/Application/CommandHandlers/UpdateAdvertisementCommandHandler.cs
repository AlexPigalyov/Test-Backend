using MediatR;

using Microsoft.EntityFrameworkCore;

using OneOf;
using Test_Backend.Application.Abstract;
using Test_Backend.Application.Abstract.Commands;
using Test_Backend.Application.Commands;
using Test_Backend.Infrastructurre;

namespace Test_Backend.Application.CommandHandlers
{
    public class UpdateAdvertisementCommandHandler : CommandHandlerBase,
        IRequestHandler<UpdateAdvertisementCommand, OneOf<string, CommandError<UpdateAdvertisementCommand>>>
    {
        private readonly ApplicationContext _context;
        public UpdateAdvertisementCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<string, CommandError<UpdateAdvertisementCommand>>> Handle(UpdateAdvertisementCommand request,
        CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {
                var advertisement = await _context.Advertisements.FindAsync(com.AdvertisementId);

                advertisement.ActionStartDate = com.ActionStartDate;
                advertisement.ActionEndDate = com.ActionEndDate;
                advertisement.ModifiedDate = DateTime.Now;
                advertisement.Title = com.Title;
                advertisement.Content = com.Content;

                _context.Advertisements.Attach(advertisement);
                _context.Entry(advertisement).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return "Success";
            });
        }
    }
}
