using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Mithril : Mineral
    {

        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");
        }
    }
}