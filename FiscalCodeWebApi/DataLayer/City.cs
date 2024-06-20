using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalCodeWebApi.DataLayer
{
    public class City
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(80), Required]
        public required string Name { get; set; }
        public long ProvinceId { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        public Province? Province { get; set; }
        [StringLength(4, MinimumLength = 4)]
        public required string CadastralCode { get; set; }
        public bool IsCapital { get; set; }
    }
}
