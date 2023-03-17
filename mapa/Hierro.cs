using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Hierro : Mineral
    {
        public Hierro() { }
        public Hierro(int NuevaVida)
        {
            this.vida = NuevaVida;
        }

        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("■");
        }
    }
}