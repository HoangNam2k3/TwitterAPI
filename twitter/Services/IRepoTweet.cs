using twitter.Models;

namespace twitter.Services
{
    public interface IRepoTweet
    {
        Task<List<TweetVM>> GetAllAsync();
        Task<TweetVM> GetByIdAsync(int id);
        Task<TweetVM> CreateAsync(TweetMD tweetMD);
        Task<bool> UpdateAsync(TweetVM tweetVM);
        Task<bool> DeleteAsync(int id);
    }
}
