using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CricketTeam
{
    class Program
    {
        struct Player
        {
           public string name;
           public int score;
        }
        static void Main(string[] args)
        {
            Player[] p = new Player[11];
            
            //Entering squad
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine("Enter " + (i + 1) + ". player name: ");
                 p[i].name = Console.ReadLine();
                if (p[i].name == "")
                {
                        Console.Write("You haven't entered a name, please enter again! /n Enter the name: ");
                        p[i].name = Console.ReadLine();
                }
                Console.WriteLine("Enter " + (i + 1) + ". player score: ");
                string playerScore = Console.ReadLine();
                int pScore = int.Parse(playerScore);
                if (pScore < 0 || pScore > 500)
                {
                    Console.Write("The score must be in range from 0 to 500, please enter again: ");
                    string plScore = Console.ReadLine();
                    int plaScore = int.Parse(plScore);
                    p[i].score = plaScore;
                }
                p[i].score = pScore;  
            }
            //Average score of the team
            int avgScore = 0;
            for (int i = 0; i < p.Length; i++)
            {
               
                avgScore += p[i].score;
            }
            avgScore = (avgScore / 11);
            Console.WriteLine("The average score of the team is: " +avgScore);

            //Listing all players and their scores
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine("Player: " +p[i].name + " || Score: " +p[i].score +"\n");
            }

        }
    }
}
