using System.ComponentModel.DataAnnotations;

namespace api_number_at_letters.Models.Dto
{
    public class NumberRequestDto
    {
        [Required]
        public long Number { get; set; }
    }
}
