using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Suelo : Celda
    {
        public override void Dibuja()
        {
            base.Dibuja();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(".");
        }
    }
}