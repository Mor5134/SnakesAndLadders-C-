using SimulatorLadderSnake.Models;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace SimulatorLadderSnake
{ 
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Manager manager= new();
            manager.StartGame();
        }
    }
}


