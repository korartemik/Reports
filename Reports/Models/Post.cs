using System.ComponentModel.DataAnnotations;
namespace Reports.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int CreatorId { get; set; }
        public string TextPost { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime DateTimeLastChange { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
