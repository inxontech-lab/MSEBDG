using System.Globalization;

namespace Shared
{
    public class BanglaDate
    {
        public string? ToBanglaDate(DateTime? date)
        {
            var banglaCulture = new CultureInfo("bn-BD");
            string? formatted = date?.ToString("dd-MMMM-yyyy", banglaCulture);

            // Replace English digits with Bangla digits
            string[] englishDigits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] banglaDigits = { "০", "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯" };

            for (int i = 0; i < 10; i++)
            {
                formatted = formatted?.Replace(englishDigits[i], banglaDigits[i]);
            }

            return formatted;
        }
    }
}
