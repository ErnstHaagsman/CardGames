﻿using CardGames.BlackJack;
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
        static IPlayer player;
        static IDeck deck = new Deck();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine();
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            player = new Player(new BlackJackHand(0), deck);
            player.Name = name;
            player.Balance = 1000;
            Console.WriteLine("Hi {0}! You have {1:C} to bet with", player.Name, player.Balance);

            player.onPlayerDied += (pl) => Console.WriteLine("You died :(");
            player.onReceivedCard += (pl, card) => Console.WriteLine("You got a {0}", card);

            PreGame();
        }

        private static void PreGame()
        {
            Game game = new Game(new StandOn17DealerFactory(), deck);
            game.SetPlayer(player);

            game.onNextState += Game_onNextState;

            Console.WriteLine("How much would you like to bet on your next hand?");
            decimal? bet = null;
            while(bet == null)
            {
                string betString = Console.ReadLine();

                decimal placeholder;
                if(Decimal.TryParse(betString, out placeholder))
                {
                    if (placeholder > 0) bet = placeholder;
                }
                else
                {
                    Console.WriteLine("That wasn't a valid bet, try any number over 0");
                }
            }

            player.Hand = new BlackJackHand((decimal)bet);
            player.Balance -= (decimal)bet;

            game.StartGame();
        }

        private static void inGame(IGame game)
        {
            while (game.State == GameState.InGame)
            {
                Console.Clear();
                Console.WriteLine("The Dealer's Open Card is: {0}", game.DealerOpenCard);
                Console.WriteLine("Your cards:");
                Console.WriteLine();

                foreach (Card card in game.CurrentHand)
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
                            game.Hit();
                            break;
                        case "S":
                            hasInput = true;
                            game.Stand();
                            break;
                        default:
                            Console.WriteLine("Please press 'H' to hit, or 'S' to stand");
                            break;
                    }
                }
            }
        }

        private static void gameOver(IGame game)
        {
            Console.Clear();
            Console.WriteLine("Your cards:");
            Console.WriteLine();

            foreach (Card card in game.CurrentHand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
            Console.WriteLine("Dealer Cards:");
            foreach (Card card in game.DealerCards)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Console.WriteLine("Your hand {0}", game.CurrentHand.State);

            Console.WriteLine();
            Console.WriteLine("You now have {0:C}", player.Balance);

            if (player.Balance > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Press enter for a new game");

                Console.ReadLine();
                PreGame();
            }
            else
            {
                Console.WriteLine("You're broke, get out!");
                Console.ReadLine();
            }
        }

        private static void Game_onNextState(object sender, GameStateEventArgs e)
        {
            switch (e.NextState)
            {
                case GameState.InGame:
                    inGame((IGame)sender);
                    break;
                case GameState.GameOver:
                    gameOver((IGame)sender);
                    break;
            }
        }
    }
}
