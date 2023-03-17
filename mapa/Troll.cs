using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Troll: Enemigo, EnemigoF
    {

        public Troll(int x, int y)
        {
            this.y = y;
            this.x = x;
            this.vida = 20;
            this.dano = 10;
        }

        public override void dibuja()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write("T");
        }
    }
}