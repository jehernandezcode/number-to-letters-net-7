using api_number_at_letters.Models.Dto.Request;
using api_number_at_letters.Models.Dto.Response;
using api_number_at_letters.Services.Autorization;
using Microsoft.AspNetCore.Mvc;

namespace api_number_at_letters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthorizationService _authorizationService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthorizationService authorization)
        {
            _logger = logger;
            _authorizationService = authorization;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto body)
        {
            LoginResponseDto response = await _authorizationService.Token(body);
            return Ok(response);
        }
    }
}
