using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_BTVN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Nhap so phan tu trong mang, va cac phan tu cua mang
            Console.WriteLine("Nhap so phan tu cua mang:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Nhap cac phan tu cho mang:");
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            //1) Hien thi mang cho nguoi dung
            List<int> mang = new List<int>(array);

            // In danh sách ra màn hình
            Console.Write("\n1) Hien thi mang: ");
            foreach (int phan_tu in mang)
            {
                Console.Write(phan_tu + " ");
            }

            //2) Hien thi mang (so chan va so le)
            Console.WriteLine("\n\n2) Hien thi mang so chan va so le");
            Console.Write("Hien thi mang so chan: ");
            foreach (int phan_tu in mang)
            {
                if (phan_tu % 2 == 0)
                {
                    Console.Write(phan_tu + " ");
                }
            }
            Console.Write("\nHien thi mang so le: ");
            foreach (int phan_tu in mang)
            {
                if (phan_tu % 2 == 1)
                {
                    Console.Write(phan_tu + " ");
                }
            }

            //3) Hien thi mang voi thu tu tang va giam dan
            Console.WriteLine("\n\n3) Hien thi mang voi thu tu tang & giam dan");
            int temp = 0;
            Console.Write("Hien thi mang voi thu tu giam dan: ");
            for (int i = 0; i < mang.Count - 1; i++)
            {
                for (int j = 0; j < mang.Count - i - 1; j++)
                {
                    if (mang[j] < mang[j + 1])
                    {
                        temp = mang[j];
                        mang[j] = mang[j + 1];
                        mang[j + 1] = temp;
                    }
                }
            }
            foreach (int phan_tu in mang)
            {
                Console.Write(phan_tu + " ");
            }
            Console.Write("\nHien thi mang voi thu tu tang dan: ");
            for (int i = 0; i < mang.Count - 1; i++)
            {
                for (int j = 0; j < mang.Count - i - 1; j++)
                {
                    if (mang[j] > mang[j + 1])
                    {
                        temp = mang[j];
                        mang[j] = mang[j + 1];
                        mang[j + 1] = temp;
                    }
                }
            }
            foreach (int phan_tu in mang)
            {
                Console.Write(phan_tu + " ");
            }

            //4) Hien thi tong cac so chan va le trong mang
            Console.WriteLine("\n\n4) Hien thi tong cac so chan va so le trong mang");
            Console.Write("Hien thi tong cac so chan: ");
            int sum1 = 0;
            foreach (int phan_tu in mang)
            {
                if (phan_tu % 2 == 0)
                {
                    sum1 += phan_tu;
                }
            }
            Console.WriteLine("Tong cac so chan: " + sum1);
            Console.Write("Hien thi tong cac so le: ");
            int sum2 = 0;
            foreach (int phan_tu in mang)
            {
                if (phan_tu % 2 == 1)
                {
                    sum2 += phan_tu;
                }
            }
            Console.WriteLine("Tong cac so le: " + sum2);

            //5)Viết một hàm để kiểm tra xem một số có phải là số Armstrong không từ mảng lấy ở bước số 1
            Console.Write("\n5) Hien thi cac so Armstrong trong mang: ");
            foreach (int phan_tu in mang)
            {
                if (isArmstrong(phan_tu))
                {
                    Console.Write(phan_tu + " ");
                }
            }

            //6)Viết một hàm để tính tổng của tất cả các số nguyên tố từ mảng lấy ở bước số 1
            Console.Write("\n\n6) Hien thi tong cac so nguyen to trong mang: ");
            int tongNguyenTo = 0;
            foreach (int phan_tu in mang)
            {
                if (isPrime(phan_tu))
                {
                    tongNguyenTo += phan_tu;
                }
            }
            Console.Write(tongNguyenTo);

            //7)Sử dụng tham chiếu để viết hàm tính Tính tổng các số lẻ và tổng các số chẵn từ mảng lấy ở bước số 1
            Console.WriteLine("\n\n7) Hien thi tong cac so chan & le trong mang, su dung tham chieu");
            int tongSoChan = 0;
            int tongSoLe = 0;
            tinhTong(mang, ref tongSoChan, ref tongSoLe);
            Console.WriteLine("Tong cac so chan: " + tongSoChan);
            Console.WriteLine("Tong cac so le: " + tongSoLe);

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.ReadKey();
        }

        //cac function tao then
        static bool isArmstrong(int number)
        {
            int sum = 0, temp = number;
            int so_chu_so = number.ToString().Length;
            while (temp > 0)
            {
                int chu_so = temp % 10;
                sum += (int)Math.Pow(chu_so, so_chu_so);
                temp /= 10;
            }
            return number == sum;
        }

        static bool isPrime(int so)
        {
            if (so <= 1) return false;
            if (so == 2) return true;
            for (int i = 2; i <= (int)Math.Floor(Math.Sqrt(so)); i++)
                if (so % i == 0)
                {
                    return false;
                }
            return true;
        }

        static void tinhTong(List<int> mang, ref int tongSoChan, ref int tongSoLe)
        {
            foreach (int so in mang)
            {
                if (so % 2 == 0)
                {
                    tongSoChan += so;
                } else
                {
                    tongSoLe += so;
                }
            }
        }
    }
}
