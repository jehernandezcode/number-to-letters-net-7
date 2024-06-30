using api_number_at_letters.Models.Dto.Request;

namespace api_number_at_letters.Services.NumberConverter
{
    public interface INumberConverter
    {
        string NumberToString(NumberRequestDto data);
    }
}
