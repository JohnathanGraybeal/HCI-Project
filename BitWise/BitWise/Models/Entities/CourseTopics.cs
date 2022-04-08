namespace BitWise.Models.Entities
{
    public class CourseTopics
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Topic { get; set; } = "";
        
        public ICollection<TopicDescription>? TopicDescriptions { get; set; } = new List<TopicDescription>();   

        public ICollection<TopicImage>? TopicImages { get; set; } = new List<TopicImage>(); 
        
    }
}
