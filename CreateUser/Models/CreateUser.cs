namespace CreateUser.Models
{
    public class CreateUser
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public IEnumerable<User> users { get; set; } = new HashSet<User>();
    }
}
