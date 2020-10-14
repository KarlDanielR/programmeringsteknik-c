using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vowelapp
{
    class Program
    {
        private static IEnumerable<object> test;

        static void Main(string[] args)
        {
            // Skriv en konsolapplikation som tar bort vokaler (konstigt va?) från en inmatad sträng.
            // Applikationen skall både presentera den resulterande strängen och antalet vokaler som togs bort.


            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y', 'å', 'ä', 'ö' };

            Console.WriteLine("Skriv ditt namn:");
            string input = Console.ReadLine();
            var output = new List<char>();
            int removedCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var currentCharacter = input[i];
                var normalizedCharacter = char.ToLower(currentCharacter);

                if (!vowels.Contains(normalizedCharacter))
                {
                    output.Add(currentCharacter);
                }
                else
                {
                    removedCount++;
                }

            }

            var resultingString = new string(output.ToArray());
            Console.WriteLine($"ditt namn utan vowels: {resultingString} borttagna vowels: {removedCount}");

        }
    }
}
