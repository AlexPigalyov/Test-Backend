using OneOf;
using Test_Backend.API.Dtos;
using Test_Backend.Application.Abstract.Queries;

namespace Test_Backend.Application.Queries
{
    public class ReadAdvertisementQuery : Query<OneOf<List<AdvertisementDto>, QueryError<ReadAdvertisementQuery>>>, IQuery
    {
        public string FilterString { get; set; } = string.Empty;
        public string OrderBy { get; set; } = "StartActionDate_asc";
    }
}
