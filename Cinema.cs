using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asking user to enter number of films in the cinema
            Console.WriteLine("Enter number of films u wanth to be shown in a cinema: ");
            string number = Console.ReadLine();
            int number1 = int.Parse(number);
            string[] filmNames = new string[number1];

            //Entering film names
            for(int i = 0;i < number1; i++)
            {
                int numOfFilm = i + 1;
                Console.WriteLine("Enter the name and  age reqariments for the "+numOfFilm + ". film: ");
                filmNames[i] = Console.ReadLine();
            }

            //Listing all films that were entered
            Console.WriteLine("List of films shown in the cinema:\n");
            for (int i = 0;i < number1; i++)
            {
                Console.WriteLine("\t "+ (i+1) + ". " + filmNames[i]);
            }

            //Selecting the movie user wants to see
            Console.WriteLine("Enter the number of the movie u want to see: ");
            string enNum = Console.ReadLine();
            int enteredNum = int.Parse(enNum);

            //finding the film
           
            Console.WriteLine("\nYou chose: " +filmNames[enteredNum - 1]);
               
            //Checking for age limits
            Console.WriteLine("Enter your age: ");
            string urage = Console.ReadLine();
            int age = int.Parse(urage);
            if (filmNames[enteredNum - 1 ].EndsWith("(20)") && age < 20)
            {
                Console.WriteLine("You are too young to see this movie");
            }
            else if (filmNames[enteredNum - 1].EndsWith("(20)") && age >= 20)
            {
                Console.WriteLine("Enjoy the movie! ");
            }
        }
    }
}
