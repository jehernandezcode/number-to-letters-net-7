using api_number_at_letters.Models.Dto;
using FluentValidation;

namespace api_number_at_letters.Models
{
    public class NumberConvertValidator: AbstractValidator<NumberRequestDto>
    {
        public NumberConvertValidator()
        {
            RuleFor((data) => data.Number).GreaterThanOrEqualTo(0).LessThanOrEqualTo(999999999999).NotNull();
        }
    }
}
