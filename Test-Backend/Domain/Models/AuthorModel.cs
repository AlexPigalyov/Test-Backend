using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Backend.Domain.Models
{
    [Table("Authors")]
    public class AuthorModel
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<AdvertisementModel> Advertisements { get; set; }
        public int Rating { get; set; } = 0;
    }
}
