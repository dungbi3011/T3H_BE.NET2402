using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6_BTVN2
{
    // Class sinhVien
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
    }

    // Class quanLySinhVien su dung Dictionary
    public class quanLy
    {
        public Dictionary<string, sinhVien> danhSachSinhVien = new Dictionary<string, sinhVien>();

        // AddItem them sinh vien vao danh sach
        public void AddItem(string id, sinhVien SinhVien)
        {
            danhSachSinhVien[id] = SinhVien; //Tim kiem sinh vien qua ID
        }

        // GetItem lay thong tin sinh vien
        public sinhVien GetItem(string id)
        {
            if (danhSachSinhVien.ContainsKey(id))
            {
                return danhSachSinhVien[id];
            }
            else
            {
                throw new KeyNotFoundException("Khong tim thay sinh vien co ID " + id);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tao 1 instance cua quanLy
            quanLy quanLySinhVien = new quanLy();

            // Them sinh vien vao danh sach
            quanLySinhVien.AddItem("SWH00420", new sinhVien("SWH00420", "Tran Quoc Dung", 20));
            quanLySinhVien.AddItem("SWH00566", new sinhVien("SWH00566", "Nguyen QUang Minh", 20));

            // Lay thong tin sinh vien qua ID
            try
            {
                sinhVien SinhVien = quanLySinhVien.GetItem("SWH00420");
                Console.WriteLine($"ID: {SinhVien.id}, Ho ten: {SinhVien.name}, Tuoi: {SinhVien.age}");
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
