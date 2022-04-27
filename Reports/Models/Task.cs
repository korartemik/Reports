using System.ComponentModel.DataAnnotations;
namespace Reports.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string TaskText { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime DeadlineTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastChange { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
