using System.ComponentModel.DataAnnotations;

namespace api_number_at_letters.Models.Dto.Request
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
