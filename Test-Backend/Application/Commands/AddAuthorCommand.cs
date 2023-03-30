using OneOf;
using Test_Backend.Application.Abstract.Commands;

namespace Test_Backend.Application.Commands
{
    public class AddAuthorCommand : Command<OneOf<string, CommandError<AddAuthorCommand>>>, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
