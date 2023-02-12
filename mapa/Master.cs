using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace mapa
{
    public class Master
    {
        Mapa map;
        Jugador player;
        List<Item> inventario = new List<Item>();

        public Master(Mapa map, Jugador player)
        {
            this.map = map;
            this.player = player;
        }

        public void Moverjugador(ConsoleKey tecla)
        {

            Console.SetCursorPosition(player.x, player.y);

            Celda celda = map.mapa[player.x, player.y];

            celda.Dibuja();
            switch (tecla)
            {
                case ConsoleKey.S:
                    MoverAbajo();
                    break;
                case ConsoleKey.D:
                    MoverDerecha();
                    break;
                case ConsoleKey.W:
                    MoverArriba();
                    break;
                case ConsoleKey.A:
                    MoverIzquierda();
                    break;
            }
            NuevoMapa();
            danotrampa();
            Beber();
        }
        //Mecanicas items

        void Beber()
        {
            if (map.mapa[player.x,player.y].loot is Cerveza)
            {
                player.vida += 15;
                map.mapa[player.x, player.y].loot = null;
            }
        }

        //Mecanicas trampas

        void danotrampa()
        {
            if (map.mapa[player.x,player.y].trampa == 1)
            {
                player.vida = player.vida - 5;
            }
            else if (map.mapa[player.x, player.y].trampa == 2)
            {
                player.vida = player.vida - 15;
            }
            else if (map.mapa[player.x, player.y].trampa == 3)
            {
                player.vida = player.vida - 25;
            }
        }

        //Mecanicas generar nuevo mapa
        void NuevoMapa()
        {
            if (map.mapa[player.x, player.y].salida == 1)
            {
                map.CellularAut();
                map.Imprimir();
                SpawnJugador();
            }
        }

        //Mecanicas Jugador
        void MoverMecanica(int moverx, int movery)
        {
            moverx = player.x + moverx;
            movery = player.y + movery;

            if (moverx < map.mapa.GetLength(0) &&
                movery < map.mapa.GetLength(1) &&
                moverx >= 0 &&
                movery >= 0 &&
                map.mapa[moverx, movery] is not Muro)
            {
                player.x = moverx;
                player.y = movery;
            }
        }
        void MoverArriba()
        {
            MoverMecanica(0, -1);
        }
        void MoverAbajo()
        {
            MoverMecanica(0, 1);
        }
        void MoverDerecha()
        {
            MoverMecanica(1, 0);
        }
        void MoverIzquierda()
        {
            MoverMecanica(-1, 0);
        }
        public void SpawnJugador()
        {
            Random rng = new Random();
            if (map.mapa[player.x, player.y] is not Suelo)
            {
                do
                {
                    int x = rng.Next(map.mapa.GetLength(0));
                    int y = rng.Next(map.mapa.GetLength(1));
                    player.x = x;
                    player.y = y;
                } while (map.mapa[player.x, player.y] is not Suelo);
            }
        }



    }
}