
namespace api_number_at_letters.Models.NumberConverter
{
    public static class NumberConverter
    {
        public static string[] units = { "", "un", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        public static string[] tens = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        public static string[] hundreds = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
        public static string[] specials = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };


        static Dictionary<long, string> escale = new Dictionary<long, string>
    {
        {1000000000, "billón"},
        {1000000, "millón"},
        {1000, "mil"}
    };
        public static string PronuntiationString(this long number) {

            if (number == 0) return "cero";

            List<string> words = new List<string>();

            foreach (var scale in escale)
            {
                if (number >= scale.Key)
                {
                    long quantityScale = number / scale.Key;
                    number %= scale.Key;

                    if (quantityScale == 1 && scale.Key >= 1000000)
                    {
                        words.Add("un " + scale.Value);
                    }
                    else
                    {
                        words.Add(ConvertSpecials(quantityScale) + " " + scale.Value + (quantityScale > 1 && scale.Key >= 1000000 ? "es" : ""));
                    }
                }
            }

            if (number > 0)
            {
                words.Add(ConvertSpecials(number));
            }

            if (words.Count() == 0)
            {
                return "Not posible convert";
            }

            return string.Join(" ", words).Trim();
        }


        static string ConvertSpecials(long number)
        {
            List<string> words = new List<string>();

            if (number >= 100)
            {
                if (number == 100) words.Add("cien");
                else words.Add(hundreds[number / 100]);
                number %= 100;
            }

            if (number >= 20)
            {
                words.Add(tens[number / 10]);
                if (number % 10 > 0) words.Add("y " + units[number % 10]);
            }
            else if (number >= 10)
            {
                words.Add(specials[number - 10]);
            }
            else if (number > 0)
            {
                words.Add(units[number]);
            }

            return string.Join(" ", words).Trim();
        }

    }
}
