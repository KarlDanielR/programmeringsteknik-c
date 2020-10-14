using System;

namespace tgif
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en applikation som läser in ett datum via användarinmatning,
            // som sedan räknar ut hur många dagar det är till nästa fredag.
            //fran det inmatade datumet

            Console.WriteLine("Skriv ett datum: ");
            DateTime userDateTime;
            DateTime.TryParse(Console.ReadLine(), out userDateTime);
            {
                
                var daysUntilFriday = ((int)DayOfWeek.Friday - (int)userDateTime.DayOfWeek + 7) % 7;
                Console.WriteLine($"Det är:{ userDateTime.DayOfWeek} och det är: {daysUntilFriday} kvar till fredag");
                Console.ReadLine();

            }
        }
    }
}

