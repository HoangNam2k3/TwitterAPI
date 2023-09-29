namespace twitter.Data
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public string? BackgroundUrl { get; set; }
        public string? Bio { get; set; }  
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }

        public User User { get; set; }
    }
}
