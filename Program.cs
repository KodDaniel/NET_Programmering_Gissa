using System;
using System.Collections.Generic;

namespace NET_Programmering_Gissa
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 1;
            List<int> allGuesses = new List<int>();
            int numberToGuess = random.Next(1, 101);


            while (true)
            {
                Console.Write("Gissa på ett tal mellan 1 till 100: ");

                var input = Console.ReadLine();

                // Om det inte är en siffra blir isNumber false.
                // Om det är en int blir isNumber true och  variabeln key sätts, vilken blir lika med den inmatade siffran
                bool isNumber = int.TryParse(input, out int key);

                // Försök igen om vi inte fick en giltig siffra
                if (!isNumber) continue;

                if (key == numberToGuess)
                {
                    Console.WriteLine($"Du valde rätt siffra. Det tog {count} gissningar.");
                    Console.WriteLine("Skriv 'Ja' om du vill fortsätta spela. Om du inte vill fortsätta, skriv ett valfritt tecken och trycka på enter.");

                    // Null Check för att undvika ToLower på null
                    string answer = Console.ReadLine()?.ToLower();

                    //Börja om spelet
                    if (answer == "ja")
                    {
                        //Rensar listan inför nästa omgång
                        allGuesses.Clear();
                        //Återställer counten
                        count = 1;
                        // Nytt nummer till nästa omgång
                        numberToGuess = random.Next(1, 101);
                        continue;
                    }

                    // Vi avslutar spelet
                    // Skriver ut alla gissningar i listan
                    Console.Write($"Dina {count} gissningar: ");
                    allGuesses.ForEach(g => Console.Write(g + " "));
                    Console.ReadKey();
                    break;
                }

                count++;
                //Lägger till det nummer som gissades på i listan
                allGuesses.Add(key);
                string errorMsg = (key > numberToGuess) ? "Ett bra försök, men för högt." : "Ett bra försök, men för lågt.";
                Console.WriteLine(errorMsg + " Försök igen.");
            }

        }
    }
}
