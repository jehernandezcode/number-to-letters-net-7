using api_number_at_letters.Models;
using api_number_at_letters.Models.Dto.Request;
using api_number_at_letters.Models.Dto.Response;
using api_number_at_letters.Services.Autorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace api_number_at_letters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthorizationService _authorizationService;
        protected ApiResponse _response;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthorizationService authorization)
        {
            _logger = logger;
            _authorizationService = authorization;
            _response = new ApiResponse();
        }

        [HttpPost()]
        [SwaggerOperation(Summary = "Servicio para authorizar una usuario con nombre y contraseña, este retorna un token usado en otros servicios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginRequestDto body)
        {
            LoginResponseDto data = await _authorizationService.Token(body);
            _response.Result = new LoginResponseDto { Token = data.Token};
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
