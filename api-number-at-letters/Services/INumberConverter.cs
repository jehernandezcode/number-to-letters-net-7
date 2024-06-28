using api_number_at_letters.Models.Dto;

namespace api_number_at_letters.Services
{
    public interface INumberConverter
    {
        string NumberToString(NumberRequestDto data);
    }
}
