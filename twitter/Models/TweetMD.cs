using twitter.Data;

namespace twitter.Models
{
    public class TweetMD
    {
        public int UserId { get; set; }
        public string TweetText { get; set; }

    }
    public class TweetVM:TweetMD
    {
        public int TweetId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RetweetsCount { get; set; }
        public int LikesCount { get; set; }
    }
}
