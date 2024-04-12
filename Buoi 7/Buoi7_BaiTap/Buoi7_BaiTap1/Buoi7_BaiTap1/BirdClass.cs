using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi7_BaiTap1
{
    public class BirdClass : Animal

    {
        public override string Eat()
        {
            return "An sau";
        }

        public override string Sound()
        {
            return "Chip Chip";
        }
    }
}
