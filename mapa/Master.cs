using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace mapa
{
    public class Master
    {
        Mapa map;
        Jugador player;

        public Master(Mapa map, Jugador player)
        {
            this.map = map;
            this.player = player;
        }

        public void moverjugador(ConsoleKey tecla)
        {
            Console.SetCursorPosition(player.x, player.y);

            Celda celda = map.mapa[player.x, player.y];

            celda.Dibuja();
            switch (tecla)
            {
                case ConsoleKey.S:
                    if (map.mapa[player.x,player.y+1].terreno == 0 )
                    {

                    }
                    else
                    {
                        player.y++;
                    }
                    break;
                case ConsoleKey.D:
                    if (map.mapa[player.x+1, player.y].terreno == 0)
                    {

                    }
                    else
                    {
                        player.x++;
                    }
                    break;
                case ConsoleKey.W:
                    if (map.mapa[player.x, player.y - 1].terreno == 0)
                    {

                    }
                    else
                    {
                        player.y--;
                    }
                    break;
                case ConsoleKey.A:
                    if (map.mapa[player.x - 1, player.y].terreno == 0)
                    {

                    }
                    else
                    {
                        player.x--;
                    }
                    break;
            }
        }


    }
}