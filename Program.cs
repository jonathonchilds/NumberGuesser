using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberRangeMaximum = int.Parse(Greeting());
            var numberRangeMinimum = 0;
            var systemGuess = (numberRangeMaximum + numberRangeMinimum) / 2;
            Console.WriteLine();
            maxGuessesCalculator(ref numberRangeMaximum, ref numberRangeMinimum);
            Console.WriteLine();
            Console.WriteLine($@"Is your number {systemGuess}?");
            Console.WriteLine();
            var userResponse = Console.ReadLine();
            ResponseLoop(ref numberRangeMaximum, ref numberRangeMinimum, ref systemGuess, ref userResponse);
        }

        static string Greeting()
        {
            Console.WriteLine("\n");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("                      WELCOME TO THE ALMIGHTY NUMBER GUESSER!                          ", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ResetColor();
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("\n");
            Console.WriteLine("Hello!");
            Console.WriteLine();
            Console.WriteLine("My goal is to guess a number that you have chosen in your mind.", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("You may pick any whole number you'd like.");
            Console.WriteLine();
            Console.WriteLine("Do not enter your number! Keep it in your head, please.");
            Console.WriteLine();
            Console.WriteLine("Now do me a favor and type any number that is higher than the number you've picked.");
            Console.WriteLine();
            return Console.ReadLine();
        }

        static void maxGuessesCalculator(ref int numberRangeMaximum, ref int numberRangeMinimum)
        {
            var maxGuesses = Math.Round(Math.Log2((numberRangeMaximum - numberRangeMinimum)) + 1);
            Console.WriteLine($"This will only take me {maxGuesses} guesses to figure out, at most. " +
                                "Now tell me if I'm correct, or if I need to guess higher or lower.");

        }

        static void ResponseLoop(ref int numberRangeMaximum, ref int numberRangeMinimum, ref int systemGuess, ref string userResponse)
        {
            // would love to import a text file containing every possible "yes" response; or, perhaps, just add radio buttons. That would be was easier. But the text file idea could apply for something like voice recognition
            var affirmativeUserResponse = new List<string>() { "y", "Y", "Yes", "yes", "yes!", "YES", "yasss", "YAS", "YUS", "yup", "yuppp", "yep", "Yeah", "Yep" };
            var List_Of_Possible_Responses_For_Guess_Lower = new List<string>() { "l", "L", "Lower", "lower", "LOWER" };
            var List_Of_Possible_Responses_For_Guess_Higher = new List<string>() { "h", "H", "higher", "Higher", "HIGHER" };

            int counter = 1;

            while (!affirmativeUserResponse.Contains(userResponse))
            {
                if (List_Of_Possible_Responses_For_Guess_Higher.Contains(userResponse))
                {
                    counter++;
                    numberRangeMinimum = systemGuess;
                    systemGuess = (numberRangeMaximum + numberRangeMinimum) / 2;
                    Console.WriteLine($"Is your number {systemGuess}?");
                    userResponse = Console.ReadLine();
                    Console.WriteLine();
                }
                else if (List_Of_Possible_Responses_For_Guess_Lower.Contains(userResponse))
                {
                    counter++;
                    numberRangeMaximum = systemGuess;
                    systemGuess = (numberRangeMaximum + numberRangeMinimum) / 2;
                    Console.WriteLine($"Is your number {systemGuess}?");
                    userResponse = Console.ReadLine();
                    Console.WriteLine();
                }
                else if (!List_Of_Possible_Responses_For_Guess_Lower.Contains(userResponse) || !List_Of_Possible_Responses_For_Guess_Higher.Contains(userResponse))
                {

                    Console.WriteLine("Please enter an acceptable response: tell me if I'm correct, or whether I need guess higher or lower. ", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                    Console.WriteLine();
                    userResponse = Console.ReadLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine(counter + " guesses! I'm sure you could do this too, but likely not as quickly. ☺️");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
