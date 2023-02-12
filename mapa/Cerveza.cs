using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Cerveza : Item
    {
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("C");
        }
    }
}