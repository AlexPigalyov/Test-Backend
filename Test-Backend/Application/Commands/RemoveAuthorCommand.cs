using OneOf;
using Test_Backend.Application.Abstract.Commands;

namespace Test_Backend.Application.Commands
{
    public class RemoveAuthorCommand : Command<OneOf<string, CommandError<RemoveAuthorCommand>>>, ICommand
    {
        public int AuthorId { get; set; }
    }
}
