using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Horno : Celda
    {
        public override void Dibuja()
        {
            base.Dibuja();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
        }
    }
}