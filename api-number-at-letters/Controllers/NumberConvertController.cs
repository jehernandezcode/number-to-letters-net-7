using api_number_at_letters.Models;
using api_number_at_letters.Models.Dto.Request;
using api_number_at_letters.Models.Dto.Response;
using api_number_at_letters.Services.NumberConverter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_number_at_letters.Controllers
{
    [Tags("NumberConverter")]
    [Route("api/[controller]")]
    [ApiController]
    public class NumberConvertController : ControllerBase
    {
        private readonly ILogger<NumberConvertController> _logger;
        private readonly INumberConverter _converterService;
        protected ApiResponse _response;
        public NumberConvertController(ILogger<NumberConvertController> logger, INumberConverter converterService)
        {
            _logger = logger;
            _converterService = converterService;
            _response = new ApiResponse();
        }

        [Authorize]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public  ActionResult<ApiResponse> NumberToString([FromBody] NumberRequestDto body)
        {
            _logger.LogInformation($"Number Converter Controller - se solicita convertir el numero {body.Number} a su pronunciacion en español");
            var resultConverter = _converterService.NumberToString(body);
            _logger.LogInformation($"Number Converter Controller - el numero {body.Number} ha sido traducido como: {resultConverter}");

            _response.Result = new NumberConvertResponseDto { NumberString = resultConverter };
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
