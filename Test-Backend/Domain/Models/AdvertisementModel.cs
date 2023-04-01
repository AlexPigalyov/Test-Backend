using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Backend.Domain.Models
{
    [Table("Advertisements")]
    public class AdvertisementModel
    {
        [Key]
        public int AdvertisementId { get; set; }
        public int AuthorId { get; set; }
        public virtual AuthorModel Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public DateTimeOffset ActionStartDate { get; set; }
        public DateTimeOffset ActionEndDate { get; set; }
    }
}
