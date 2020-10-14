using System;
using System.Globalization;

namespace months
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a number between 1-12");
            
            int userData = int.Parse(Console.ReadLine());
            var month = CultureInfo.CreateSpecificCulture("sv-SE").DateTimeFormat.GetMonthName(userData);

            Console.WriteLine($"{month}");

            // Skriv ett program som tar en emot inmatad siffra (1-12)
            // och konverterar siffran till ett månadsnamn på svenska
            // programmet skall kasta ett fel om den inmatade siffran är något annat än 1-12.
        }
    }
}
