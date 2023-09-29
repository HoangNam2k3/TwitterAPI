namespace twitter.Models
{
    public class ImageMD
    {
        public int TweetId { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
    }
    public class ImageVM : ImageMD
    {
        public int ImgId { get; set; }
    }
}
