namespace twitter.Data
{
    public class Image
    {
        public int ImgId { get; set; }
        public int TweetId { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }

        public Tweet Tweet { get; set; }
    }
}
