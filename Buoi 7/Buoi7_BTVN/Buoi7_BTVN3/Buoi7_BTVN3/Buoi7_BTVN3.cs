using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi7_BTVN3
{
    // Class dai dien cho Product
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product (int productID, string productName, double price)
        {
            ProductId = productID;
            ProductName = productName;
            Price = price;
        }
    }

    // Interface IProduct dinh nghia cac ham Insert, Update, Delete, Search
    interface IProduct
    {
        void Insert(Product product);
        void Update(int productId, Product updatedProduct);
        void Delete(int productId);
        Product Search(int productId);
    }

    // Class ImplementIProduct trien khai cac ham trong IProduct
    class ImplementIProduct : IProduct
    {
        private List<Product> products = new List<Product>();

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(int productId, Product updatedProduct)
        {
            Product oldProduct = Search(productId);
            oldProduct.ProductName = updatedProduct.ProductName;
            oldProduct.Price = updatedProduct.Price;
        }

        public Product Search(int productId)
        {
            return products.Find(p => p.ProductId == productId);
        }
        public void Delete(int productId)
        {
            products.Remove(Search(productId));

        }
    }
    internal class Buoi7_BTVN3
    {
        ImplementIProduct khoHang = new ImplementIProduct();
        public bool CheckXSSInput(string input)
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
        public bool KiemTraLoi(string productID, string productName, string price)
        {
            //Check ma & ten san pham
            if (string.IsNullOrWhiteSpace(productID))
            {
                Console.WriteLine("Ma san pham khong duoc de trong.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Ten san pham khong duoc de trong.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(price))
            {
                Console.WriteLine("Gia san pham khong duoc de trong.");
                return false;
            }
            if (CheckXSSInput(productName) == false)
            {
                Console.WriteLine("Ten san pham KHONG DUOC PHEP CHUA MA DOC.");
                return false;
            }
            //Check ma san pham
            int number1;
            if (!int.TryParse(productID, out number1))
            {
                Console.WriteLine("Ma san pham phai la so tu nhien.");
                return false;
            }
            //Check gia san pham
            int number2;
            if (!int.TryParse(price, out number2))
            {
                Console.WriteLine("Gia san pham phai la so tu nhien >= 0.");
                return false;
            }
            if (int.TryParse(price, out number2))
            {
                if (number2 < 0)
                {
                    Console.WriteLine("Gia san pham phai la so tu nhien >= 0.");
                    return false;
                }
            }
            return true;
        }
        public bool KiemTraMaSanPham(string input)
        {
            //Check ma san pham
            int number1;
            if (!int.TryParse(input, out number1))
            {
                Console.WriteLine("Ma san pham phai la so tu nhien.");
                return false;
            }
            return true;
        }
        public bool KiemTraInputSoSanPham(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("So san pham phai la so tu nhien > 0 va < 100.");
                return false;
            }
            if (int.TryParse(input, out number))
            {
                if (number <= 0 || number >= 100)
                {
                    Console.WriteLine("So san pham phai la so tu nhien > 0 va < 100.");
                    return false;
                }
            }
            return true;
        }
        public bool KiemTraChuoiMaID (string input)
        {
            bool checkerViet = input.Split(',').All(id => int.TryParse(id, out int ID));
            if (checkerViet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void nhapSanPham(int n) // Tham so n. So luong san pham can nhap la n.
        {
            Console.WriteLine($"Bat dau chuong trinh nhap vao {n} san pham.");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin san pham thu " + (i + 1) + ":");

                Console.Write("Ma san pham: ");
                string productID = Console.ReadLine();

                Console.Write("Ten san pham: ");
                string ProductName = Console.ReadLine();

                Console.Write("Gia san pham: ");
                string price = Console.ReadLine();

                if (KiemTraLoi(productID, ProductName, price)) // Neu khong co loi thi add san pham vao danh sach
                {
                    int ProductID = Convert.ToInt32(productID);
                    double Price = Convert.ToInt32(price);
                    Product product = new Product(ProductID, ProductName, Price);
                    khoHang.Insert(product);
                    Console.WriteLine("Them san pham vao kho hang thanh cong!");
                }
                else
                {
                    Console.WriteLine($"Xay ra loi khi nhap thong tin san pham. Chuong trinh xin bo qua thong tin cua san pham thu {i + 1}.");
                }
            }
        }
        public void BTVN3()
        {
            Console.WriteLine("-------CHUONG TRINH QUAN LY SAN PHAM---------");
            Console.WriteLine("1. Nhap vao N san pham.");
            Console.WriteLine("2. Hien thi thong tin san pham theo ID.");
            Console.WriteLine("3. Xóa san pham theo ID.");
            Console.WriteLine("4. Update san pham.");
            Console.WriteLine("5. Xoa nhieu san pham cung luc theo ID.");
            Console.WriteLine("0. Thoat");
            //Viet menu chuong trinh
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
                    case 1: //Nhap vao N san pham
                        Console.Write("Nhap so luong san pham can nhap: ");
                        string n1 = Console.ReadLine();
                        while (!KiemTraInputSoSanPham(n1))
                        {
                            Console.Write("Vui long nhap lai so san pham: ");
                            n1 = Console.ReadLine();
                        }
                        int N1 = Convert.ToInt32(n1);
                        nhapSanPham(N1);
                        Console.WriteLine("Hoan thanh nhap danh sach san pham!");
                        break;

                    case 2: //Hien thi san pham theo ID
                        Console.Write("Nhap ma ID cua san pham can hien thi: ");
                        string maSanPham = Console.ReadLine();
                        while (!KiemTraMaSanPham(maSanPham))
                        {
                            Console.Write("Vui long nhap lai ma san pham: ");
                            maSanPham = Console.ReadLine();
                        }
                        int MaSanPham = Convert.ToInt32(maSanPham);
                        Product sanPhamTimKiem = khoHang.Search(MaSanPham);
                        if (sanPhamTimKiem != null)
                        {
                            Console.WriteLine($"Ma san pham: {sanPhamTimKiem.ProductId} - Ten san pham: {sanPhamTimKiem.ProductName} - Gia san pham: {sanPhamTimKiem.Price} VND");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay ma san pham tuong ung.");
                        }
                        break;

                    case 3: //Xoa san pham thong qua ma ID cua san pham
                        Console.Write("Nhap ma ID cua san pham can xoa: ");
                        string maSanPhamCanXoa = Console.ReadLine();
                        while (!KiemTraMaSanPham(maSanPhamCanXoa))
                        {
                            Console.Write("Vui long nhap lai ma san pham: ");
                            maSanPhamCanXoa = Console.ReadLine();
                        }
                        int MaSanPhamCanXoa = Convert.ToInt32(maSanPhamCanXoa);
                        if (khoHang.Search(MaSanPhamCanXoa) != null)
                        {
                            khoHang.Delete(MaSanPhamCanXoa);
                            Console.WriteLine("Xoa san pham khoi kho hang thanh cong!");
                        } else {
                            Console.WriteLine("Khong tim thay ma san pham tuong ung de xoa.");
                        }
                        break;

                    case 4: //Cap nhat san pham thong qua ma ID cua san pham
                        Console.Write("Nhap ma ID cua san pham can cap nhat: ");
                        string maSanPhamCanCapNhat = Console.ReadLine();
                        while (!KiemTraMaSanPham(maSanPhamCanCapNhat))
                        {
                            Console.Write("Vui long nhap lai ma san pham: ");
                            maSanPhamCanCapNhat = Console.ReadLine();
                        }
                        int MaSanPhamCanCapNhat = Convert.ToInt32(maSanPhamCanCapNhat);
                        Console.WriteLine("Nhap thong tin san pham moi: ");
                        Console.Write("Ten san pham moi: ");
                        string TenSanPhamMoi = Console.ReadLine();
                        Console.Write("Price: ");
                        string giaSanPhamMoi = Console.ReadLine();
                        if (KiemTraLoi(maSanPhamCanCapNhat, TenSanPhamMoi, giaSanPhamMoi))
                        {
                            double GiaSanPhamMoi = Convert.ToInt32(giaSanPhamMoi);
                            Product sanPhamMoi = new Product(MaSanPhamCanCapNhat, TenSanPhamMoi, GiaSanPhamMoi);
                            if (khoHang.Search(MaSanPhamCanCapNhat) != null)
                            {
                                khoHang.Update(MaSanPhamCanCapNhat, sanPhamMoi);
                                Console.WriteLine("Cap nhat san pham thanh cong!");
                            } else {
                                Console.WriteLine("Khong tim thay ma san pham tuong ung de cap nhat.");
                            }
                        } else {
                            Console.WriteLine("Xay ra loi khi nhap thong tin san pham.");
                        }
                        break;

                    case 5: //Xoa nhieu san pham cung luc
                        Console.Write("Nhap danh sach nhung Ma ID cua san pham can xoa (cach nhau bang dau phay): ");
                        string nhungMaSanPhamCanXoa = Console.ReadLine();
                        //Check chuoi ma san pham xem hop le hay khong
                        while (!KiemTraChuoiMaID(nhungMaSanPhamCanXoa)) {
                            Console.Write("Vui long nhap lai danh sach nhung Ma ID cua san pham can xoa (CACH NHAU BANG DAU PHAY ','): ");
                            nhungMaSanPhamCanXoa = Console.ReadLine();
                        }
                        List<int> NhungMaSanPhamCanXoa = nhungMaSanPhamCanXoa.Split(',').Select(int.Parse).ToList();

                        foreach (int id in NhungMaSanPhamCanXoa)
                        {
                            Product sanPhamCanXoa = khoHang.Search(id);
                            if (sanPhamCanXoa != null)
                            {
                                khoHang.Delete(id);
                                Console.WriteLine($"Xoa san pham co ma ID {id} thanh cong!");
                            }
                            else
                            {
                                Console.WriteLine($"Khong tim thay san pham co ma ID {id}.");
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Moi ban ra khoi chuong trinh.");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }
    }
}
