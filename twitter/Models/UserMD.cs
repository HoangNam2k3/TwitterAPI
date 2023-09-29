namespace twitter.Models
{
    public class UserMD
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserVM : UserMD
    {
        public int UserId { get; set; }
    }
}
