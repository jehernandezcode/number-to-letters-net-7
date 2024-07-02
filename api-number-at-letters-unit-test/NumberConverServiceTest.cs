using api_number_at_letters.Models.Dto.Request;
using api_number_at_letters.Models.NumberConverter;
using api_number_at_letters.Services.NumberConverter;
using Microsoft.Extensions.Logging;
using Moq;

namespace api_number_at_letters_unit_test
{
    public class NumberConverServiceTest
    {
        private readonly Mock<ILogger<NumberConverterService>> _loggerService;
        private readonly INumberConverter _numberConverter;

        public NumberConverServiceTest()
        {
            _loggerService = new Mock<ILogger<NumberConverterService>>();
            _numberConverter = new NumberConverterService(_loggerService.Object);
        }

        [Theory]
        [InlineData(1, "un")]
        [InlineData(0, "cero")]
        [InlineData(2451387, "dos millónes cuatrocientos cincuenta y un mil trescientos ochenta y siete")]
        public void NumberConvertOk(long number, string result)
        {
            NumberRequestDto sendNumber = new NumberRequestDto
            {
                Number = number,
            };
            string data = _numberConverter.NumberToString(sendNumber);

            Assert.Equal(result, data);
        }

        [Theory]
        [InlineData(-1, "Not posible convert")]
        [InlineData(-22342332, "Not posible convert")]
        public void NumberConvertFail(long number, string result)
        {
            NumberRequestDto sendNumber = new NumberRequestDto
            {
                Number = number,
            };
            string data = _numberConverter.NumberToString(sendNumber);

            Assert.Equal(result, data);
        }
    }
}
