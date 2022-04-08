using BitWise.Models.Entities;

namespace BitWise.Services
{
    public interface ICourseRepo
    {

        ICollection<CourseName> ReadCourses();
        ICollection<CourseTopics> ReadCourseTopics();
        ICollection<TopicDescription> ReadTopicDescriptions();
        ICollection<TopicImage> ReadTopicImages();

        CourseTopics? Read(int courseId);
       

    }
}
