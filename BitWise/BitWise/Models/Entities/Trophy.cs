using BitWise.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace BitWise.Models.Entities
{
    public class Trophy
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TrophyRarity Rarity { get; set; } //use this to pick trophy image badge
        public string? Description { get; set; }
        public DateOnly DateEarned { get; set; }
        public BitWiseUser BitWiseUser { get; set; }
        public string BitWiseUserId { get; set; }
    }
}
