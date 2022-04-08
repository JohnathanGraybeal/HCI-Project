using BitWise.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitWise.Services
{
    public class CourseRepo : ICourseRepo
    {
        private readonly CoursesDbContext _db;
        
        public CourseRepo(CoursesDbContext db)
        { 
            _db = db;
        }

        //Might need to adjust this one. 
        public CourseTopics? Read(int courseId)
        {
            return _db.CourseTopics
                    .Include(c => c.TopicDescriptions)
                    .Include(c=> c.TopicDescriptions)
                    .FirstOrDefault(c => c.Id == courseId);
        }
        //Might need to adjust this one. 
        public ICollection<CourseName> ReadCourses()
        {
            return _db.CourseNames
                .Include(c => c.CourseTopics)
                    .ThenInclude(c => c.TopicImages)
                .Include(c => c.CourseTopics)
                    .ThenInclude(c => c.TopicDescriptions)
                .ToList();
        }

        public ICollection<CourseTopics> ReadCourseTopics()
        {
            return _db.CourseTopics
               .Include(c => c.TopicDescriptions)
               .Include(c => c.TopicDescriptions).ToList();
        }

        public ICollection<TopicDescription> ReadTopicDescriptions()
        {
            return _db.TopicDescriptions.ToList();
        }

        public ICollection<TopicImage> ReadTopicImages()
        {
            return _db.TopicImages.ToList();
        }
    }
}
