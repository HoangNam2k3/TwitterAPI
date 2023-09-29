namespace twitter.Models
{
    public class VideoMD
    {
        public int TweetId { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
    }
    public class VideoVM : VideoMD
    {
        public int VideoId { get; set; }
    }
}
