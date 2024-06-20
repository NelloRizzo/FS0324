using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcSample.Controllers.Models
{
    public class CalculateModel
    {
        public decimal First {  get; set; }
        public decimal Second { get; set; }
        public char Operation {  get; set; }
        public decimal Result { get; set; }
    }
}