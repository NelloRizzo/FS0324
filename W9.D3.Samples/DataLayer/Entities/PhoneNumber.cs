using System.ComponentModel.DataAnnotations;

namespace W9.D3.Samples.DataLayer.Entities
{
    public class PhoneNumber : Recipient
    {
        [MaxLength(5)]
        public string? NationalCode {  get; set; }
        [MaxLength(15)]
        public required string Number {  get; set; }
    }
}
