using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currency_conversion.DTO
{
    public class CurrencyData
    {
        public CurrencyFrom Currencies { get; set; }
    }

    public class CurrencyFrom
    {
        public CurrencyPrice TWD { get; set; }
        public CurrencyPrice JPY { get; set; }
        public CurrencyPrice USD { get; set; }
    }

    public class CurrencyPrice
    {
        public decimal TWD { get; set; }
        public decimal JPY { get; set; }
        public decimal USD { get; set; }
    }
}
