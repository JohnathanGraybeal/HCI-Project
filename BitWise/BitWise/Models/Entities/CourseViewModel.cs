using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitWise.Models.Entities
{
    public class CourseViewModel
    {
        [Key]
        public int CId { get; set; }

        public string CourseName { get; set; } = "";

        public ICollection<CourseTopic>? CourseTopics { get; set; } = new List<CourseTopic>();
        [NotMapped]

        public ICollection<ICollection<TopicDescription>>? TopicDescriptions { get; set; } = new List<ICollection<TopicDescription>>();
        [NotMapped]

        public ICollection<ICollection<TopicImage>>? TopicImages { get; set; } = new List<ICollection<TopicImage>>();
    }
}
