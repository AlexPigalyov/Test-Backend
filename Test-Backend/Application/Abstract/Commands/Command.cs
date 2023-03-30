using MediatR;

namespace Test_Backend.Application.Abstract.Commands
{
    public class Command<T> : IRequest<T> where T : new()
    {
    }
}
