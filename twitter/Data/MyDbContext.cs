using Microsoft.EntityFrameworkCore;
using System.Data;

namespace twitter.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        #region
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(us => us.UserId);
            });
            modelBuilder.Entity<Profile>(e =>
            {
                e.HasKey(prf => prf.ProfileId);
                e.HasOne(prf => prf.User)
                .WithOne(prf => prf.Profile)
                .HasForeignKey<Profile>(prf => prf.UserId);
                e.Property(prf => prf.CreatedAt).HasDefaultValueSql("GetDate()");
                e.Property(prf => prf.UpdatedAt).HasDefaultValueSql("GetDate()");
                e.Property(prf => prf.FollowersCount).HasDefaultValue(0);
                e.Property(prf => prf.FollowingCount).HasDefaultValue(0);
            });
            modelBuilder.Entity<Tweet>(e =>
            {
                e.HasKey(tw => tw.TweetId);
                e.HasOne(tw => tw.User)
                .WithMany(tw => tw.Tweets)
                .HasForeignKey(tw => tw.UserId);
                e.Property(tw => tw.CreatedAt).HasDefaultValueSql("GetDate()");
                e.Property(tw => tw.RetweetsCount).HasDefaultValue(0);
                e.Property(tw => tw.LikesCount).HasDefaultValue(0);
            });
            modelBuilder.Entity<Image>(e =>
            {
                e.HasKey(ig => ig.ImgId);
                e.HasOne(ig => ig.Tweet)
                .WithMany(ig => ig.TweetImages)
                .HasForeignKey(ig => ig.TweetId);
            });
            modelBuilder.Entity<Video>(e =>
            {
                e.HasKey(vd => vd.VideoId);
                e.HasOne(vd => vd.Tweet)
                .WithMany(vd => vd.TweetVideos)
                .HasForeignKey(vd => vd.TweetId);
            });
        }
    }
}
