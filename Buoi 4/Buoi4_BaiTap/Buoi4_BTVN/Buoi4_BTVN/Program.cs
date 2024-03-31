using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4_BTVN
{
    public class Receipt
    {
        public string receiptId { get; set; }
        public DateTime releaseDate { get; set; }
        public decimal price { get; set; }
        public decimal debts { get; set; }
        public int debtState { get => debts == 0 ? 0 : 1; }
        public string customer { get; set; }
    }

    class manageReceipts
    {
        public List<Receipt> receipts = new List<Receipt>();

        public void writingReceipts(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var receipt = new Receipt();
                Console.WriteLine($"Nhap thong tin hoa don thu {i + 1}");
                Console.Write("Ma hoa don: ");
                receipt.receiptId = Console.ReadLine();
                Console.Write("Ngay phat hanh (mm/dd/yyyy): ");
                receipt.releaseDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Tong tien: ");
                receipt.price = decimal.Parse(Console.ReadLine());
                Console.Write("Khoan no: ");
                receipt.debts = decimal.Parse(Console.ReadLine());
                Console.Write("Ten khach hang: ");
                receipt.customer = Console.ReadLine();
                
                // Them hoa don vao danh sach hoa don
                receipts.Add(receipt);
            }
        }

        public void deleteDebts(string receiptId)
        {
            List<Receipt> query = new List<Receipt>();
            foreach (var receipt in receipts)
            {
                if (receipt.receiptId == receiptId)
                {
                    query.Add(receipt);
                }
            }
            if (query != null)
            {
                query[0].debts = 0;
            }

            Console.WriteLine("Xoa no thanh cong!");

        }

        public void printingReceipts (string receiptId = null, int? debtState = null)
        {
            var query = receipts.AsEnumerable();
            if (!string.IsNullOrEmpty(receiptId))
            {
                query = query.Where(hd => hd.receiptId == receiptId);
            }
            if (debtState.HasValue)
            {
                query = query.Where(hd => hd.debtState == debtState.Value);
            }

            foreach (var receipt in query)
            {
                Console.WriteLine($"Ma hoa don: {receipt.receiptId}, Ngay phat hanh: {receipt.releaseDate:dd/MM/yyyy}, Tong gia tien: {receipt.price}, Khoan no: {receipt.debts}, Trang thai no: {(receipt.debtState == 0 ? "Khong" : "Co")}, Ten khach hang: {receipt.customer}");
            }
        }

        public void printingDebtReceipts(int days)
        {
            var ngayHienTai = DateTime.Now;
            List<Receipt> query = new List<Receipt>();
            foreach (var receipt in receipts)
            {
                if ( ((ngayHienTai - receipt.releaseDate).Days <= days) && ((ngayHienTai - receipt.releaseDate).Days > (days-30))) {
                    query.Add(receipt);
                };
            }

            foreach (var receipt in query)
            {
                Console.WriteLine($"Ma hoa don: {receipt.receiptId}, Ngay phat hanh: {receipt.releaseDate: dd/MM/yyyy}, Khoan no: {receipt.debts}, Ten khach hang: {receipt.customer}");
            }
        }

        public void Export()
        {
            List<Receipt> noDebtReceipts = new List<Receipt>();
            foreach (var receipt in receipts)
            {
                if (receipt.debtState == 0)
                {
                    noDebtReceipts.Add(receipt);
                };
            }
            using (StreamWriter sw = new StreamWriter("hoa_don_hop_le.txt"))
            {
                foreach (var hoaDon in noDebtReceipts)
                {
                    sw.WriteLine($"Ma hoa don: {hoaDon.receiptId}, Ngay phat hanh: {hoaDon.releaseDate:dd/MM/yyyy}, Tong tien: {hoaDon.price}, Ten khach hang: {hoaDon.customer}");
                }
            }
        }
    }
    internal class Program
    {
        static manageReceipts quanLy = new manageReceipts();
        static void Main(string[] args)
        {
            bool chuong_trinh = true;
            //Mo dau chuong trinh
            Console.WriteLine("CHUONG TRINH QUAN LY HOA DON\n");
            Console.WriteLine("1. Nhap danh sach cac hoa don");
            Console.WriteLine("2. Xoa no hoa don");
            Console.WriteLine("3. Xuat danh sach hoa don");
            Console.WriteLine("4. Hien thi danh sach hoa don co no");
            Console.WriteLine("5. Xuat danh sach hoa don khong no vao file hoa_don_hop_le.txt");
            Console.WriteLine("6. Thoat chuong trinh");
            while (chuong_trinh)
            {
                //Lua chon cua nguoi dung
                Console.Write("\nNhap lua chon cua ban (1-6): ");
                int lua_chon;
                bool isNumeric = int.TryParse(Console.ReadLine(), out lua_chon);

                while (isNumeric == false || lua_chon < 1 || lua_chon > 6)
                {
                    Console.Write("Vui long nhap lai so tu nhien tu 1 den 6: ");
                    isNumeric = int.TryParse(Console.ReadLine(), out lua_chon);
                }

                switch (lua_chon)
                {
                    case 1:
                        Console.Write("Nhap so luong hoa don can cho vao danh sach: ");
                        int soLuongHoaDon = Convert.ToInt32(Console.ReadLine());
                        quanLy.writingReceipts(soLuongHoaDon);
                        break;
                    case 2:
                        Console.Write("Nhap ma cua hoa don can xoa no: ");
                        string maHoaDon = Console.ReadLine();
                        quanLy.deleteDebts(maHoaDon);
                        break;
                    case 3:
                        Console.Write("Nhap ma hoa don can xuat (khong nhap gi de xuat tat ca): ");
                        maHoaDon = Console.ReadLine();
                        quanLy.printingReceipts(maHoaDon);
                        break;
                    case 4:
                        Console.WriteLine("1. Hoa don no trong vong 30 ngay (<= 30 ngay)");
                        Console.WriteLine("2. Hoa don no trong vong 60 ngay (<= 60 ngay)");
                        Console.WriteLine("3. Hoa don no trong vong 90 ngay (<= 90 ngay)");
                        //Chon moc thoi gian cua khoan no de hien thi danh sach hoa don tuong ung
                        Console.Write("Chon moc thoi gian hop le (1-3): ");
                        int mocThoiGian;
                        bool is_Numeric = int.TryParse(Console.ReadLine(), out mocThoiGian);
                        while (is_Numeric == false || mocThoiGian < 1 || mocThoiGian > 3)
                        {
                            Console.Write("Vui long nhap lai moc thoi gian tu 1 den 3: ");
                            is_Numeric = int.TryParse(Console.ReadLine(), out mocThoiGian);
                        }
                        int soNgay = 0;
                        switch (mocThoiGian) 
                        {
                            case 1:
                                soNgay = 30;
                                break;
                            case 2:
                                soNgay = 60;
                                break;
                            case 3:
                                soNgay = 90;
                                break;
                        }
                        quanLy.printingDebtReceipts(soNgay);
                        break;
                    case 5:
                        quanLy.Export();
                        Console.WriteLine("Xuat hoa don khong no vao file hoa_don_hop_le.txt thanh cong!");
                        break;
                    case 6:
                        Console.WriteLine("Cam on vi da tham gia chuong trinh...");
                        Console.WriteLine("Moi ban ra ngoai!");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Vui long nhap lai so tu nhien tu 1 den 6, ban ngu qua: ");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
