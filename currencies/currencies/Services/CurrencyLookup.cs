using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace currencies.Services
{
    public static class CurrencyLookup
    {
        static private IDictionary<string, string> _currencies;

        static CurrencyLookup()
        {
            _currencies = new Dictionary<string, string>();

            GenerateCurrencyList();
        }

        public static string GetCurrencyName(string currenctCode)
        {
            return _currencies[currenctCode];
        }
        private static void GenerateCurrencyList()
        {
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo cultureInfo in cultureInfos)
            {
                if (cultureInfo.IsNeutralCulture)
                    continue;

                RegionInfo region = new RegionInfo(cultureInfo.LCID);

                if (_currencies.ContainsKey(region.ISOCurrencySymbol))
                    continue;
                _currencies.Add(region.ISOCurrencySymbol, region.CurrencyNativeName);
            }
        }
    }
}
