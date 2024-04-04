using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_BaiTap3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstStr = "first_string,";
            var secondStr = "frist_string";

            var compare = String.Compare(firstStr, secondStr);
            Console.WriteLine("compare: " + compare);

            var strReplace = firstStr.Replace("f", "F");
            Console.WriteLine("strReplace: " + strReplace);

            var strSplit = firstStr.Split('_');

            foreach (var item in strSplit)
            {
                Console.WriteLine("item split: " + item);
            }

            var subStr = firstStr.Substring(0, firstStr);

            Console.ReadKey();
        }
    }
}
