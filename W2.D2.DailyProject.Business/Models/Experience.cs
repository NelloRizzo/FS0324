namespace W2.D2.DailyProject.Business.Models
{
    public class Experience : TimedInfo
    {
        public required string Company { get; set; }
        public required string JobTitle { get; set; }
        public required string JobDescription { get; set; }
        public required string Tasks { get; set; }
    }
}
