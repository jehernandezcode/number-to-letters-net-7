using api_number_at_letters.Models.Dto.Request;
using FluentValidation;

namespace api_number_at_letters.Models.NumberConverter
{
    public class NumberConvertValidator : AbstractValidator<NumberRequestDto>
    {
        public NumberConvertValidator()
        {
            RuleFor((data) => data.Number).GreaterThanOrEqualTo(0).LessThanOrEqualTo(999999999999).NotNull();
        }
    }
}
