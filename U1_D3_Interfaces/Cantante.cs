using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_D3_Interfaces
{
    class Personaggio { }
    internal class Cantante:Personaggio, CapaceDiFareRumore
    {
        public string Canzone { get; set; }
        public void Canta()
        {
            Console.WriteLine(Canzone);
        }

        public void FaiRumore()
        {
            Canta();
        }
    }
}
