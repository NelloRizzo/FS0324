using System.ComponentModel.DataAnnotations;

namespace W2.D3.WebAppSample.Models
{
    public class Person
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Inserire il nome")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Display(Name = "Cognome")]
        public string LastName { get; set; }
        [Display(Name = "Reddito annuo")
        //    , DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)
        ]
        [Range(1, 10000)]
        public decimal Income { get; set; }
        [Display(Name ="Sesso")]
        public char Gender {  get; set; }

    }
}
