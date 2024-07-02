using api_number_at_letters.Controllers;
using api_number_at_letters.Models.Dto.Request;
using api_number_at_letters.Services.NumberConverter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_number_at_letters_unit_test
{
    public class NumberConvertTest
    {

        private readonly NumberConvertController _controller;
        private readonly INumberConverter _numberConverterService;
        private readonly ILogger<NumberConvertController> _logger;

        public NumberConvertTest()
        {
            _logger = new Mock<ILogger<NumberConvertController>>();
            _numberConverterService = new NumberConverterService(null);
            _controller = new NumberConvertController(_logger, _numberConverterService);
        }

        [Fact]
        public void PostOk()
        {
            var body = new NumberRequestDto
            {
                Number = 1
            };
            var result = _controller.NumberToString(body);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}