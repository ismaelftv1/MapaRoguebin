using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Plata : Mineral
    {
        public Plata() { }
        public Plata(int NuevaVida) 
        {
            this.vida = NuevaVida;
        }
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
        }
    }
}