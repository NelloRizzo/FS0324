namespace W2.D2.DailyProject.Business.Models
{
    public class Study : TimedInfo
    {
        public required string Qualification { get; set; }
        public required string Institute { get; set; }
        public required string Kind { get; set; }
    }
}
