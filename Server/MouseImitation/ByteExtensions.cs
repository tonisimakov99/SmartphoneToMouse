using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseImitation
{
    static class ByteExtensions
    {
        public const byte Minus = 45;

        public static byte GetByteByDigit(int digit)
        {
            return (byte)(digit + 48);
        }

        public static int GetDigit(this byte b)
        {
            return b - 48;
        }

        public static bool IsDigit(this byte b)
        {
            return b > 47 && b < 58;
        }
    }
}
