using System.ComponentModel.DataAnnotations;

namespace BitWise.Models.Entities
{
    public class CourseViewModel
    {
        [Key]
        public int CId { get; set; }

        public string CourseName { get; set; } = "";

        public ICollection<CourseTopic>? CourseTopics { get; set; } = new List<CourseTopic>();

        public ICollection<ICollection<TopicDescription>>? TopicDescriptions { get; set; } = new List<ICollection<TopicDescription>>();

        public ICollection<ICollection<TopicImage>>? TopicImages { get; set; } = new List<ICollection<TopicImage>>();
    }
}
