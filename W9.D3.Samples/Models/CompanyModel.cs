using System.ComponentModel.DataAnnotations;

namespace W9.D3.Samples.Models
{
    public class CompanyModel
    {
        [Display(Name = "Denominazione"), Required(ErrorMessage = "Inserire la denominazione"), MaxLength(50)]
        public required string Name { get; set; }
    }
}
