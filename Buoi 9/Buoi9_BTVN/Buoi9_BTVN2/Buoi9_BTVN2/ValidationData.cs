using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_BTVN2
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

        public static bool KiemTraInputHocPhi(string input)
        {
            if (!Decimal.TryParse(input, out decimal HocPhi))
            {
                return false;
            }
            if (Decimal.TryParse(input, out HocPhi))
            {
                if (HocPhi < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool KiemTraInputNgaySinh(string input)
        {
            bool checkDate = DateTime.TryParseExact(input, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime ngayHopLe);
            if (!checkDate || ngayHopLe >= DateTime.Today)
            {
                return false;
            }
            return true;
        }

        public static bool KiemTraInputNgayKhaiGiang(string input)
        {
            bool checkDate = DateTime.TryParseExact(input, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime ngayHopLe);
            if (!checkDate || ngayHopLe < DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
}
