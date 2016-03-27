using CardGames.BlackJack;
using CardGames.BlackJack.Dealers;
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
            {
                PlayGame();
                Console.Clear();
            }
        }

        private static void PlayGame()
        {
            Game game = new Game(new Deck(), new StandOn17DealerFactory());

            game.onPlayerWins +=
                (s, pl) => Console.WriteLine("{0} Won!", pl.Name);

            game.onPlayerTies +=
                (s, pl) => Console.WriteLine("You tied!");

            game.Player.onPlayerDied +=
                (pl) =>
                {
                    Console.WriteLine("You died :(");
                };

            game.Player.onReceivedCard +=
                (pl, card) =>
                {
                    Console.WriteLine("You got a {0}", card);
                };

            game.StartGame();

            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("The Dealer's Open Card is: {0}", game.DealerOpenCard());

            while (!game.Player.Done)
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
                            break;
                        case "S":
                            hasInput = true;
                            game.Player.Stand();
                            break;
                        default:
                            Console.WriteLine("Please press 'H' to hit, or 'S' to stand");
                            break;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Dealer Cards:");
            foreach (Card card in game.GetDealerCards())
            {
                Console.WriteLine(card);
            }

            Console.ReadLine();
        }
    }
}
