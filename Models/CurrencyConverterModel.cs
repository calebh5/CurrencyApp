// Models/CurrencyConverterModel.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyApp.Models
{
    public class CurrencyConverterModel
    {
        private readonly List<CurrencyModel> currencies;

        public CurrencyConverterModel()
        {
            // Initialize the list with example data
            currencies = new List<CurrencyModel>
            {
                new CurrencyModel { CurrencyID = 1, CurrencyCode = "USD", ExchangeRate = 1.0 },
                new CurrencyModel { CurrencyID = 4, CurrencyCode = "PHP", ExchangeRate = 43.1232 },
                new CurrencyModel { CurrencyID = 2, CurrencyCode = "EURO", ExchangeRate = .92 },
                new CurrencyModel { CurrencyID = 6, CurrencyCode = "YUAN", ExchangeRate = 7.1 },
                new CurrencyModel { CurrencyID = 3, CurrencyCode = "PESO", ExchangeRate = 17.09 },
                new CurrencyModel { CurrencyID = 5, CurrencyCode = "YEN", ExchangeRate = 146.43 }
                // Add more currencies as needed
            };
        }

        public List<CurrencyModel> GetAvailableCurrencies()
        {
            return currencies;
        }

        public decimal ConvertCurrency(string currencyFrom, string currencyTo, decimal amount)
        {
            // Validation
            if (string.IsNullOrEmpty(currencyFrom) || string.IsNullOrEmpty(currencyTo) || amount <= 0)
            {
                throw new ArgumentException("Invalid input. Currency codes and amount must be provided.");
            }

            // Find exchange rates for the specified currencies
            var fromCurrency = GetCurrencyByCode(currencyFrom);
            var toCurrency = GetCurrencyByCode(currencyTo);

            if (fromCurrency == null || toCurrency == null)
            {
                throw new ArgumentException("Invalid currency codes. Make sure currencies are supported.");
            }

            // Perform the currency conversion
            decimal convertedAmount = amount * (decimal)(toCurrency.ExchangeRate / fromCurrency.ExchangeRate);

            return Math.Round(convertedAmount, 2); // Round to two decimal places
        }

        // Private helper method to retrieve currency by code
        private CurrencyModel? GetCurrencyByCode(string currencyCode)
        {
            return currencies.FirstOrDefault(c => c.CurrencyCode.Equals(currencyCode, StringComparison.OrdinalIgnoreCase));
        }

        // Combined CurrencyModel class
        public class CurrencyModel
        {
            public int CurrencyID { get; set; }
            public string CurrencyCode { get; set; } = string.Empty; // Assigning a default value
            public double ExchangeRate { get; set; }
        }
    }
}
