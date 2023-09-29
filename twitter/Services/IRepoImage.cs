using twitter.Data;
using twitter.Models;

namespace twitter.Services
{
    public interface IRepoImage
    {
        Task<List<ImageVM>> GetAllAsync();
        Task<ImageVM> GetByIdAsync(int id);
        Task<ImageVM> CreateAsync(ImageMD imageMD);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(ImageVM imageVM);
    }
}
