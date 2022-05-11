using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            //do
            //{
            var numberRangeMaximum = Greeting();
            var numberRangeMinimum = 0;
            var systemGuess = (numberRangeMaximum + numberRangeMinimum) / 2;
            Console.WriteLine();
            maxGuessesCalculator(ref numberRangeMaximum, ref numberRangeMinimum);
            Console.WriteLine();
            Console.WriteLine($@"Is your number {systemGuess}?");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            var userResponse = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine();
            ResponseLoop(ref numberRangeMaximum, ref numberRangeMinimum, ref systemGuess, ref userResponse);
            Console.WriteLine("Do you want to play again?");
            //}
            //while (guessHigherResponses.Contains(Console.ReadLine()));

        }

        static int Greeting()
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
            Console.WriteLine("Please type any number that is HIGHER than the number you've picked:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            var initialMaximum = Console.ReadLine();
            Console.ResetColor();
            return int.Parse(initialMaximum);
        }

        static void maxGuessesCalculator(ref int numberRangeMaximum, ref int numberRangeMinimum)
        {
            var maxGuesses = Math.Round(Math.Log2((numberRangeMaximum - numberRangeMinimum)) + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"This will only take me {maxGuesses} guesses to figure out, at most!");
            Console.WriteLine("Now tell me if I'm correct, or if I need to guess higher or lower.");
            Console.ResetColor();

        }

        static void ResponseLoop(ref int numberRangeMaximum, ref int numberRangeMinimum, ref int systemGuess, ref string userResponse)
        {
            // would love to import a text file containing every possible "yes" response; or, perhaps, just add radio buttons. That would be was easier. But the text file idea could apply for something like voice recognition
            var affirmativeUserResponse = new List<string>() { "y", "Y", "Yes", "yes", "yes!", "YES", "yasss", "YAS", "YUS", "yup", "yuppp", "yep", "Yeah", "Yep", "yers", "yEs" };
            var guessLowerResponses = new List<string>() { "l", "L", "Lower", "lower", "LOWER" };
            var guessHigherResponses = new List<string>() { "h", "H", "higher", "Higher", "HIGHER" };

            int counter = 1;

            while (!affirmativeUserResponse.Contains(userResponse))
            {
                if (guessHigherResponses.Contains(userResponse))
                {
                    counter++;
                    numberRangeMinimum = systemGuess;
                    systemGuess = (numberRangeMaximum + numberRangeMinimum) / 2;
                    Console.WriteLine($"Is your number {systemGuess}?");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userResponse = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (guessLowerResponses.Contains(userResponse))
                {
                    counter++;
                    numberRangeMaximum = systemGuess;
                    systemGuess = (numberRangeMaximum + numberRangeMinimum) / 2;
                    Console.WriteLine($"Is your number {systemGuess}?");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userResponse = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (!guessLowerResponses.Contains(userResponse) || !guessHigherResponses.Contains(userResponse))
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
            Console.WriteLine();
            Console.WriteLine("**************************************************************************************", Console.ForegroundColor = ConsoleColor.DarkMagenta);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(counter + " guesses!!! I'm sure you could do this too (but likely not as quickly). ;-) ", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************************", Console.ForegroundColor = ConsoleColor.DarkMagenta);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
