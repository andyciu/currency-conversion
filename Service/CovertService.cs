using currency_conversion.DTO;
using currency_conversion.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace currency_conversion.Service
{
    public class CovertService: ICovertService
    {
        public string BasicConvert(ConvertQuery query)
        {
            StreamReader reader = new StreamReader("currencyData.json");
            string json = reader.ReadToEnd();
            CurrencyData currencyData = JsonConvert.DeserializeObject<CurrencyData>(json);

            var fromCurrencyObj = query.FromCurrency switch
            {
                "TWD" => currencyData.Currencies.TWD,
                "JPY" => currencyData.Currencies.JPY,
                "USD" => currencyData.Currencies.USD,
                _ => null
            };

            if (fromCurrencyObj == null)
            {
                return null;
            }

            var priceChoose = query.ToCurrency switch
            {
                "TWD" => fromCurrencyObj.TWD,
                "JPY" => fromCurrencyObj.JPY,
                "USD" => fromCurrencyObj.USD,
                _ => 0
            };

            var priceresult = query.Price * priceChoose;
            var result = priceresult.ToString("N", CultureInfo.CreateSpecificCulture("en-US"));

            return result;
        }
    }
}
