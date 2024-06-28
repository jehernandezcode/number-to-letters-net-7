using System.ComponentModel.DataAnnotations;

namespace api_number_at_letters.Models.Dto
{
    public class NumberConvertDto
    {
        [Required]
        [MaxLength(5)]
        public string NumberString { get; set; }
    }
}
