using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstDate = DateTime.Now.AddDays(10);
            var secondDate = DateTime.Now.AddDays(10);

            var result = DateTime.Compare(firstDate, secondDate);
            Console.WriteLine("result = " + result);

            string date_string = "15/04/2024";

            var dateFromString = DateTime.ParseExact(date_string, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("dateFromString = " + dateFromString.ToString("yyyy/MM/dd"));

            var subdate = DateTime.Now - new DateTime(2024, 04, 01);

            Console.WriteLine("subdate = " + subdate.Days);

            Console.ReadKey();
        }
    }
}
