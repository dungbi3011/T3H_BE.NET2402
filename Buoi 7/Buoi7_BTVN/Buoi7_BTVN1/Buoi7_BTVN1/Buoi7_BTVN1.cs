using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi7_BTVN1
{
    // Class Book chua thong tin ve sach
    class Sach
    {
        public string title { get; set; }
        public string author { get; set; }
        public string ibsn { get; set; }
        public double price { get; set; }

        public Sach(string Title, string Author, string IBSN, double Price)
        {
            title = Title;
            author = Author;
            ibsn = IBSN;
            price = Price;
        }

        public override string ToString()
        {
            return $"Title: {title} - Author: {author} - ISBN: {ibsn} - Price: {price} VND";
        }
    }

    // Class Library quan ly thu vien sach
    class ThuVien
    {
        private List<Sach> thuVien = new List<Sach>();

        public void themSach(Sach sach)
        {
            thuVien.Add(sach);
        }

        //Phuong thuc tim sach qua ten
        public Sach timSach_Ten(string Title)
        {
            return thuVien.Find(s => s.title.Equals(Title, StringComparison.OrdinalIgnoreCase));
        }

        //Phuong thuc tim sach qua tac gia
        public Sach timSach_TacGia(string Author)
        {
            return thuVien.Find(s => s.author.Equals(Author, StringComparison.OrdinalIgnoreCase));
        }

        //Phuong thuc tim sach qua IBSN
        public Sach timSach_IBSN(string IBSN)
        {
            return thuVien.Find(s => s.ibsn.Equals(IBSN, StringComparison.OrdinalIgnoreCase));
        }

        // Phuong thuc muon sach
        public void muonSach(Sach sach)
        {
            Console.WriteLine($"Muon sach: {sach.title}");
        }

        // Phuong thuc tra sach
        public void traSach(Sach sach)
        {
            Console.WriteLine($"Tra sach: {sach.title}");
        }
    }
    internal class Buoi7_BTVN1
    {
        ThuVien thuVien = new ThuVien();
        // Check neu Input co ma doc
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

        // Check tat ca loi cua Input
        public bool KiemTraLoi (string Title, string Author, string IBSN, string price)
        {
            if (string.IsNullOrWhiteSpace(Title)) 
            {
                Console.WriteLine("Ten sach khong duoc de trong.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Author))
            {
                Console.WriteLine("Ten tac gia khong duoc de trong.");
                return false;
            }
            if (Author.Any(char.IsDigit)) 
            {
                Console.WriteLine("Ten tac gia khong duoc chua so.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(IBSN))
            {
                Console.WriteLine("IBSN cua sach khong duoc de trong.");
                return false;
            }
            if (CheckXSSInput(Title) == false || CheckXSSInput(Author) == false || CheckXSSInput(IBSN) == false)
            {
                Console.WriteLine("Thong tin cua sach KHONG DUOC PHEP CHUA MA DOC.");
                return false;
            }
            int Price;
            if (!int.TryParse(price, out Price))
            {
                Console.WriteLine("Gia cua sach phai la so tu nhien > 0 hoac < 10000000.");
                return false;
            }
            if (int.TryParse(price, out Price))
            {
                if (Price <= 0 || Price >= 10000000)
                {
                    Console.WriteLine("Gia cua sach phai la so tu nhien > 0 hoac < 10000000.");
                    return false;
                }
            }
            return true;
        }
        public bool KiemTraInputSoSach(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("So sach phai la so tu nhien > 0 va < 100.");
                return false;
            }
            if (int.TryParse(input, out number))
            {
                if (number <= 0 || number >= 100)
                {
                    Console.WriteLine("So sach phai la so tu nhien > 0 va < 100.");
                    return false;
                }
            }
            return true;
        }

        public void nhapThongTinSach(int n) // Tham so n. So luong sach la n.
        {
            Console.WriteLine("Bat dau chuong trinh them sach vao thu vien.");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin sach thu " + (i + 1) + ":");

                Console.Write("Ten sach: ");
                string Title = Console.ReadLine();

                Console.Write("Ten tac gia: ");
                string Author = Console.ReadLine();

                Console.Write("Ma IBSN cua sach: ");
                string IBSN = Console.ReadLine();

                Console.Write("Tri gia cua sach: ");
                string price = Console.ReadLine();

                if (KiemTraLoi(Title, Author, IBSN, price)) // Neu khong co loi thi add sach vao thuVien
                {
                    int Price = Convert.ToInt32(price);
                    thuVien.themSach(new Sach(Title, Author, IBSN, Price));
                    Console.WriteLine($"Them sach {Title} vao thu vien thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin sach. Chuong trinh xin bo qua thong tin cua sach thu {i + 1}.");
                }
            }
        }

        public void BTVN1()
        {
            Console.WriteLine("-----------THU VIEN SACH--------------");
            Console.WriteLine("1. Them sach vao thu vien.");
            Console.WriteLine("2. Tim kiem sach thong qua ten tac gia.");
            Console.WriteLine("3. Tim kiem sach thong qua ma IBSN.");
            Console.WriteLine("4. Muon sach.");
            Console.WriteLine("5. Tra sach.");
            Console.WriteLine("0. Thoat khoi chuong trinh.");
            // Viết menu chương trình 
            while (true)
            {
                Console.Write("\nChon mot chuc nang (nhap so tu 0-5): ");
                int luachon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                while (isNumeric == false || luachon < 0 || luachon > 5)
                {
                    Console.Write("Vui long nhap lai lua chon chuc nang (0-5): ");
                    isNumeric = int.TryParse(Console.ReadLine(), out luachon);
                }

                switch (luachon)
                {
                    case 1:
                        Console.Write("Nhap so luong sach can them: ");
                        string n = Console.ReadLine();
                        while (!KiemTraInputSoSach(n))
                        {
                            Console.Write("Vui long nhap lai so sach can them: ");
                            n = Console.ReadLine();
                        }
                        int N = Convert.ToInt32(n);
                        nhapThongTinSach(N);
                        break;
                    case 2:
                        Console.Write("Nhap ten tac gia cua sach can tim: ");
                        string tacGia = Console.ReadLine();
                        Sach sachTimKiem1 = thuVien.timSach_TacGia(tacGia);
                        if (sachTimKiem1 != null)
                        {
                            Console.WriteLine($"Ket qua tim kiem:\n{sachTimKiem1}");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay ket qua.");
                        }
                        break;
                    case 3:
                        Console.Write("Nhap ma IBSN cua sach can tim: ");
                        string IBSN = Console.ReadLine();
                        Sach sachTimKiem2 = thuVien.timSach_IBSN(IBSN);
                        if (sachTimKiem2 != null)
                        {
                            Console.WriteLine($"Ket qua tim kiem:\n{sachTimKiem2}");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay ket qua.");
                        }
                        break;
                    case 4:
                        Console.Write("Nhap ten cuon sach can muon: ");
                        string Ten1 = Console.ReadLine();
                        Sach sachCanMuon = thuVien.timSach_Ten(Ten1);
                        if (sachCanMuon != null)
                        {
                            Console.WriteLine($"Sach can muon:\n{sachCanMuon}");
                            Console.WriteLine("Muon sach thanh cong!");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay ket qua.");
                        }
                        break;
                    case 5:
                        Console.Write("Nhap ten cuon sach can tra: ");
                        string Ten2 = Console.ReadLine();
                        Sach sachCanTra = thuVien.timSach_Ten(Ten2);
                        if (sachCanTra != null)
                        {
                            Console.WriteLine($"Sach can tra:\n{sachCanTra}");
                            Console.WriteLine("Tra sach thanh cong!");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay ket qua.");
                        }
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }

        }
    }
}
