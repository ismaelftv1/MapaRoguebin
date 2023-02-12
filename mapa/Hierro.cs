using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Hierro : Mineral
    {
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
        }
    }
}