﻿using System;
using System.Collections.Generic;
using System.Text;

namespace currencies.Services
{
    public struct Money
    {
        public Money(decimal amount, string currency)
        {
            /*if (string.IsNullOrEmpty(currency))
                throw new ArgumentNullException(nameof(currency));

            if (currency.Length != 3)
                throw new ArgumentException("Invalid currency code");
            */
            Amount = amount;
            Currency = currency.ToUpper();

        }
        public decimal Amount { get; }
        public string Currency { get; }

        public override string ToString()
        {
            return $"{Math.Round(Amount, 2)} {Currency}";
        }

    }

}