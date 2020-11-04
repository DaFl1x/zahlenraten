using System;

namespace Zahlenraten
{
    class Program
    {
        static void Main(string[] args)
        {
            // The min and max values aren't needed right now, but maybe in the future we want to easily increase the difficulty (or just time consumption) of this game
            int min = 1; 
            int max = 100;   
 
            // Generates a new random number between min and max
            Random random = new Random();
            int randomNumber = random.Next(min, max);

            // Welcomes the user
            Console.WriteLine("Willkommen beim Zahlenraten!");

            // Asks for you to input a number
            Console.WriteLine("Bitte geben sie eine Zahl von " + min + " bis " + max + " an:");

            // Now you can't guess the number by entering text
            int guessedNumber = 1;

            // Later on, if the input is not text, this boolean will be set to false
            bool inputIsText = true;

            // Name says it all
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
                    // Error: User can't read instructions
                    Console.WriteLine("Bitte geben sie nur Zahlen an!");
                    inputIsText = true;
                }

                if (inputIsText == false)
                {
                    // Every time you input a number, it adds one try
                    trysNeeded = trysNeeded + 1;

                    // The input should be from min to max, nothing above. You can enter something above, I don't care. But it wont help you with the guessing...
                    if (guessedNumber > max)
                    {
                        Console.WriteLine("Sie können zwar eine Zahl über " + max + " anegeben, die zufällige Zahl (die sie erraten sollen) befindet sich allerdings zwischen " + min + " und " + max + ". Deshalb:");
                    }

                    // The input should be from min to max, nothing above. You can enter something above, I don't care. But it wont help you with the guessing...
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

            Console.WriteLine("--== Bravo! Du hast " + trysNeeded + " Versuche gebraucht. ==--");
        }
    }
}
