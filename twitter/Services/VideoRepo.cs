using Microsoft.EntityFrameworkCore;
using twitter.Data;
using twitter.Models;

namespace twitter.Services
{
    public class VideoRepo : IRepoVideo
    {
        private readonly MyDbContext _context;

        public VideoRepo(MyDbContext context) {
            _context = context;
        }
        public async Task<VideoVM> CreateAsync(VideoMD videoMD)
        {
            var video = new Video
            {
                TweetId = videoMD.TweetId,
                Title = videoMD.Title,
                VideoUrl = videoMD.VideoUrl,
            };
            _context.Add(video);
            await _context.SaveChangesAsync();
            return new VideoVM
            {
                TweetId = video.TweetId,
                Title = video.Title,
                VideoUrl = video.VideoUrl,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var video = await _context.Videos.SingleOrDefaultAsync(vd => vd.VideoId == id);
            if (video == null) return false;
            _context.Remove(video);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<VideoVM>> GetAllAsync()
        {
            var videos = await _context.Videos.Select(video => new VideoVM
            {
                VideoId = video.VideoId,
                TweetId = video.TweetId,
                Title = video.Title,
                VideoUrl = video.VideoUrl,
            }).ToListAsync();
            return videos;
        }

        public async Task<VideoVM> GetByIdAsync(int id)
        {
            var video = await _context.Videos.SingleOrDefaultAsync(vd => vd.VideoId.Equals(id));
            if (video == null) return null!;
            return new VideoVM
            {
                VideoId = video.VideoId,
                TweetId = video.TweetId,
                Title = video.Title,
                VideoUrl = video.VideoUrl,
            };
        }

        public Task<bool> UpdateAsync(VideoVM videoVM)
        {
            throw new NotImplementedException();
        }
    }
}
