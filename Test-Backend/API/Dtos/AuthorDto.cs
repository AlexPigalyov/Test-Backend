namespace Test_Backend.API.Dtos
{
    public class AuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public int Rating { get; set; }
    }
}
