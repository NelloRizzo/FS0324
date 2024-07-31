namespace W9.D3.Samples.DataLayer.Entities
{
    public class Contact : Entity
    {
        public bool IsPublic {  get; set; }
        public virtual List<Recipient> Recipients { get; set; } = [];
    }
}
