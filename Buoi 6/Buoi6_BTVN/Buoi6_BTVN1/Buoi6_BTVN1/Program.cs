using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buoi6_BTVN1
{
    public class quanLy <T>
    {
        public List<T> list = new List<T>();

        // Them phan tu vao danh sach
        public void Add(T item)
        {
            list.Add(item);
        }

        // Xoa phan tu khoi danh sach
        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        // Truy cap 1 phan tu cua danh sach
        public T GetItem(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                return list[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        // Tim kiem 1 phan tu trong danh sach
        public int Find(T item)
        {
            return list.IndexOf(item);
        }
    }

    // Class "Student" de chua thong tin ve hoc sinh
    public class sinhVien
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public sinhVien(string ID, string Name, int Age)
        {
            id = ID;
            name = Name;
            age = Age;
        }

        // Override ham ToString de xuat danh sach sinh vien
        public override string ToString()
        {
            return $"ID - {id} - Ten: {name} - Tuoi: {age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tao 1 instance cua quanLy, kieu du lieu la SinhVien
            quanLy<sinhVien> quanLySinhVien = new quanLy<sinhVien>();

            // Then sinh vien vao danh sach
            quanLySinhVien.Add(new sinhVien("SWH00420", "Tran Quoc Dung", 20));
            quanLySinhVien.Add(new sinhVien("SWH00566", "Nguyen Quang Minh", 20));

            // Xoa sinh vien khoi danh sach
            sinhVien SinhVienBiXoa = new sinhVien("SWH00566", "Nguyen Quang Minh", 20);
            quanLySinhVien.Remove(SinhVienBiXoa);

            // Truy cap sinh vien trong danh sach
            sinhVien SinhVienThuNhat = quanLySinhVien.GetItem(0);
            Console.WriteLine(SinhVienThuNhat);

            // Tim kiem sinh vien trong danh sach qua so thu tu
            int index = quanLySinhVien.Find(new sinhVien("SWH00420", "Tran Quoc Dung", 20));
            Console.WriteLine($"So thu tu cua Tran Quoc Dung la: {index + 1}");

            Console.ReadKey();
        }
    }
}
