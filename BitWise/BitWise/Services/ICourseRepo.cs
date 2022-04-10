using BitWise.Models.Entities;

namespace BitWise.Services
{
    public interface ICourseRepo
    {
        ICollection<Course> ReadCourses();
        ICollection<CourseTopic> ReadCourseTopics(int id);
        ICollection<TopicDescription> ReadTopicDescriptions(int topicID);
        ICollection<TopicImage> ReadTopicImages(int topicID);
        void CreateTestEntries();
        CourseViewModel ReadCourse(int topicId);

        public void AddImages();
    }
}
