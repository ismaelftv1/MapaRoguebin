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
        public int salida;

        public Celda(int t)
        {
            terreno = t;
            vecinos = 0;
            salida = 0;
        }

        public void Dibuja()
        {

            if (salida == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
            }
            else
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
}
