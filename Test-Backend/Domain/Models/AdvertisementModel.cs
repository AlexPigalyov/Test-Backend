namespace Test_Backend.Domain.Models
{
    public class AdvertisementModel
    {
        public int AdvertisementId { get; set; }
        public int AuthorId { get; set; }
        public virtual AuthorModel Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ActionStartDate { get; set; }
        public DateTime ActionEndDate { get; set; }
    }
}
