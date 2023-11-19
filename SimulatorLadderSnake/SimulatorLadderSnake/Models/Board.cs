using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLadderSnake.Models
{
    public class Board
    {
        private Square[] Squares { get; set; }
        public List<Player> _players;

        public Board(int snakesCount, int laddersCount, int goldenCount)
        {
            Squares = new Square[100];
            _players = new List<Player>() {
                new () { Id = 1, Name = "Piece 1" },
                new () { Id = 2, Name = "Piece 2" }
            };

            while (snakesCount > 0)
            {
                var (top, bottom) = GenerateValidPositions();
                Squares[top] = new SquareSnakeHead(bottom);
                Squares[bottom] = new SquareSnakeTail();
                snakesCount--;
            }

            while (laddersCount > 0)
            {
                var (top, bottom) = GenerateValidPositions();
                Squares[bottom] = new SquareLadderBottom(top);
                Squares[top] = new SquareLadderTop();
                laddersCount--;
            }

            Random rnd = new Random();
            while (goldenCount > 0)
            {
                var pos = rnd.Next(3, Squares.Length);
                if (Squares[pos] != null)
                    continue;
                Squares[pos] = new GoldenSquare(this);
                goldenCount--;
            }

            for (int i = 0; i < Squares.Length; i++)
            {
                if (Squares[i] == null)
                    Squares[i] = new Square();
            }
        }
        public Board()
        {
            Squares = new Square[100];
            _players = new List<Player>() {
                new () { Id = 1, Name = "Player 1" },
                new () { Id = 2, Name = "Player 2" }
            };
            int[] snakesCordiantes = new int[]  {97,78,95,56,88,24,62,18,48,26,36,6,32,10};
            int[] laddersCordiantes = new int[] {1,38,4,14,8,30,21,42,28,76,50,67,71,92,80,99};
           
            for (int i = 0; i < snakesCordiantes.Length; i += 2)
            {
                Squares[snakesCordiantes[i]] = new SquareSnakeHead(snakesCordiantes[i + 1]);
                Squares[snakesCordiantes[i + 1]] = new SquareSnakeTail();
            }
            for (int i = 0; i < laddersCordiantes.Length; i += 2)
            {
                Squares[laddersCordiantes[i]] = new SquareLadderBottom(laddersCordiantes[i + 1]);
                Squares[laddersCordiantes[i+1]] = new SquareLadderTop();
            }
            for (int i = 0; i < Squares.Length; i++)
            {
                if (Squares[i] == null)
                    Squares[i] = new Square();
            }
        }

        private (int top, int bottom) GenerateValidPositions()
        {
            //Square[] emptySquares = new Square[Squares.Length];
            //foreach(var square in Squares)
            //{
            //    if(square != null)
            //    {
                    
            //    }
            //}


            Random rnd = new Random();
            int top, bottom;

            do
                top = rnd.Next(11, Squares.Length);
            while (Squares[top] != null);

            var upperBound = top - top % 10;
            do
                bottom = rnd.Next(upperBound);
            while (Squares[bottom] != null);


            return (top, bottom);
        }

        private void TriggerSquare(Player player)
        {
            if (player.CurrentSquare < Squares.Length)
            {
                Squares[player.CurrentSquare].PlayerLanded(player);
            }
        }

        public void MovePlayer(Player player, int position)
        {
            //if (position < 0 || Squares.Length <= position)
                //throw new ArgumentException();
            player.CurrentSquare = position;
            TriggerSquare(player);
        }

        public string PrintBoard()
        {
            var str = new StringBuilder();
            for (int i = 0; i < 100; i += 10)
            {
                for (int j = 0; j < 10; j++)
                {
                    str.Append(Squares[i + j]);
                    str.Append(' ');
                }
                str.AppendLine();
            }
            return str.ToString();
        }
    }
}