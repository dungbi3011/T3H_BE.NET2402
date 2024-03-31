using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4_BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student hocsinh = new Student();
            Console.WriteLine($"Nhap thong tin hoc sinh ");
            Console.Write("Id hoc sinh: ");
            hocsinh.id = Console.ReadLine();
            Console.Write("\nTen hoc sinh: ");
            hocsinh.name = Console.ReadLine();
            Console.Write("\nGioi tinh hoc sinh: ");
            hocsinh.gioi_tinh = Console.ReadLine();
            Console.Write("\nTuoi hoc sinh: ");
            hocsinh.age = Int32.Parse(Console.ReadLine());
            Console.ReadKey();
        }
    }

    public struct Student
    {
        public string id;
        public string name;
        public string gioi_tinh;
        public int age;

        public Student(string _id, string _name, string _gioi_tinh, int _age)
        {
            id = _id;
            name = _name;
            gioi_tinh = _gioi_tinh;
            age = _age;
        }
    }
}
