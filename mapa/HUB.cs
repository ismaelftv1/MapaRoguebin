using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace mapa
{
    public static class HUB
    {

       public static void DibujaHUB(Jugador player,Mapa map)
        {
            Console.SetCursorPosition(101, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Nivel: ");
            Console.Write(map.nivel);
            Console.SetCursorPosition(101, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Vida: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(player.getVida() + " ");

            if (player.Inventario[0] is Pico)
            {
                Console.SetCursorPosition(101, 20);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Durabilidad: ");
                Console.Write(((Pico)player.Inventario[0]).durabilidad + " ");
            }

            Console.SetCursorPosition(101, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|---------------------|");
            Console.SetCursorPosition(101, 5);
            Console.Write("|      Inventario     |");
            Console.SetCursorPosition(101, 6);
            Console.Write("|Cobre   =   " + player.Inventario.FindAll(x => x is Cobre).Count + "        |");
            Console.SetCursorPosition(101, 7);
            Console.Write("|Hierro  =   " + player.Inventario.FindAll(x => x is Hierro).Count + "        |");
            Console.SetCursorPosition(101, 8);
            Console.Write("|Oro     =   " + player.Inventario.FindAll(x => x is Oro).Count + "        |");
            Console.SetCursorPosition(101, 9);
            Console.Write("|Plata   =   " + player.Inventario.FindAll(x => x is Plata).Count + "        |");
            Console.SetCursorPosition(101, 10);
            Console.Write("|Mithril =   " + player.Inventario.FindAll(x => x is Mithril).Count + "        |");
            Console.SetCursorPosition(101, 11);
            Console.Write("|Picos   =   " + player.Inventario.FindAll(x => x is Pico).Count + "        |");
            Console.SetCursorPosition(101, 12);
            Console.Write("|---------------------|");

            Console.SetCursorPosition(101, 24);
            Console.Write("[" + player.x + "]" + "[" + player.y + "]" + " ");
        }
    }
}