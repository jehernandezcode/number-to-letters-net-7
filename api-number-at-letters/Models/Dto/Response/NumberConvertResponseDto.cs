using System.ComponentModel.DataAnnotations;

namespace api_number_at_letters.Models.Dto.Response
{
    public class NumberConvertResponseDto
    {
        [Required]
        [MaxLength(350)]
        public string NumberString { get; set; }
    }
}
