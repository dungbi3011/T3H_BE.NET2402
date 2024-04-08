using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Buoi6_BaiTap1
{
    public class Buoi6GenericFucntion<T>
    {
        public Buoi6GenericFunction() { }
        private T[] array;
        public Buoi6GenericFunction(int size)
        {
            array = new T[size + 1];        
        }
        public T getItem (int index)
        {
            return array[index];
        }
        public void setItem(int index, T value)
        {
            array[index] = value;
        }
        public T Tong(T a, T b)
        {

        }

    }
}
