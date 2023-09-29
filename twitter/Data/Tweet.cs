namespace twitter.Data
{
    public class Tweet
    {
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string TweetText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RetweetsCount { get; set; }
        public int LikesCount { get; set; }
        public User User { get; set; }

        public ICollection<Video> TweetVideos { get; set; }
        public ICollection<Image> TweetImages { get; set; }

        public Tweet()
        {
            TweetVideos = new HashSet<Video>();
            TweetImages = new HashSet<Image>();
        }

    }
}
