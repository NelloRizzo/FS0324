using System.ComponentModel.DataAnnotations;

namespace FiscalCodeWebApi.DataLayer
{
    public class Province
    {
        [Key]
        public long Id { get; set; }
        [Required, MaxLength(80)]
        public required string Name { get; set; }
        [Required, StringLength(2, MinimumLength = 2)]
        public required string Acronym { get; set; }
        public override bool Equals(object? obj) => obj is Province && obj.GetHashCode() == GetHashCode();
        public override int GetHashCode() => HashCode.Combine(Acronym);
    }
}
