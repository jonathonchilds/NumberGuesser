using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting();
            var guessCount = new List<int>();
            var restart = "yes";
            while (restart == "yes")
            {
                var maximum = MaxGuessesCalculator();
                var counter = NumberGuesserLoop(ref maximum);
                guessCount.Add(counter);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type \"yes\" to play again!");
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                restart = Console.ReadLine().ToLower();
                Console.ResetColor();
                Console.WriteLine();
            }
            var averageGuesses = guessCount.Average();
            ExitMessage(ref averageGuesses);
        }

        static void Greeting()
        {
            Console.WriteLine("\n");
            Console.WriteLine("**************************************************************************************", Console.ForegroundColor = ConsoleColor.DarkMagenta);
            Console.WriteLine("**************************************************************************************");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      WELCOME TO THE ALMIGHTY NUMBER GUESSER!                          ", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************************", Console.ForegroundColor = ConsoleColor.DarkMagenta);
            Console.WriteLine("**************************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("HELLO!");
            Console.WriteLine();
            Console.WriteLine("I will guess any number you choose.", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("You may pick any whole number you'd like.");
            Console.WriteLine();
            Console.WriteLine("Do not enter your number! Keep it in your head!", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static int MaxGuessesCalculator()
        {
            Console.WriteLine("Please type any number that is HIGHER than the number you've picked:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            int maximum = int.Parse(Console.ReadLine());
            Console.ResetColor();
            int minimum = 0;
            double maxGuesses = Math.Round(Math.Log2((maximum - minimum)) + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine($"This will only take me {maxGuesses} guesses to figure out, at most!");
            Console.WriteLine("Now tell me if I'm correct, or if I need to guess higher or lower.");
            Console.ResetColor();
            return maximum;
        }

        static int NumberGuesserLoop(ref int maximum)
        {

            var higher = new List<string> { "h", "H", "higher", "Higher", "HIGHER" };
            var lower = new List<string> { "l", "L", "Lower", "lower", "LOWER" };
            var yes = new List<string> { "y", "Y", "Yes", "yes", "yes!", "YES", "yasss", "YAS", "YUS", "yup", "yuppp", "yep", "Yeah", "Yep", "yers", "yEs" };

            var minimum = 0;
            var guess = (maximum + minimum) / 2;
            Console.WriteLine();
            Console.WriteLine($"Is your number {guess}? ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            var userResponse = Console.ReadLine();
            Console.ResetColor();

            int counter = 1;
            while (!yes.Contains(userResponse))
            {
                if (higher.Contains(userResponse))
                {
                    counter++;
                    minimum = guess;
                    guess = (maximum + minimum) / 2;
                    Console.WriteLine();
                    Console.WriteLine($"Is your number {guess}?");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userResponse = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (lower.Contains(userResponse))
                {
                    counter++;
                    maximum = guess;
                    guess = (maximum + minimum) / 2;
                    Console.WriteLine($"Is your number {guess}?");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userResponse = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (!lower.Contains(userResponse) || !higher.Contains(userResponse))
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter an acceptable response. (Tell me if I'm correct, or whether I need guess higher or lower.) ", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userResponse = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************************", Console.ForegroundColor = ConsoleColor.DarkMagenta);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(counter + " guesses!!! I'm sure you could do this too (but likely not as quickly). ;-) ", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************************", Console.ForegroundColor = ConsoleColor.DarkMagenta);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            return counter;
        }

        public static void ExitMessage(ref double averageGuesses)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"I averaged {averageGuesses} guesses!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

    }
}

