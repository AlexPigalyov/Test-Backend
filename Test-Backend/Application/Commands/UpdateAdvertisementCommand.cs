using OneOf;
using Test_Backend.Application.Abstract.Commands;

namespace Test_Backend.Application.Commands
{
    public class UpdateAdvertisementCommand : Command<OneOf<string, CommandError<UpdateAdvertisementCommand>>>, ICommand
    {
        public int AdvertisementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ActionStartDate { get; set; }
        public DateTime ActionEndDate { get; set; }
    }
}
