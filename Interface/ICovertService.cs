using currency_conversion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currency_conversion.Interface
{
    public interface ICovertService
    {
        string BasicConvert(ConvertQuery query);
    }
}
