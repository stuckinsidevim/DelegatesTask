namespace DelegatesTask
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contact { get; set; } = null!;
        private static int counter;

        public User()
        {
            Id = ++counter;
        }
    }
}
