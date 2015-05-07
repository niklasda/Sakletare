using System;
using System.Globalization;

namespace Silver.Wp7.Logic
{
    public class HtmlStringParser
    {
        public HtmlStringParser(string allText)
        {
            _allText = allText;
        }

        private readonly string _allText;

        public string ParseGold()
        {
            if (string.IsNullOrEmpty(_allText))
            {
                return null;
            }

            int iGroupingStart = _allText.IndexOf("Dagens guldpris är: ", 0, StringComparison.CurrentCultureIgnoreCase);

            string sTitle = _allText.Substring(iGroupingStart, 40).Trim();
            string sPrice = sTitle.Replace("Dagens guldpris är: ", "");
            string x = sPrice.Substring(0, sPrice.IndexOf("kr/gram")).Trim();

            float price = 0;
            if (float.TryParse(x, NumberStyles.Currency, new CultureInfo("en-US"), out price))
            {
                return string.Format("Guldpris: {0} SEK/g", price.ToString(new CultureInfo("sv-SE")));
            }

            return "Fel";
        }

        public string ParseSilver()
        {
            if (string.IsNullOrEmpty(_allText))
            {
                return null;
            }

            int iGroupingStart = _allText.IndexOf("Silverpriset: ", 0, StringComparison.CurrentCultureIgnoreCase);

            string sTitle = _allText.Substring(iGroupingStart, 35).Trim();
            string sPrice = sTitle.Replace("Silverpriset: ", "");
            string x = sPrice.Substring(0, sPrice.IndexOf("SEK per gram")).Trim();

            float price = 0;
            if (float.TryParse(x, NumberStyles.Currency, new CultureInfo("sv-SE"), out price))
            {
                return string.Format("Silverpris: {0} SEK/g", price.ToString(new CultureInfo("sv-SE")));
            }

            return "Fel";
        }
    }
}