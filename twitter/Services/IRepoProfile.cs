using twitter.Models;
namespace twitter.Services
{
    public interface IRepoProfile
    {
        Task<List<ProfileVM>> GetAllAsync();
        Task<ProfileVM> GetByIdAsync(int id);
        Task<ProfileVM> CreateAsync(ProfileMD profileMD);
        Task<bool> UpdateAsync(ProfileVM profileVM);
        Task<bool> DeleteAsync(int id);
    }
}
