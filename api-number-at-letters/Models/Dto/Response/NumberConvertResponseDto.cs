using System.ComponentModel.DataAnnotations;

namespace api_number_at_letters.Models.Dto.Response
{
    public class NumberConvertResponseDto
    {
        [Required]
        [MaxLength(5)]
        public string NumberString { get; set; }
    }
}
