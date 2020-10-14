using currencies.Models;
using currencies.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace currencies
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Skriv ett program som läser in en fil med växlingskurser och
            // sedan konverterar en inmatad valuta till svenska kronor.

            // 2. Skapa sedan ett uppslagsverk med valutanamn och skriv ut namnen på valutorna konverteringen sker emellan.
            // (Valutor lagras på RegionInfo, en egenskap på CultureInfo) 

            // 3. Lägg till ett ytterligare val för valuta att konvertera till (förutom SEK).
            
            
            MoneyConverter moneyConverter = new MoneyConverter("Resources\\Riksbanken_2020-10-13.csv", "SEK");

            Console.Write("Skriv in önskad växlings-valuta och mängd (tex 100 usd): ");
            string input = Console.ReadLine();

            Console.WriteLine("Skriv vilken valuta du vill växla till (tex, GBP)");
            string currencyInput = Console.ReadLine();

            Money enteredMoney = MoneyParser.Parse(input);
            Money convertedMoney = moneyConverter.ConvertToTargetCurrency(enteredMoney);

            if (currencyInput != "SEK")
            {
                convertedMoney = moneyConverter.ConvertFromTargetCurrency(convertedMoney.Amount, currencyInput);
            }

            Console.WriteLine($"Dina {enteredMoney} ({GetCurrencyName(enteredMoney)}) blir {convertedMoney} ({GetCurrencyName(convertedMoney)})");
            
            
                
        }
        public static string GetCurrencyName(Money money)
        {
            return CurrencyLookup.GetCurrencyName(money.Currency);
        }

    }
}
