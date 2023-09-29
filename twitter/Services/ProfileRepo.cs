using Microsoft.EntityFrameworkCore;
using twitter.Data;
using twitter.Models;

namespace twitter.Services
{
    public class ProfileRepo : IRepoProfile
    {
        private readonly MyDbContext _dbContext;

        public ProfileRepo(MyDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<ProfileVM> CreateAsync(ProfileMD profileMD)
        {
            var profile = new Profile
            {
                UserId = profileMD.UserId,
                UserName = profileMD.UserName,
                FullName = profileMD.FullName,
                Birthday = profileMD.Birthday,
                Email = profileMD.Email,
                AvatarUrl = profileMD.AvatarUrl,

            };
            _dbContext.Add(profile);
            await _dbContext.SaveChangesAsync();
            return new ProfileVM
            {
                ProfileId = profile.ProfileId,
                UserId = profile.UserId,
                Email = profile.Email,
                AvatarUrl = profile.AvatarUrl,
                BackgroundUrl = profile.BackgroundUrl,
                Bio = profile.Bio,
                Birthday = profile.Birthday,
                CreatedAt = profile.CreatedAt,
                FollowersCount = profile.FollowersCount,
                FollowingCount = profile.FollowingCount,
                FullName = profile.FullName,
                Location = profile.Location,
                UpdatedAt = profile.UpdatedAt,
                UserName = profile.UserName,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.Profiles.SingleOrDefaultAsync(prf => prf.UserId == id);
            if (user == null)
                return false;
            _dbContext.Profiles.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProfileVM>> GetAllAsync()
        {
            var users = _dbContext.Profiles.Select(profile => new ProfileVM
            {
                ProfileId = profile.ProfileId,
                UserId = profile.UserId,
                UserName = profile.UserName,
                FullName = profile.FullName,
                Email = profile.Email,
                AvatarUrl = profile.AvatarUrl,
                BackgroundUrl = profile.BackgroundUrl,
                Bio = profile.Bio,
                Birthday = profile.Birthday,
                CreatedAt = profile.CreatedAt,
                Location = profile.Location,
                FollowersCount = profile.FollowersCount,
                FollowingCount = profile.FollowingCount,
                UpdatedAt = profile.UpdatedAt,
            });
            return await users.ToListAsync();
        }

        public async Task<ProfileVM> GetByIdAsync(int id)
        {
            var profile = await _dbContext.Profiles.SingleOrDefaultAsync(prf => prf.UserId.Equals(id));
            if (profile == null) return null!;
            return new ProfileVM
            {   
                ProfileId = profile.ProfileId,
                UserId = profile.UserId,
                UserName = profile.UserName,
                FullName = profile.FullName,
                Email = profile.Email,
                AvatarUrl = profile.AvatarUrl,
                BackgroundUrl = profile.BackgroundUrl,
                Bio = profile.Bio,
                Birthday = profile.Birthday,
                CreatedAt = profile.CreatedAt,
                Location = profile.Location,
                FollowersCount = profile.FollowersCount,
                FollowingCount = profile.FollowingCount,
                UpdatedAt = profile.UpdatedAt,
            };
        }

        public async Task<bool> UpdateAsync(ProfileVM profileVM)
        {
            var profile = await _dbContext.Profiles.SingleOrDefaultAsync(prf => prf.UserId == profileVM.ProfileId);
            if (profile == null) return false;
            profile.UserName = profileVM.UserName;
            profile.FullName = profileVM.FullName;
            profile.Email = profileVM.Email;
            profile.AvatarUrl = profileVM.AvatarUrl;
            profile.BackgroundUrl = profileVM.BackgroundUrl;
            profile.Bio = profileVM.Bio;
            profile.Birthday = profileVM.Birthday;
            profile.CreatedAt = profileVM.CreatedAt;
            profile.Location = profileVM.Location;
            profile.FollowersCount = profileVM.FollowersCount;
            profile.FollowingCount = profileVM.FollowingCount;
            profile.UpdatedAt = profileVM.UpdatedAt;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
