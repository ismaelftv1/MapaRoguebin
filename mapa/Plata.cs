using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Plata : Mineral
    {
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("■");
        }
    }
}