using OneOf;
using Test_Backend.Application.Abstract.Queries;
using Test_Backend.Domain.Dtos;

namespace Test_Backend.Application.Queries
{
    public class ReadAdvertisementQuery : Query<OneOf<List<AdvertisementDto>, QueryError<ReadAdvertisementQuery>>>, IQuery
    {
        public string FilterString { get; set; } = string.Empty;
        public AdvertisementSortState SortOrder { get; set; } = AdvertisementSortState.StartActionDateDesc;
    }
}
