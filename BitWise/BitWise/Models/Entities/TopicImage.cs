namespace BitWise.Models.Entities
{
    public class TopicImage
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string ImageURL { get; set; } = "";
    }
}
