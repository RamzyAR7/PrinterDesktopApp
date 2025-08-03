using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public static class PriceEncrypt
    {
        private const int Scale = 2;
        private const int Secret = 5372;

        public static int EncryptPrice(decimal price)
        {
            int scaled = (int)(price * Scale);
            int encoded = scaled + Secret;
            return encoded;
        }
    }
}
