using MediatR;

using Microsoft.EntityFrameworkCore;

using OneOf;


using Test_Backend.API.Dtos;
using Test_Backend.Application.Abstract;
using Test_Backend.Application.Abstract.Queries;
using Test_Backend.Application.Queries;
using Test_Backend.Infrastructurre;

namespace Test_Backend.Application.QueryHandlers
{
    public class ReadAdvertisementQueryHandler : QueryHandlerBase,
        IRequestHandler<ReadAdvertisementQuery, OneOf<List<AdvertisementDto>, QueryError<ReadAdvertisementQuery>>>
    {
        private readonly ApplicationContext _context;
        public ReadAdvertisementQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OneOf<List<AdvertisementDto>, QueryError<ReadAdvertisementQuery>>> Handle(ReadAdvertisementQuery request, CancellationToken cancellationToken)
        {
            return await TryAsync(request, async com =>
            {
                var models = _context.Advertisements.Include(x => x.Author).AsQueryable();

                if (!string.IsNullOrEmpty(com.FilterString))
                {
                    models = models.Where(x => x.Author.FirstName.Contains(com.FilterString)
                    || x.Author.LastName.Contains(com.FilterString)
                    || x.Title.Contains(com.FilterString));
                }
                
                var dtos = models.Select(x =>
                    new AdvertisementDto()
                    {
                        AuthorId = x.AuthorId,
                        AuthorFullName = x.Author.FirstName + " " + x.Author.LastName,
                        Title = x.Title,
                        Content = x.Content,
                        CreationDate = x.CreationDate.DateTime,
                        ModifiedDate = x.ModifiedDate.GetValueOrDefault().DateTime,
                        ActionStartDate = x.ActionStartDate.DateTime,
                        ActionEndDate = x.ActionEndDate.DateTime
                    });

                ApplySort(ref dtos, request.OrderBy);

                return await dtos.ToListAsync(cancellationToken);
            });

        }
    }
}
