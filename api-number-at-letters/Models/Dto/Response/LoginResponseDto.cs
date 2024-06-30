using System.ComponentModel.DataAnnotations;

namespace api_number_at_letters.Models.Dto.Response
{
    public class LoginResponseDto
    {
        [Required]
        public string Token { get; set; }
    }
}
