using api_number_at_letters.Models.Dto.Request;
using api_number_at_letters.Models.Dto.Response;

namespace api_number_at_letters.Services.Autorization
{
    public interface IAuthorizationService
    {
        Task<LoginResponseDto> Token(LoginRequestDto credentials);
    }
}
