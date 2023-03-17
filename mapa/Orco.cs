using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
    public class Orco: Enemigo, EnemigoF
    {
        public Orco(int x , int y)
        {
            this.y = y;
            this.x = x;
            this.vida = 10;
            this.dano = 5;
        }

        public void hablar()
        {

        }

        public override void dibuja()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }
    }
}