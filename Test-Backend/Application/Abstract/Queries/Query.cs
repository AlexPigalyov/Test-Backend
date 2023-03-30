using MediatR;

namespace Test_Backend.Application.Abstract.Queries
{
    public abstract class Query<TResult> : IRequest<TResult> where TResult : new()
    {
    }
}
