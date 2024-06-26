namespace W2.D2.DailyProject.Business.Models
{
    public class Curriculum
    {
        public required PersonalData PersonalData { get; set; }
        public List<Experience> Experiences { get; set; } = [];
        public List<Study> Studies { get; set; } = [];
    }
}
