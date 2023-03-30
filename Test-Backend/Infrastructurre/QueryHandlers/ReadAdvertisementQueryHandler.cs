using MediatR;

using Microsoft.EntityFrameworkCore;

using OneOf;

using Test_Backend.Application;
using Test_Backend.Application.Abstract.Queries;
using Test_Backend.Application.Queries;
using Test_Backend.Domain.Dtos;
using Test_Backend.Domain.Models;
using Test_Backend.Infrastructurre.Abstract;

namespace Test_Backend.Infrastructurre.QueryHandlers
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
                    ||  x.Author.LastName.Contains(com.FilterString) 
                    || x.Title.Contains(com.FilterString));
                }

                IOrderedQueryable<AdvertisementModel> filteredModels;

                switch (com.SortOrder)
                {
                    case AdvertisementSortState.AuthorAsc:
                        filteredModels = models.OrderBy(s => s.Author.FirstName);
                        break;
                    case AdvertisementSortState.AuthorDesc:
                        filteredModels = models.OrderByDescending(s => s.Author.FirstName);
                        break;
                    case AdvertisementSortState.ContentAsc:
                        filteredModels = models.OrderBy(s => s.Content);
                        break;
                    case AdvertisementSortState.ContentDesc:
                        filteredModels = models.OrderByDescending(s => s.Content);
                        break;
                    case AdvertisementSortState.TitleAsc:
                        filteredModels = models.OrderBy(s => s.Title);
                        break;
                    case AdvertisementSortState.TitleDesc:
                        filteredModels = models.OrderByDescending(s => s.Title);
                        break;
                    case AdvertisementSortState.CreationDateAsc:
                        filteredModels = models.OrderBy(s => s.CreationDate);
                        break;
                    case AdvertisementSortState.CreationDateDesc:
                        filteredModels = models.OrderByDescending(s => s.CreationDate);
                        break;
                    case AdvertisementSortState.ModifiedDateAsc:
                        filteredModels = models.OrderBy(s => s.ModifiedDate);
                        break;
                    case AdvertisementSortState.ModifiedDateDesc:
                        filteredModels = models.OrderByDescending(s => s.ModifiedDate);
                        break;
                    case AdvertisementSortState.StartActionDateAsc:
                        filteredModels = models.OrderBy(s => s.ActionStartDate);
                        break;
                    case AdvertisementSortState.StartActionDateDesc:
                        filteredModels = models.OrderByDescending(s => s.ActionStartDate);
                        break;
                    case AdvertisementSortState.EndActionDateAsc:
                        filteredModels = models.OrderBy(s => s.ActionEndDate);
                        break;
                    case AdvertisementSortState.EndActionDateDesc:
                        filteredModels = models.OrderByDescending(s => s.ActionEndDate);
                        break;
                    default:
                        filteredModels = models.OrderBy(s => s.CreationDate);
                        break;
                }

                var result = filteredModels.Select(x =>
                    new AdvertisementDto()
                    {
                        AuthorId = x.AuthorId,
                        AuthorFullName = x.Author.FullName,
                        Title = x.Title,
                        Content = x.Content,
                        CreationDate = x.CreationDate,
                        ModifiedDate = x.ModifiedDate,
                        ActionStartDate = x.ActionStartDate,
                        ActionEndDate = x.ActionEndDate
                    });

                return await result.ToListAsync(cancellationToken);
            });
            
        }
    }
}
