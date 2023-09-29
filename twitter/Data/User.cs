namespace twitter.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; }

        public ICollection<Tweet> Tweets { get; set; }
        public Profile Profile { get; set; }

        public User()
        {
            Tweets = new HashSet<Tweet>();
            Profile = new Profile();
        }
    }
}
