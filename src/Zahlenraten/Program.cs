using System;

namespace Zahlenraten
{
    class Program
    {
        static void Main(string[] args)
        {
            // The min and max values aren't needed right now, but maybe in the future we want to easily increase the difficulty (or just time consumption) of this game
            int min = 10; 
            int max = 50;   
 
            // Generates a new random number between min and max
            Random random = new Random();
            int randomNumber = random.Next(min, max);

            Console.WriteLine("--== Willkommen beim Zahlenraten! ==--");

            // Asks for you to input a number from min to max
            Console.WriteLine("Bitte geben sie eine Zahl von " + min + " bis " + max + " an:");

            // This will be the automatic guessed number if text is entered
            int guessedNumber = 1;

            // Later on, if the input is not text, this boolean will be set to false
            bool inputIsText = true;

            int trysNeeded = 0;

            for (; ; )
            {
                // Waits for the user to input a new number
                try
                {
                    guessedNumber = Convert.ToInt32(Console.ReadLine());
                    inputIsText = false;
                }

                catch
                {
                    Console.WriteLine("Bitte geben sie nur Zahlen an!");
                    inputIsText = true;
                }

                if (inputIsText == false)
                {
                    trysNeeded = trysNeeded + 1;

                    // The input should be from min to max, nothing above. You can enter something above, it won't help you with the guessing...
                    if (guessedNumber > max)
                    {
                        Console.WriteLine("Sie können zwar eine Zahl über " + max + " anegeben, die zufällige Zahl (die sie erraten sollen) befindet sich allerdings zwischen " + min + " und " + max + ". Deshalb:");
                    }

                    // The input should be from min to max, nothing above. You can enter something above, it won't help you with the guessing...
                    else if (guessedNumber < min)
                    {
                        Console.WriteLine("Sie können zwar eine Zahl unter " + min + " anegeben, die zufällige Zahl (die sie erraten sollen) befindet sich allerdings zwischen " + min + " und " + max + ". Deshalb:");
                    }

                    // Compares the random number with the input
                    if (guessedNumber == randomNumber)
                    {
                        // you guessed the number
                        Console.WriteLine("Toll, das ist die richtige Zahl!");
                        break;
                    }

                    else if (guessedNumber > randomNumber)
                    {
                        // guess is too great
                        Console.WriteLine("Leider falsch, die Zahl ist kleiner");
                    }

                    else
                    {
                        // guess is too litle
                        Console.WriteLine("Leider falsch, die Zahl ist grösser");
                    }

                }

            }

            // I did this because "you did it in 1 trys" was not great to read
            if (trysNeeded == 1)
            {
                Console.WriteLine("--== Wow! Du hast nur einen Versuch gebraucht. ==--");
            }

            else
            {
                Console.WriteLine("--== Bravo! Du hast " + trysNeeded + " Versuche gebraucht. ==--");
            }
        }
    }
}
