using BitWise.Models.Entities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitWise.Services
{
    public class CoursesDbContext : DbContext, IDataProtectionKeyContext
    {
        public CoursesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;
        public DbSet<Course> Course => Set<Course>();
        public DbSet<CourseTopic> CourseTopic => Set<CourseTopic>();
        public DbSet<TopicDescription> TopicDescription => Set<TopicDescription>();
        public DbSet<TopicImage> TopicImage => Set<TopicImage>();
    }
}
