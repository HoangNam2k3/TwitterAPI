using Microsoft.EntityFrameworkCore;
using twitter.Data;
using twitter.Models;

namespace twitter.Services
{
    public class TweetRepo : IRepoTweet
    {
        private readonly MyDbContext _dbContext;

        public TweetRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TweetVM> CreateAsync(TweetMD tweetMD)
        {
            var tweet = new Tweet
            {
                UserId = tweetMD.UserId,
                TweetText = tweetMD.TweetText,
            };
            _dbContext.Add(tweet);
            await _dbContext.SaveChangesAsync();
            return new TweetVM
            {
                TweetId = tweet.UserId,
                TweetText = tweet.TweetText,
                CreatedAt = tweet.CreatedAt,
                UserId = tweet.UserId,
                LikesCount=tweet.LikesCount,
                RetweetsCount=tweet.RetweetsCount,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tweet = await _dbContext.Tweets.FindAsync(id);
            if(tweet == null) return false;

            _dbContext.Remove(tweet);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<TweetVM>> GetAllAsync()
        {
            var tweets = await _dbContext.Tweets.Select(tweet => new TweetVM
            {
                TweetId = tweet.UserId,
                TweetText = tweet.TweetText,
                CreatedAt = tweet.CreatedAt,
                UserId = tweet.UserId,
                LikesCount = tweet.LikesCount,
                RetweetsCount = tweet.RetweetsCount,
            }).ToListAsync();
            return tweets;
        }

        public async Task<TweetVM> GetByIdAsync(int id)
        {
            var tweet = await _dbContext.Tweets.SingleOrDefaultAsync(tw => tw.TweetId == id);
            if (tweet == null) return null!;
            return new TweetVM
            {
                TweetId = tweet.UserId,
                TweetText = tweet.TweetText,
                CreatedAt = tweet.CreatedAt,
                UserId = tweet.UserId,
                LikesCount = tweet.LikesCount,
                RetweetsCount = tweet.RetweetsCount,
            };
        }

        public Task<bool> UpdateAsync(TweetVM tweetVM)
        {
            throw new NotImplementedException();
        }
    }
}
