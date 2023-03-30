using OneOf;
using Test_Backend.Application.Abstract.Queries;
using Test_Backend.Domain.Dtos;

namespace Test_Backend.Application.Queries
{
    public class ReadAuthorQuery : Query<OneOf<List<AuthorDto>, QueryError<ReadAuthorQuery>>>, IQuery
    {
    }
}
