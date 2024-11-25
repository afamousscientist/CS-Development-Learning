using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RNGGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool playing = true;
            int points = 0;
            

            while (playing)
            {
                int answer = rng.Next(1, 20);
                Console.WriteLine("Pick a number between 1 and 20:");
                int pickedNum = Convert.ToInt32(Console.ReadLine());
                if (answer == pickedNum)
                {
                    points++;
                    Console.WriteLine("Congrats! You Guessed Correctly.");
                    Console.WriteLine("Would You like to play Again? (Y/N)");
                    string playAgain = Console.ReadLine();
                    if (playAgain == "N" || playAgain == "n")
                    {
                        Console.WriteLine($"You finished with {points} points.");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Womp Womp. You Guessed Incorrectly.");
                    Console.WriteLine("Would You like to play Again? (Y/N)");
                    string playAgain = Console.ReadLine();
                    if (playAgain == "N" || playAgain == "n")
                    {
                        Console.WriteLine($"You finished with {points} points.");
                    }
                }
            }
            
        }
    }
}
