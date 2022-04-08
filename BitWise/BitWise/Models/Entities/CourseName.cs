namespace BitWise.Models.Entities
{
    public class CourseName
    {
        public int Id { get; set; }

        public string CourseNames { get; set; } = "";

        public ICollection<CourseTopics> CourseTopics { get; set; } = new List<CourseTopics>();

    }
}
