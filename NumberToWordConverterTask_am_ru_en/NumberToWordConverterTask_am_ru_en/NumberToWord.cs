using System;

namespace NumberToWord
{
    class Converter
    {
        public static string ConvertToWords(string number, string lang)
        {
            switch (lang)
            {
                case "en":
                    return ConvertToWordsEnglish(number);
                case "am":
                    return ConvertToWordsArmenian(number);
                case "ru":
                    return ConvertToWordsRussian(number);
                default:
                    throw new ArgumentException("Unsupported language");
            }
        }


        private static string ConvertToWordsEnglish(string number)
        {
            if (string.IsNullOrEmpty(number))
                return "";

            string[] unitsMap = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] teensMap = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tensMap = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] thousandsMap = { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion" };

            string[] parts = number.Split('.', ',');
            string integerPart = parts[0];
            string decimalPart = parts.Length > 1 ? parts[1] : "";

            string result = ConvertToWordsEnglishIntegerPart(integerPart, unitsMap, teensMap, tensMap, thousandsMap);

            if (!string.IsNullOrEmpty(decimalPart))
            {
                string decimalWords = ConvertToWordsEnglishDecimalPart(decimalPart, unitsMap, teensMap, tensMap,thousandsMap);
                result += " point " + decimalWords + " ";
            }

            return result.Trim();
        }

        private static string ConvertToWordsEnglishIntegerPart(string number, string[] unitsMap, string[] teensMap, string[] tensMap, string[] thousandsMap)
        {
            if (number.Equals("0"))
                return "Zero";

            int numDigits = number.Length;
            int group = (numDigits + 2) / 3; // Number of groups
            string result = "";

            number = number.PadLeft(group * 3, '0'); // Pad with leading zeros

            for (int i = 0; i < group; i++)
            {
                int hundredsDigit = (int)Char.GetNumericValue(number[i * 3]);
                int tensDigit = (int)Char.GetNumericValue(number[i * 3 + 1]);
                int onesDigit = (int)Char.GetNumericValue(number[i * 3 + 2]);

                string groupInWords = "";

                if (hundredsDigit > 0)
                    groupInWords += unitsMap[hundredsDigit] + " Hundred ";

                if (tensDigit > 1)
                {
                    groupInWords += tensMap[tensDigit] + " ";
                    if (onesDigit > 0)
                        groupInWords += unitsMap[onesDigit];
                }
                else if (tensDigit == 1)
                {
                    groupInWords += teensMap[onesDigit];
                }
                else if (onesDigit > 0)
                {
                    groupInWords += unitsMap[onesDigit];
                }

                if (!string.IsNullOrEmpty(groupInWords))
                {
                    groupInWords += " " + thousandsMap[group - i - 1];
                    result += groupInWords.Trim() + " ";
                }
            }

            return result.Trim();
        }

        private static string ConvertToWordsEnglishDecimalPart(string number, string[] unitsMap, string[] teensMap, string[] tensMap, string[] thousandsMap)
{
            string result = "";
            Console.WriteLine(number);
            while (number[0] == '0')
            {
                Console.WriteLine(number);

                result += " " + "Zero";

                number = number.Substring(1,number.Length-1);
            }

           result += " "+ ConvertToWordsEnglishIntegerPart(number, unitsMap, teensMap, tensMap, thousandsMap);
  

    return result.Trim();
}

        private static string ConvertToWordsRussian(string number)
        {
            if (string.IsNullOrEmpty(number))
                return "";

            string[] unitsMap = { "", "Один", "Два", "Три", "Четыре", "Пять", "Шесть", "Семь", "Восемь", "Девять" };
            string[] teensMap = { "Десять", "Одиннадцать", "Двенадцать", "Тринадцать", "Четырнадцать", "Пятнадцать", "Шестнадцать", "Семнадцать", "Восемнадцать", "Девятнадцать" };
            string[] tensMap = { "", "", "Двадцать", "Тридцать", "Сорок", "Пятьдесят", "Шестьдесят", "Семьдесят", "Восемьдесят", "Девяносто" };
            string[] thousandsMap = { "", "Тысяча", "Миллион", "Миллиард", "Триллион", "Квадриллион", "Квинтиллион", "Секстиллион", "Септиллион", "Октиллион", "Нониллион", "Дециллион" };

            string[] parts = number.Split('.', ',');
            string integerPart = parts[0];
            string decimalPart = parts.Length > 1 ? parts[1] : "";

            string result = ConvertToWordsRussianIntegerPart(integerPart, unitsMap, teensMap, tensMap, thousandsMap);

            if (!string.IsNullOrEmpty(decimalPart) )
            {
                string decimalWords = ConvertToWordsRussianDecimalPart(decimalPart, unitsMap, teensMap, tensMap, thousandsMap);
                result += " и " + decimalWords + " ";
            }

            return result.Trim();
        }

