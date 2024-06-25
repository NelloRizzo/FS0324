namespace W2_D2_SampleApplication.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Owner { get; set; }
        public string Description {  get; set; }
    }
}
