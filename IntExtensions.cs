using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseImitation
{
    static class IntExtensions
    {
        public static int GetNumber(byte[] digits)
        {
            var endIndex = 0;
            if (digits[0] == ByteExtensions.Minus)
                endIndex = 1;
            var number = 0;
            var pow = 1;
            for (var i = digits.Length - 1; i >= endIndex; i--, pow *= 10)
                number += digits[i].GetDigit() * pow;
            return digits[0] != ByteExtensions.Minus ? number : -number;
        }

        public static byte[] ToBytes(this int number)
        {
            var minus = new byte[0];
            if (number < 0)
                minus = new byte[] { ByteExtensions.Minus };
            return minus
                .Concat(number.GetDigits().Select(d => ByteExtensions.GetByteByDigit(d))).ToArray();
        }

        public static int[] GetDigits(this int number)
        {
            var result = new Stack<int>();
            number = Math.Abs(number);
            do
            {
                result.Push(number % 10);
                number /= 10;
            }
            while (number > 0);
            return result.ToArray();
        }
    }
}
