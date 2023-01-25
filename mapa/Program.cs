namespace mapa
{
    class Program
    {
        private static void Main(string[] args)
        {
            Master game;
            Mapa map;
            Jugador player;

            map = new Mapa(100,25);
            player = new Jugador(10,10);

            game = new Master(map, player);
            map.Imprimir();

            Console.CursorVisible = false;

            ConsoleKey tecla;
            do
            {

                player.dibuja();
                tecla = Console.ReadKey(true).Key;

                game.Moverjugador(tecla);
            } while (tecla != ConsoleKey.Escape);

        }
    }
}