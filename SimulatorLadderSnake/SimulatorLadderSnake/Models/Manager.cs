using SimulatorLadderSnake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLadderSnake.Models
{
    public class Manager
    {
        private readonly Random _rnd;
        private const int goldenSquaresCount = 2;
        Board _board = null!;

        public Manager()
        {
            _rnd = new Random();
        }

        private int RollingCube()
        {
            return _rnd.Next(2, 13);
        }

        private void PlayerTurnMove(Player player)
        {
            var resultSteps = RollingCube();
            Console.WriteLine($"{player.Name} Moving {resultSteps} Steps");
            _board.MovePlayer(player, player.CurrentSquare + resultSteps);
        }

        private bool GameOver()
        {
            foreach (Player player in _board._players)
            {
                if (player.CurrentSquare >= 100)
                {
                    Console.WriteLine($"Game Over {player.Name} Has Won");
                    return true;
                }
            }
            return false;
        }

        private void TrackPlayer(Board board)
        {
            do
            {
                foreach (Player player in board._players)
                {
                    if (GameOver() != true)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine($"\n{player.Name} start turn on square {player.CurrentSquare}");
                        Thread.Sleep(1000);
                        PlayerTurnMove(player);
                        Thread.Sleep(1000);
                        Console.WriteLine($"{player.Name} is now in square {player.CurrentSquare}");
                    }
                }
            }
            while (GameOver() == false);
        }

        private int UserChooseBoard()
        {
            Console.WriteLine("Hello User Do you Want To Create Your Own Board Or Use A Deafault One?");
            Console.WriteLine("To Create Your Own Press 1,For A Deafult One Press 2");
            int choise;

            do
            {
                int.TryParse(Console.ReadLine(), out choise);
            }
            while (choise != 1 && choise != 2);

            if (choise == 1)
                return 1;

            return 2;
        }

        public void StartGame()
        {
            if (UserChooseBoard() == 1)
            {
                int snakeCount,laddersCount;
                Console.WriteLine("You Choose Default Board,Choose How Many Snakes To Add");
                int.TryParse(Console.ReadLine(), out snakeCount);
                Console.WriteLine("And Now How Many Ladders To Add");
                int.TryParse(Console.ReadLine(), out laddersCount);
                Console.WriteLine($"\nThank You For Your Choises,There Are Also Golden Squaers Which Are Always {goldenSquaresCount} ,Good Luck\n");
                _board = new(snakeCount, laddersCount, goldenSquaresCount);
            }

            else
                _board = new Board();

            Console.WriteLine(_board.PrintBoard());
            TrackPlayer(_board);
        }
    }
}




