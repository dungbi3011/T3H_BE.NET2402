using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN3
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

        public static bool KiemTraInputSoLuong(string input)
        {
            if (!int.TryParse(input, out int soLuong))
            {
                return false;
            }
            if (int.TryParse(input, out soLuong))
            {
                if (soLuong < 1 || soLuong > 100)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool KiemTraInputGia(string input)
        {
            if (!Decimal.TryParse(input, out decimal Gia))
            {
                return false;
            }
            if (Decimal.TryParse(input, out Gia))
            {
                if (Gia < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
