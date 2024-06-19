using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_D3_PartialClasses
{
    internal partial class MyClass
    {
        public void Print()
        {
            Console.WriteLine($"Value = {Value} - Static Value = {StaticValue}");
        }
    }
}
