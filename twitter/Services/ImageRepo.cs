using Microsoft.EntityFrameworkCore;
using twitter.Data;
using twitter.Models;

namespace twitter.Services
{
    public class ImageRepo : IRepoImage
    {
        private readonly MyDbContext _dbContext;

        public ImageRepo(MyDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<ImageVM> CreateAsync(ImageMD imageMD)
        {
            var image = new Image
            {
               TweetId = imageMD.TweetId,
               ImgUrl = imageMD.ImgUrl,
               Title = imageMD.Title,
            };
            _dbContext.Add(image);
            await _dbContext.SaveChangesAsync();
            return new ImageVM
            {
                ImgId = image.ImgId,
                TweetId = image.TweetId,
                ImgUrl = image.ImgUrl,
                Title = image.Title,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var image = await _dbContext.Images.SingleOrDefaultAsync(ig => ig.ImgId == id);
            if (image == null) return false;
            _dbContext.Remove(image);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ImageVM>> GetAllAsync()
        {
            var images = await _dbContext.Images.Select(image => new ImageVM
            {
                ImgId = image.ImgId,
                TweetId = image.TweetId,
                ImgUrl = image.ImgUrl,
                Title = image.Title,
            }).ToListAsync();
            return images;
        }

        public async Task<ImageVM> GetByIdAsync(int id)
        {
            var image = await _dbContext.Images.SingleOrDefaultAsync(ig => ig.ImgId == id);
            if (image == null) return null!;
            return new ImageVM
            {
                ImgId = image.ImgId,
                TweetId = image.TweetId,
                ImgUrl = image.ImgUrl,
                Title = image.Title,
            };
        }

        public Task<bool> UpdateAsync(ImageVM imageVM)
        {
            throw new NotImplementedException();
        }
    }
}
