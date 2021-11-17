using currency_conversion.DTO;
using currency_conversion.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace currency_conversion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly ILogger<ConvertController> _logger;
        private readonly ICovertService _covertService;

        public ConvertController(ILogger<ConvertController> logger, ICovertService covertService)
        {
            _logger = logger;
            _covertService = covertService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ConvertRes> Get([FromQuery] ConvertQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.FromCurrency) || string.IsNullOrWhiteSpace(query.ToCurrency) || query.Price < 0)
            {
                return NotFound();
            }

            string result = _covertService.BasicConvert(query);
            if (result == null)
            {
                return NotFound();
            }

            return new ConvertRes
            {
                Result = result
            };
        }
    }
}
