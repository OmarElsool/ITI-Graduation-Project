using Airbnb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using static Airbnb.Convert.DateOnlyConverterValue;

namespace Airbnb.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Mansion> Mansions { get; set; }
        public virtual DbSet<MansionCategory> MansionsCategories { get; set; }
        public virtual DbSet<MansionPhotoModel> MansionsPhotos { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ServiceModel> Services { get; set; }
        public virtual DbSet<ServiceTypeModel> ServicesType { get; set; }
        public virtual DbSet<AccessFeatureModel> AccessFeatures { get; set; }
        public virtual DbSet<AccessFeatureType> AccessFeaturesTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MansionPhotoModel>(
                o => o.HasKey(k => new { k.Id, k.MansionId })
            );
            builder.Entity<Comment>(
                o => o.HasKey(k => new { k.Id, k.ReviewId })
            );

            builder.Entity<Reservation>()
                .HasOne(o => o.User).WithMany(o => o.Reservations)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Reservation>()
                .HasOne(o => o.Mansion).WithMany(o => o.Reservations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(o => o.User).WithMany(o => o.Reviews)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Review>()
                .HasOne(o => o.Mansion).WithMany(o => o.Reviews)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    configurationBuilder.Properties<DateOnly>()
        //       .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
        //       .HaveColumnType("date");
        //    base.ConfigureConventions(configurationBuilder);
        //}
    }
}