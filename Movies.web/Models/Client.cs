namespace Movies.web.Models
{
    public class Client:User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
