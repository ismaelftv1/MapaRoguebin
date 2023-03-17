using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Oro : Mineral
    {
        public Oro() { }
        public Oro(int NuevaVida)
        {
            this.vida = NuevaVida;
        }
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("■");
        }
    }
}