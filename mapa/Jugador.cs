using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapa
{
    public class Jugador
    {
       public int x,y;

        public Jugador(int x, int y)
        {
            this.y = y;
            this.x = x;
        }

        public void dibuja()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x,y);
            Console.Write("▲");
        }
    }
}
