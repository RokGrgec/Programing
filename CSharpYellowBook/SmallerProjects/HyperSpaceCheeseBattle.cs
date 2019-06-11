using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSpaceCheeseBattle
{
    public struct Player 
        {
           public string Name;
           public int PlayerNo;
           public int X;
           public int Y;
        }
    enum Direction //Direction in which player moves
    {
        UpArrow,
        DownArrow,
        RightArrow,
        LeftArrow,
        WIN,
        Cheese
    }
    class Program
    {
       public static Player[] players;

       public static int NoOfPlayers; 
       
       public static Direction[,] Board = new Direction[,] //Board
            {
                
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 0    | 
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.Cheese,Direction.UpArrow,Direction.UpArrow}, // row 1    |
                { Direction.UpArrow,Direction.Cheese,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 2    |
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.Cheese,Direction.UpArrow}, // row 3    |   Direction of the board
                { Direction.UpArrow,Direction.UpArrow,Direction.Cheese,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 4    |   is upside down
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 5    |
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.Cheese,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 6    |
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.WIN}      // row 7    V
            };
       
        static void Main(string[] args)
        {
           
            Console.Write("\t\t-------------------------------------------\n\t\t-------------------------------------------\n\t\t" +
                "Hi and Welcome to Hyper Space Cheese Battle\n\t\t-------------------------------------------\n\t\t-------------------------------------------" +
                " \n\n\nPlease enter number of players that are playing this round (min of 2, max of 4): ");
           
          
            
           
        }
    }
}
