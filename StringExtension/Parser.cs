using System;
using System.Collections.Generic;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (@base < 2 || @base > 16)
            {
                throw new ArgumentOutOfRangeException();
            }

            return DigitArrayToDecimal(StringToDigitArray(source, @base), @base);
        }

        private static bool IsValidStringForCurrentBase(int[] source, int @base)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] >= @base)
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] StringToDigitArray(string source, int @base)
        {
            var digitArray = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                digitArray[i] = ConvertToDigit(source[i]);
            }

            if(!IsValidStringForCurrentBase(digitArray, @base))
            {
                throw new ArgumentException();
            }

            return digitArray;
        }

        private static int ConvertToDigit(char symbol)
        {
            if (char.IsDigit(symbol))
            {
                return (int)char.GetNumericValue(symbol);
            }
            else
            {
                switch (char.ToUpper(symbol))
                {
                    case ('A'): return 10;
                    case ('B'): return 11;
                    case ('C'): return 12;
                    case ('D'): return 13;
                    case ('E'): return 14;
                    case ('F'): return 15;
                    default: throw new ArgumentException();
                }
            }
        }

        private static int DigitArrayToDecimal(int[] digitArray, int @base)
        {
            int result = 0;
            int rank = 1;
            for (int i = digitArray.Length - 1; i >= 0; i--)
            {
                if(result + digitArray[i] * rank >= int.MaxValue)
                {
                    throw new ArgumentException();
                }

                result += digitArray[i] * rank;
                rank *= @base;
            }

            if (result <= 0)
            {
                throw new ArgumentException();
            }

            return result;
        }
    }
}
