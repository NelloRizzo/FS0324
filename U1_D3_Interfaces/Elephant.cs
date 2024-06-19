using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_D3_Interfaces
{
    internal class Elephant:Animal
    {
        public Elephant() { Kind = "Elefante"; }

        public override void Bark()
        {
            Console.WriteLine("Sono un elefante e barrisco");
        }
    }
}
