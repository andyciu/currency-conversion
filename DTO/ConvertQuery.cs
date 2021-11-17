using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace currency_conversion.DTO
{
    public class ConvertQuery
    {
        [BindRequired]
        public string FromCurrency { get; set; }
        [BindRequired]
        public string ToCurrency { get; set; }
        [BindRequired]
        public decimal Price { get; set; }
    }
}