        private static string ConvertToWordsRussianIntegerPart(string number, string[] unitsMap, string[] teensMap, string[] tensMap, string[] thousandsMap)
        {
            if (number.Equals("0"))
                return "Ноль";

            int numDigits = number.Length;
            int group = (numDigits + 2) / 3; // Number of groups
            string result = "";

            number = number.PadLeft(group * 3, '0'); // Pad with leading zeros

            for (int i = 0; i < group; i++)
            {
                int hundredsDigit = (int)Char.GetNumericValue(number[i * 3]);
                int tensDigit = (int)Char.GetNumericValue(number[i * 3 + 1]);
                int onesDigit = (int)Char.GetNumericValue(number[i * 3 + 2]);

                string groupInWords = "";

                if (hundredsDigit > 0)
                    groupInWords += unitsMap[hundredsDigit] + " Сот ";

                if (tensDigit > 1)
                {
                    groupInWords += tensMap[tensDigit] + " ";
                    if (onesDigit > 0)
                        groupInWords += unitsMap[onesDigit];
                }
                else if (tensDigit == 1)
                {
                    groupInWords += teensMap[onesDigit];
                }
                else if (onesDigit > 0)
                {
                    groupInWords += unitsMap[onesDigit];
                }

                if (!string.IsNullOrEmpty(groupInWords))
                {
                    groupInWords += " " + thousandsMap[group - i - 1];
                    result += groupInWords.Trim() + " ";
                }
            }

            return result.Trim();
        }

        private static string ConvertToWordsRussianDecimalPart(string number, string[] unitsMap, string[] teensMap, string[] tensMap, string[] thousandsMap)
        {

            string result = "";
            Console.WriteLine(number);
            while (number[0] == '0')
            {
                Console.WriteLine(number);

                result += " " + "Ноль";

                number = number.Substring(1, number.Length - 1);
            }

            result += " " + ConvertToWordsRussianIntegerPart(number, unitsMap, teensMap, tensMap, thousandsMap);
          
            return result.Trim();
        }

        private static string ConvertToWordsArmenian(string number)
        {
            if (string.IsNullOrEmpty(number))
                return "";

            string[] unitsMap = { "", "Մեկ", "Երկու", "Երեք", "Չորս", "Հինգ", "Վեց", "Յոթ", "Ութ", "Ինը" };
            string[] teensMap = { "Տասը", "Տասնմեկ", "Տասներկու", "Տասներեք", "Տասնչորս", "Տասնհինգ", "Տասնվեց", "Տասնյոթ", "Տասնութ", "Տասնինը" };
            string[] tensMap = { "", "", "Քսան", "Երեսուն", "Քառասուն", "Հիսուն", "Վաթսուն", "Յոթանասուն", "Ութսուն", "Իննսուն" };
            string[] thousandsMap = { "", "Հազար", "Միլիոն", "Բիլիոն", "Թրիլիոն", "Կվադրիլիոն", "Քվինտիլիոն", "Սեքստիլիոն", "Սեպտիլիոն", "Ոկտիլիոն", "Նոնիլիոն", "Դեկտիլիոն" };

            string[] parts = number.Split('.', ',');
            string integerPart = parts[0];
            string decimalPart = parts.Length > 1 ? parts[1] : "";

            string result = ConvertToWordsArmenianIntegerPart(integerPart, unitsMap, teensMap, tensMap, thousandsMap);

            if (!string.IsNullOrEmpty(decimalPart))
            {
                string decimalWords = ConvertToWordsArmenianDecimalPart(decimalPart, unitsMap, teensMap, tensMap, thousandsMap);
                result += " ամբողջ " + decimalWords + " ";
            }

            return result.Trim();
        }

        private static string ConvertToWordsArmenianIntegerPart(string number, string[] unitsMap, string[] teensMap, string[] tensMap, string[] thousandsMap)
        {
            if (number.Equals("0"))
                return "Զրո";

            int numDigits = number.Length;
            int group = (numDigits + 2) / 3; // Number of groups
            string result = "";

            number = number.PadLeft(group * 3, '0'); // Pad with leading zeros

            for (int i = 0; i < group; i++)
            {
                int hundredsDigit = (int)Char.GetNumericValue(number[i * 3]);
                int tensDigit = (int)Char.GetNumericValue(number[i * 3 + 1]);
                int onesDigit = (int)Char.GetNumericValue(number[i * 3 + 2]);

                string groupInWords = "";

                if (hundredsDigit > 0)
                    groupInWords += unitsMap[hundredsDigit] + " Հարյուր ";

                if (tensDigit > 1)
                {
                    groupInWords += tensMap[tensDigit] + " ";
                    if (onesDigit > 0)
                        groupInWords += unitsMap[onesDigit];
                }
                else if (tensDigit == 1)
                {
                    groupInWords += teensMap[onesDigit];
                }
                else if (onesDigit > 0)
                {
                    groupInWords += unitsMap[onesDigit];
                }

                if (!string.IsNullOrEmpty(groupInWords))
                {
                    groupInWords += " " + thousandsMap[group - i - 1];
                    result += groupInWords.Trim() + " ";
                }
            }

            return result.Trim();
        }

        private static string ConvertToWordsArmenianDecimalPart(string number, string[] unitsMap, string[] teensMap, string[] tensMap, string[] thousandsMap)
        {
            string result = "";
            Console.WriteLine(number);
            while (number[0] == '0')
            {
                Console.WriteLine(number);

                result += " " + "Զրո";

                number = number.Substring(1, number.Length - 1);
            }

            result += " " + ConvertToWordsArmenianIntegerPart(number, unitsMap, teensMap, tensMap, thousandsMap);


            return result.Trim();
        }

             
    }
}
