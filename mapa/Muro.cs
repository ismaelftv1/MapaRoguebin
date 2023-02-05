using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Muro : Celda
    {
        public override void Dibuja()
        {
            base.Dibuja();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("▓");
        }
    }
}