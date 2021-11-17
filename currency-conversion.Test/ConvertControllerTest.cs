using currency_conversion.Controllers;
using currency_conversion.DTO;
using currency_conversion.Interface;
using currency_conversion.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace currency_conversion.Test
{
    public class ConvertControllerTest
    {
        ConvertController _convertController;
        ICovertService _covertService;

        public ConvertControllerTest()
        {
            var logger = Mock.Of<ILogger<ConvertController>>();
            _covertService = new CovertService();
            _convertController = new ConvertController(logger, _covertService);
        }

        [Fact]
        public void SuccessTest1()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "JPY",
                ToCurrency = "TWD",
                Price = 3333
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var resultObj = result.Result as OkObjectResult;
            Assert.IsType<ConvertRes>(resultObj.Value);

            var resData = resultObj.Value as ConvertRes;

            Assert.Equal("898.44", resData.Result);
        }

        [Fact]
        public void SuccessTest2()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "TWD",
                ToCurrency = "USD",
                Price = 2222
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var resultObj = result.Result as OkObjectResult;
            Assert.IsType<ConvertRes>(resultObj.Value);

            var resData = resultObj.Value as ConvertRes;

            Assert.Equal("72.90", resData.Result);
        }

        [Fact]
        public void SuccessTest3()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "USD",
                ToCurrency = "JPY",
                Price = 77
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var resultObj = result.Result as OkObjectResult;
            Assert.IsType<ConvertRes>(resultObj.Value);

            var resData = resultObj.Value as ConvertRes;

            Assert.Equal("8,608.68", resData.Result);
        }

        [Fact]
        public void SuccessTest4()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "TWD",
                ToCurrency = "TWD",
                Price = 10000
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var resultObj = result.Result as OkObjectResult;
            Assert.IsType<ConvertRes>(resultObj.Value);

            var resData = resultObj.Value as ConvertRes;

            Assert.Equal("10,000.00", resData.Result);
        }

        [Fact]
        public void SuccessTest5()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "JPY",
                ToCurrency = "TWD",
                Price = 0
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var resultObj = result.Result as OkObjectResult;
            Assert.IsType<ConvertRes>(resultObj.Value);

            var resData = resultObj.Value as ConvertRes;

            Assert.Equal("0.00", resData.Result);
        }

        [Fact]
        public void FailedTest1()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = null,
                ToCurrency = "JPY",
                Price = 88888
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsNotType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void FailedTest2()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "TWD",
                ToCurrency = "JPY",
                Price = -87
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsNotType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void FailedTest3()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "KRW",
                ToCurrency = "JPY",
                Price = 300000
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsNotType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void FailedTest4()
        {
            //Arrange
            var data = new ConvertQuery
            {
                FromCurrency = "JPY",
                ToCurrency = "CNY",
                Price = 1000000
            };
            //Act
            var result = _convertController.Get(data);
            //Assert
            Assert.IsNotType<OkObjectResult>(result.Result);
        }
    }
}
