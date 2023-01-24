using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapa
{
    public class Celda
    {
        public int terreno;
        public int vecinos;

        public Celda(int t)
        { 
           terreno = t;
           vecinos = 0;
        }

        public void Dibuja()
        {
           


            if (terreno == Materiales.Tierra)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(".");
            }
            else if (terreno == Materiales.Hierba)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("*");
            }
            else if (terreno == Materiales.Muro)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("▓");
            }
        }
    }
}
