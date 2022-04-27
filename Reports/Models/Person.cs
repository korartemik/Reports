namespace Reports.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Login { get; set; } = string.Empty;
        public int ParentId { get; set; }
    }
}
