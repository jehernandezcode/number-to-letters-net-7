using api_number_at_letters.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_number_at_letters.Models.NumberConverter
{
    public static class NumberConverter
    {
    static string[] units = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
    static string[] tens = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
    static string[] hundreds = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
    static string[] specials = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };


    static Dictionary<long, string> escale = new Dictionary<long, string>
    {
        {1000000000000, "billón"},
        {1000000000, "mil millones"},
        {1000000, "millón"},
        {1000, "mil"}
    };
        public static string PronuntiationString(this long number) {

            if (number == 0) return "cero";
            //if (numero < 0) return "menos " + ConvertirATexto(Math.Abs(numero));

            List<string> words = new List<string>();

            foreach (var escala in escale)
            {
                if (number >= escala.Key)
                {
                    long cantidadEscala = number / escala.Key;
                    number %= escala.Key;

                    if (cantidadEscala == 1 && escala.Key >= 1000000)
                    {
                        words.Add("un " + escala.Value);
                    }
                    else
                    {
                        words.Add(PronuntiationString(cantidadEscala) + " " + escala.Value + (cantidadEscala > 1 && escala.Key >= 1000000 ? "es" : ""));
                    }
                }
            }

            if (number > 0)
            {
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
            }

            return string.Join(" ", words).Trim();
        }

    }
}
