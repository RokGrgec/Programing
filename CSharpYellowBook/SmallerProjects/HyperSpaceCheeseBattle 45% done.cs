using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HyperSpaceCheeseBattle

{
    public struct Player { //Player Info
           public string Name;
           public int PlayerNo;
           public int X;
           public int Y;
        }
    enum Direction { //Direction in which player moves
    
        UpArrow,
        DownArrow,
        RightArrow,
        LeftArrow,
        WIN,
        UPCheese,
        RightCheese,
        LeftCheese
    }
    class Program {
                
       public static int NoOfPlayers; //Entered at the start of the game by the user

       public static Player[] players = new Player[NoOfPlayers];

       
      

     public  static int DiceTrow() {
            return 0;
       }
        static bool RocketInSquare(int X, int Y) {

            return true;
        }
        public static Direction[,] Board = new Direction[,] {
                
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow},// row 0    | 
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UPCheese,Direction.UpArrow,Direction.UpArrow}, // row 1    |
                { Direction.UpArrow,Direction.UPCheese,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 2    |
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.RightCheese,Direction.UpArrow}, // row 3    |   Direction of the board
                { Direction.UpArrow,Direction.UpArrow,Direction.RightCheese,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 4    |   is upside down
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow},// row 5    |
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.LeftCheese,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow}, // row 6    |
                { Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.UpArrow,Direction.WIN}     // row 7    V
            };

        
            public static void Move(int x, int y, int player) // The 'Move' method. This contains a player collisions checker and a border collisions checker
            {
                foreach (Player p in players) // The player collisions checker
                {
                    if (players[player].PlayerNo == p.PlayerNo) // This stops the player from colliding with themself
                    {
                        continue;
                    }
                    if (players[player].Y + y == p.Y && players[player].X + x == p.X) // This checks if the player has collided with another player
                    {
                        players[player].X += x;
                        players[player].Y += y;
                        switch (Board[p.Y, p.X]) // This checks to see what direction the player, that the current player has collided with, is going and to then move the current player 1 square in the required direction
                        {
                        // D   case Direction.DownArrow:
                        // A      Move(0, -1, player);
                        // N       Console.WriteLine("Looks like that square is already taken");
                        // K       Console.WriteLine("{0} bounces off {1} and moves down", players[player].Name, p.Name);
                        //        break;
                        // S   case Direction.UpArrow:
                        // H       Move(0, +1, player);
                        // I       Console.WriteLine("Looks like that square is already taken");
                        // T       Console.WriteLine("{0} bounces off {1} and moves up", players[player].Name, p.Name);
                        //        break;
                        //    case Direction.RightArrow:
                        //        Move(+1, 0, player);
                        //        Console.WriteLine("Looks like that square is already taken");
                        //        Console.WriteLine("{0} bounces off {1} and moves right", players[player].Name, p.Name);
                        //        break;
                        //    case Direction.LeftArrow:
                        //        Move(-1, 0, player);
                        //        Console.WriteLine("Looks like that square is already taken");
                        //        Console.WriteLine("{0} bounces off {1} and moves left", players[player].Name, p.Name);
                        //        break;
                        //    case Direction.UPCheese:
                        //        Move(+1, 0, player);
                        //        Console.WriteLine("Looks like that square is already taken");
                        //        Console.WriteLine("{0} bounces off {1} and moves right", players[player].Name, p.Name);
                        //        break;
                        //    case Direction.RightCheese:
                        //        Move(-1, 0, player);
                        //        Console.WriteLine("Looks like that square is already taken");
                        //        Console.WriteLine("{0} bounces off {1} and moves left", players[player].Name, p.Name);
                        //        break;
                        //    case Direction.LeftCheese:
                        //        Move(0, +1, player);
                        //        Console.WriteLine("Looks like that square is already taken");
                        //        Console.WriteLine("{0} bounces off {1} and moves up", players[player].Name, p.Name);
                        //        break;
                        //}
                        return;
                    }
                
                Console.WriteLine("{0}'s previous coordinates were ({1},{2})", players[player].Name, players[player].X, players[player].Y);
                if (players[player].X + x > 7 || players[player].Y + y > 7 || players[player].X + x < 0 || players[player].Y + y < 0) // This checks to see if the player has gone over the board and takes them back to their original position if so
                {
                    Console.WriteLine("Looks like {0} has gone over the board", players[player].Name);
                    Console.WriteLine("{0} is returned to their previous position", players[player].Name);
                    return;
                }
                players[player].X += x; // These use values from the Player Turn method
                players[player].Y += y; // and adds them to the X and Y values of the player
            }
        }
     
        static void ResetGame() {
            Console.Write("\t\t-------------------------------------------\n\t\t-------------------------------------------\n\t\t" +
                           "Hi and Welcome to Hyper Space Cheese Battle\n\t\t-------------------------------------------\n\t\t-------------------------------------------" +
                            " \n\n\nPlease enter number of players that are playing this round (min of 2, max of 4): ");
            NoOfPlayers = int.Parse(Console.ReadLine());

            for (int i = 0; i < NoOfPlayers; i++)
            {
                Console.WriteLine("Enter the name of " + (i + 1) + ". player: ");
                players[i].Name = Console.ReadLine();
                players[i].PlayerNo = (i + 1);
                players[i].X = 0;
                players[i].Y = 0;
            }
            

        }

        static void ShowStatus() {
            Console.WriteLine("Hyper Space Cheese Battle Report: ");
            Console.WriteLine("\n\nThere are " + players.Length + " in the game.");
            for (int i = 0; i < players.Length; i++)
            {

                Console.WriteLine(players[i].Name + " is on square ( " + players[i].X + players[i].X + " ).");

            }
            
        }

      
        static void Main(string[] args) {

           

            ResetGame();

            ShowStatus();
           
        }
    }
}
