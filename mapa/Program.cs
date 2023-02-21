namespace mapa
{
    class Program
    {
        private static void Main(string[] args)
        {
            Master game;
            Mapa map;
            Jugador player;

            map = new Mapa(100, 25);
            player = new Jugador(10, 10);

            game = new Master(map, player);
            game.SpawnJugador();
            map.Imprimir();

            Console.CursorVisible = false;
            ConsoleKey tecla;
            do
            {
                //GUI
                Console.SetCursorPosition(101, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Vida: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(player.vida + " ");
                Console.SetCursorPosition(101, 1);
                Console.Write("test");



                player.dibuja();
                tecla = Console.ReadKey(true).Key;

                game.Moverjugador(tecla);
            } while (tecla != ConsoleKey.Escape && player.vida > 0);
        }
    }
}