using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api_number_at_letters.Models.Dto.Request
{
    public class LoginRequestDto
    {
        [Required]
        [DefaultValue("userConverter")]
        public string UserName { get; set; }

        [Required]
        [DefaultValue("123456789")]
        public string Password { get; set; }
    }
}
