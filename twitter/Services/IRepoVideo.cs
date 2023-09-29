using twitter.Models;

namespace twitter.Services
{
    public interface IRepoVideo
    {
        Task<VideoVM> GetByIdAsync(int id);
        Task<VideoVM> CreateAsync(VideoMD videoMD);
        Task<bool> UpdateAsync(VideoVM videoVM);
        Task<bool> DeleteAsync(int id);
        Task<List<VideoVM>> GetAllAsync();
    }
}
