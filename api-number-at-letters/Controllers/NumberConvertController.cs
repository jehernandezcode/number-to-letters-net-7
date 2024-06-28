using api_number_at_letters.Filters;
using api_number_at_letters.Models.Dto;
using api_number_at_letters.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_number_at_letters.Controllers
{
    [TypeFilter(typeof(GlobalExceptionsFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class NumberConvertController : ControllerBase
    {
        private readonly ILogger<NumberConvertController> _logger;
        private readonly INumberConverter _converterService;
        public NumberConvertController(ILogger<NumberConvertController> logger, INumberConverter converterService)
        {
            _logger = logger;
            _converterService = converterService;
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  ActionResult<NumberConvertDto> NumberToString([FromBody] NumberRequestDto body)
        {
            _logger.LogInformation($"Number Converter Controller - se solicita convertir el numero {body.Number} a su pronunciacion en español");
            var resultConverter = _converterService.NumberToString(body);
            _logger.LogInformation($"Number Converter Controller - el numero {body.Number} ha sido traducido como: {resultConverter}");
            return Ok(new NumberConvertDto { NumberString = resultConverter });
        }
    }
}
