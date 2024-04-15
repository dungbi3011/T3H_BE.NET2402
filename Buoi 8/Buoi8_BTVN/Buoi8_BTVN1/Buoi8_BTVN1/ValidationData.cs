using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_BTVN1
{
    public static class ValidationData
    {
        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool KiemTraInputChu(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            if (CheckXSSInput(input) == false)
            {
                return false;
            }
            return true;
        }

        public static bool KiemTraInputSo(string input)
        {
            if (!long.TryParse(input, out long number))
            {
                return false;
            }
            if (long.TryParse(input, out number))
            {
                if (number < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}