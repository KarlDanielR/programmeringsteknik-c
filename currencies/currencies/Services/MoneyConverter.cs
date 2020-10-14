using currencies.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace currencies.Services
{
    public class MoneyConverter
    {
        private readonly string _targetCurrency;

        private readonly IDictionary<string, ExchangeRate> _exchangeRates;
        public MoneyConverter(string filepath, string targetCurrency)
        {
            _exchangeRates = new Dictionary<string, ExchangeRate>(StringComparer.OrdinalIgnoreCase);
            _targetCurrency = targetCurrency;

            ReadFile(filepath);
        }

        public Money ConvertToTargetCurrency(Money money)
        {
            ExchangeRate rate = _exchangeRates[money.Currency];

            decimal converterAmount = money.Amount * rate.ConversionRate;

            return new Money(converterAmount, _targetCurrency);
        }

        public Money ConvertFromTargetCurrency(decimal amount, string currency)
        {
            ExchangeRate rate = _exchangeRates[currency];
            decimal convertedAmount = amount / rate.ConversionRate;

            return new Money(convertedAmount, currency);
        }

        private void ReadFile(string filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            using (StreamReader reader = new StreamReader(stream))

            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        ExchangeRate rate = ExchangeRateParser.Parse(line);

                        _exchangeRates.Add(rate.Currency, rate);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            }
        }
    }
}

