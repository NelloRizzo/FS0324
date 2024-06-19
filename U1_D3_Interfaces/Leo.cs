using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_D3_Interfaces
{
    internal class Leo:Animal
    {
        public Leo() { Kind = "Leone"; }

        public override void Bark()
        {
            Console.WriteLine("Sono un leone e ruggisco");
        }
    }
}
