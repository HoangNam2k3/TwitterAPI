namespace twitter.Data
{
    public class Video
    {
        public int VideoId { get; set; }
        public int TweetId { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
        public Tweet Tweet { get; set; }
    }
}
