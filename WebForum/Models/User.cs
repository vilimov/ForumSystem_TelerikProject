namespace WebForum.Models
{
    public class User
    {
        private string firstName;
        private string lastName;
        private string email;
        private string username;
        public User(int id, string firstName, string lastName, string email, string username, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                // validator method
                if (value.Length < 4 || value.Length > 32)
                {
                    throw new ArgumentException("First name must be between 4 and 32 symbols");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                // validator method
                if (value.Length < 4 || value.Length > 32)
                {
                    throw new ArgumentException("Last name must be between 4 and 32 symbols");
                }
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                // Regex stuff?
            }
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                // validator method
                if (value.Length < 4 || value.Length > 32)
                {
                    throw new ArgumentException("Username must be between 4 and 32 symbols");
                }
            }
        }
        public string Password { get; set; } // What validation? < & >
        public string ProfileImage { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
