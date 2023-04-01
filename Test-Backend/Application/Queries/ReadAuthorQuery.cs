using OneOf;
using Test_Backend.API.Dtos;
using Test_Backend.Application.Abstract.Queries;

namespace Test_Backend.Application.Queries
{
    public class ReadAuthorQuery : Query<OneOf<List<AuthorDto>, QueryError<ReadAuthorQuery>>>, IQuery
    {
    }
}
