using Microsoft.EntityFrameworkCore;
using BitWise.Models.Entities;
namespace BitWise.Services
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<CourseName> CourseNames => Set<CourseName>();
        public DbSet<CourseTopics> CourseTopics => Set<CourseTopics>();
        public DbSet<TopicDescription> TopicDescriptions => Set<TopicDescription>();
        public DbSet<TopicImage> TopicImages => Set<TopicImage>();

    }
}
