using System;
using System.Collections.Generic;

namespace oop
{
    class NumericalExpression
    {
        Dictionary<int, string> NUMBERSWORD = new Dictionary<int, string>
            {
                { 1, "one " },
                { 2, "two " },
                { 3, "three " },
                { 4, "four " },
                { 5, "five " },
                { 6, "six " },
                { 7, "seven " },
                { 8, "eight " },
                { 9, "nine " },
            };
        Dictionary<int, string> SPECIALDIGITWORD = new Dictionary<int, string>
            {
                { 0, "" },
                { 1, "thousand " },
                { 2, "million " },
                { 3, "billion " }
            };
        Dictionary<int, string> TYDIGITWORD = new Dictionary<int, string>
            {
                { 2, "twenty " },
                { 3, "thirty " },
                { 4, "forty " },
                { 5, "fifty " },
                { 6, "sixty " },
                { 7, "seventy " },
                { 8, "eighty " },
                { 9, "ninety " },
            };

        Dictionary<int, string> TEENDIGITWORD = new Dictionary<int, string>
            {
                { 0, "ten " },
                { 1, "eleven " },
                { 2, "twelve " },
                { 3, "thirteen " },
                { 4, "fourteen " },
                { 5, "fifteen " },
                { 6, "sixteen " },
                { 7, "seventeen " },
                { 8, "eighteen " },
                { 9, "nineteen " },
            };
        public long Value { get; set; }
        public List<int> Digits;
        public NumericalExpression(long value)
        {
            Value = value;
            Digits = DigitsList();
        }
        public override string ToString()
        {
            string numberText = "";
            for(int i = 0; i < Digits.Count; i ++)
            {
                int currentDigit = Digits[i];
                string digitText = "";
                if (currentDigit != 0)
                {
                    digitText = NUMBERSWORD[currentDigit];
                    if (i % 3 == 0)
                        digitText += SPECIALDIGITWORD[i / 3];
                    else if (i % 3 == 1)
                    {
                        if (i == 1 && currentDigit == 1)
                        {
                            digitText = TEENDIGITWORD[Digits[0]];
                            numberText = "";
                        }
                        else
                            digitText = TYDIGITWORD[currentDigit];
                    }
                    else
                        digitText += "hundred ";
                }
                else
                {
                    if (i == 0 && Digits.Count == 1)
                        digitText += "zero ";
                }
                numberText = digitText + numberText;
            }
            return numberText;
        }
        public long GetValue()
        {
            return Value;
        }
        public static long SumLetters(long value)
        {
            long totaltextLength = 0;
            for (long i = 0; i <= value; i ++)
                totaltextLength += new NumericalExpression(i).ToString().Replace(" ", "").Length;
            return totaltextLength;
        }
        public static long SumLetters(NumericalExpression number)
        {
            // overloading -> polymorphism 
            // allows a class to have more than one method 
            // with the same name but different parameters
            long totaltextLength = 0;
            for (long i = 0; i <= number.Value; i++)
                totaltextLength += number.ToString().Replace(" ", "").Length;
            return totaltextLength;
        }
        public List<int> DigitsList()
        {
            long number_backup = Value;
            List<int> digits = new List<int>();
            if (number_backup == 0)
                digits.Add(0);
            while (number_backup != 0)
            {
                digits.Add((int)(number_backup % 10));
                number_backup /= 10;
            }
            return digits;
        }
    }
}
