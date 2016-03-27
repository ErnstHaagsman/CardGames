using CardGames.BlackJack;
using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJackCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
                PlayGame();
        }

        private static void PlayGame()
        {
            Game game = new Game(new Deck());

            game.onPlayerWins +=
                (s, pl) => Console.WriteLine("{0} Won!", pl.Name);

            game.onPlayerTies +=
                (s, pl) => Console.WriteLine("You tied!");

            game.StartGame();

            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("The Dealer Open Card is: {0}", game.DealerOpenCard());

            bool going = true;
            while (going)
            {
                Console.WriteLine("Your cards:");
                Console.WriteLine();

                foreach (Card card in game.Player.Hand.GetCards())
                {
                    Console.WriteLine(card);
                }

                Console.WriteLine();
                bool hasInput = false;
                while (!hasInput)
                {
                    Console.Write("You can [H]it or [S]tand: ");
                    string key = Console.ReadKey().KeyChar.ToString().ToUpper();
                    Console.WriteLine();
                    switch (key)
                    {
                        case "H":
                            hasInput = true;
                            game.Player.Hit();
                            if (!game.Player.Alive)
                            {
                                Console.WriteLine("You died :(");
                                going = false;
                            }
                            break;
                        case "S":
                            hasInput = true;
                            game.Player.Stand();
                            going = false;
                            break;
                        default:
                            Console.WriteLine("Please press 'H' to hit, or 'S' to stand");
                            break;
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
