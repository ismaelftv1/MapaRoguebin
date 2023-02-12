using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapa
{
    public abstract class Celda
    {
        public int vecinos;
        public int salida;
        public int trampa;
        public Item? loot;

        public Celda()
        {
            vecinos = 0;
            salida = 0;
            trampa = 0;
            loot = null;
        }

        public virtual void Dibuja()
        {

            if (salida == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
            }
            else if (trampa != 0)
            {
                if (trampa == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("t");
                }
                else if (trampa == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("t");
                }
                else if (trampa == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("t");
                }
            }
            else
            {
                if (loot != null)
                {
                    ((Mineral)loot).Dibuja();
                    ((Cerveza)loot).Dibuja();
                }
            }


        }
    }
}
