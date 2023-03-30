namespace Test_Backend.Domain.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public List<AdvertisementModel> Advertisements { get; set; }
        public int Rating { get; set; }
    }
}
