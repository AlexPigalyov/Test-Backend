using OneOf;
using Test_Backend.Application.Abstract.Commands;

namespace Test_Backend.Application.Commands
{
    public class RemoveAdvertisementCommand : Command<OneOf<string, CommandError<RemoveAdvertisementCommand>>>, ICommand
    {
        public int AdvertisementId { get; set; }
    }
}
