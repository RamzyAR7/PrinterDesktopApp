using System;
using DesktopApp.Utilities;

namespace DesktopApp.Tests
{
    public static class ArabicNumberTest
    {
        public static void TestArabicConversion()
        {
            // Test the Arabic number conversion
            decimal testAmount = 86225m;
            string arabicResult = ArabicNumberConverter.ConvertDecimalToArabic(testAmount);
            
            Console.WriteLine($"Original: {testAmount}");
            Console.WriteLine($"Arabic: {arabicResult}");
            Console.WriteLine($"Expected: ٨٦,٢٢٥");
            
            // Test with different numbers
            decimal[] testNumbers = { 86225m, 17245m, 5m, 20m, 86205m };
            
            foreach (var number in testNumbers)
            {
                string arabic = ArabicNumberConverter.ConvertDecimalToArabic(number);
                Console.WriteLine($"{number} -> {arabic}");
            }
        }
    }
}
