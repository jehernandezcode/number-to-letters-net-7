using api_number_at_letters.Models;
using api_number_at_letters.Models.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_number_at_letters.Services
{
    public class NumberConverterService : INumberConverter
    {
        private readonly ILogger<NumberConverterService> _logger;

        public NumberConverterService(ILogger<NumberConverterService> logger)
        {
            _logger = logger;
        }
        public string NumberToString(NumberRequestDto data)
        {
            _logger.LogInformation($"Number Converter Service - numero {data.Number} para convertir");
            var resultConvert = data.Number.PronuntiationString();
            _logger.LogInformation($"Number Converter Service - numero {data.Number} equivalente a: {resultConvert}");
            return resultConvert;
        }
    }
}
