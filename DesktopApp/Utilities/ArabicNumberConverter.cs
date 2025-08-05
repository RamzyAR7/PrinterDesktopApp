using System;
using System.Globalization;

namespace DesktopApp.Utilities
{
    public static class ArabicNumberConverter
    {
        private static readonly char[] ArabicDigits = { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };
        private static readonly char[] EnglishDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// Converts decimal number to Arabic formatted string with Arabic digits
        /// Example: 12000.00 becomes "١٢,٠٠٠"
        /// </summary>
        public static string ConvertDecimalToArabic(decimal number)
        {
            try
            {
                // Format number with thousands separator, no decimal places
                string formattedNumber = number.ToString("N0", CultureInfo.InvariantCulture);
                
                // Convert English digits to Arabic digits
                return ConvertToArabicDigits(formattedNumber);
            }
            catch
            {
                return "٠";
            }
        }

        /// <summary>
        /// Converts decimal number to Arabic formatted string with Arabic digits including decimals
        /// Example: 12000.50 becomes "١٢,٠٠٠.٥٠"
        /// </summary>
        public static string ConvertDecimalToArabicWithDecimals(decimal number)
        {
            try
            {
                // Format number with thousands separator and 2 decimal places
                string formattedNumber = number.ToString("N2", CultureInfo.InvariantCulture);
                
                // Convert English digits to Arabic digits
                return ConvertToArabicDigits(formattedNumber);
            }
            catch
            {
                return "٠.٠٠";
            }
        }

        /// <summary>
        /// Converts integer to Arabic digits
        /// Example: 123 becomes "١٢٣"
        /// </summary>
        public static string ConvertIntegerToArabic(int number)
        {
            try
            {
                string numberString = number.ToString();
                return ConvertToArabicDigits(numberString);
            }
            catch
            {
                return "٠";
            }
        }

        /// <summary>
        /// Converts string containing English digits to Arabic digits
        /// </summary>
        public static string ConvertToArabicDigits(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] result = input.ToCharArray();
            
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < EnglishDigits.Length; j++)
                {
                    if (result[i] == EnglishDigits[j])
                    {
                        result[i] = ArabicDigits[j];
                        break;
                    }
                }
            }
            
            return new string(result);
        }

        /// <summary>
        /// Converts Arabic digits back to English digits (for parsing)
        /// </summary>
        public static string ConvertToEnglishDigits(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] result = input.ToCharArray();
            
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < ArabicDigits.Length; j++)
                {
                    if (result[i] == ArabicDigits[j])
                    {
                        result[i] = EnglishDigits[j];
                        break;
                    }
                }
            }
            
            return new string(result);
        }

        /// <summary>
        /// Formats currency amount in Arabic with currency symbol
        /// Example: 12000.00 becomes "١٢,٠٠٠ ج.م"
        /// </summary>
        public static string FormatCurrencyInArabic(decimal amount, string currencySymbol = "ج.م")
        {
            string formattedAmount = ConvertDecimalToArabic(amount);
            return $"{formattedAmount} {currencySymbol}";
        }

        /// <summary>
        /// Formats date in Arabic style like in the photo: "٢٠٢٥-٠٨-٠١ ١٢:٠٠:٠٠AM"
        /// </summary>
        public static string FormatDateInArabic(DateTime date)
        {
            try
            {
                // Format: yyyy-MM-dd HH:mm:sstt
                string formattedDate = date.ToString("yyyy-MM-dd hh:mm:sstt", System.Globalization.CultureInfo.InvariantCulture);
                
                // Convert English digits to Arabic digits
                return ConvertToArabicDigits(formattedDate);
            }
            catch
            {
                return ConvertToArabicDigits(DateTime.Now.ToString("yyyy-MM-dd hh:mm:sstt"));
            }
        }

        /// <summary>
        /// Formats date in simple Arabic format: "٢٠٢٥-٠٨-٠١"
        /// </summary>
        public static string FormatDateSimpleArabic(DateTime date)
        {
            try
            {
                // Format: yyyy-MM-dd
                string formattedDate = date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                
                // Convert English digits to Arabic digits
                return ConvertToArabicDigits(formattedDate);
            }
            catch
            {
                return ConvertToArabicDigits(DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        /// <summary>
        /// Formats date with slashes in Arabic format: "٢٠٢٥/٠٨/٠١"
        /// </summary>
        public static string FormatDateWithSlashesArabic(DateTime date)
        {
            try
            {
                // Format: yyyy/MM/dd
                string formattedDate = date.ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                
                // Convert English digits to Arabic digits
                return ConvertToArabicDigits(formattedDate);
            }
            catch
            {
                return ConvertToArabicDigits(DateTime.Now.ToString("yyyy/MM/dd"));
            }
        }
    }
}
