using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLadderSnake.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CurrentSquare { get; set; }
    }
}
