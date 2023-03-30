using OneOf;
using Test_Backend.Application.Abstract.Commands;

namespace Test_Backend.Application.Commands
{
    public class UpdateAuthorCommand : Command<OneOf<string, CommandError<UpdateAuthorCommand>>>, ICommand
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
