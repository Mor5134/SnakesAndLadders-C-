using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLadderSnake.Models
{
    public class Square
    {
        public Square()
        {
        }
        public virtual void PlayerLanded(Player player1) { }
        public override string ToString()
        {
            return "Square";
        }
    }

    class SquareSnakeHead : Square
    {
        private readonly int _bottomTail;
        public SquareSnakeHead(int bottomTail)
        {
            _bottomTail = bottomTail;
        }
        public override void PlayerLanded(Player player)
        {
            Console.WriteLine("Player Landed On Snake Head He is Going Down");
            player.CurrentSquare = _bottomTail;
        }
        public override string ToString()
        {
            return "SHead!";
        }
    }

    class SquareSnakeTail : Square
    {
        public override string ToString()
        {
            return "STail!";
        }
    }

    class SquareLadderBottom : Square
    {
        private readonly int _topOfLadder;
        public SquareLadderBottom(int topOfLadder)
        {
            _topOfLadder = topOfLadder;
        }

        public override void PlayerLanded(Player player)
        {
            Console.WriteLine("Player Landed On Bottom Of Ladder He Is Going Up");
            player.CurrentSquare = _topOfLadder;
        }
        public override string ToString()
        {
            return "LadderB";
        }
    }

    class SquareLadderTop : Square
    {
        public override string ToString()
        {
            return "LadderT";
        }
    }

    class GoldenSquare : Square
    {
        private Board _board;
        public GoldenSquare(Board board)
        {
            _board = board;
        }
        public override string ToString()
        {
            return "(Golden)";
        }
        public override void PlayerLanded(Player player)
        {
            Console.WriteLine($"{player.Name} Landed On Golden Square,Both Players Swap Places");
            var p1 = _board._players.Find(x => x.Id ==1);
            var p2 = _board._players.Find(x => x.Id ==2);
            (p1.CurrentSquare, p2.CurrentSquare) = (p2.CurrentSquare, p1.CurrentSquare);
        }

    }
}

