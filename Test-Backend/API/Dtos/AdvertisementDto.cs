using Test_Backend.Application;
using Test_Backend.Domain.Models;

namespace Test_Backend.API.Dtos
{
    public class AdvertisementDto
    {
        public int AuthorId { get; set; }
        public string AuthorFullName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime ActionStartDate { get; set; }
        public DateTime ActionEndDate { get; set; }
    }
}
