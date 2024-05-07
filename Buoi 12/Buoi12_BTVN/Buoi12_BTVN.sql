USE [BE.NET2402]

--TẠO BẢNG Books--
CREATE TABLE Books (
BookID INT NOT NULL IDENTITY PRIMARY KEY,
Ten nvarchar(50),
TacGia nvarchar(50),
TheLoai nvarchar(50),
Gia bigint,
SoLuong int NOT NULL
)

--CHO DỮ LIỆU VÀO BẢNG Books
INSERT INTO [dbo].[Books] (Ten, TacGia, TheLoai, Gia, SoLuong)	
VALUES 
(N'Klara Và Mặt Trời', N'Kazuo Ishiguro', N'Khoa học viễn tưởng', 150000, 30),
(N'Không Gia Đình', N'Hector Malot', N'Văn học cổ điển', 95000, 50),
(N'Thư Viện Nửa Đêm', N'Matt Haig', N'Khoa học viễn tưởng', 150000, 20),
(N'Tàn Ngày Để Lại', N'Kazuo Ishiguro', N'Văn học cổ điển', 135000, 50),
(N'Thay đổi tí hon - Hiệu quả bất ngờ', N'James Clear', N'Phi hư cấu', 130000, 40),
(N'Ông già và Biển cả', N'Ernest Hermingway', N'Văn học cổ điển', 69000, 80)

--TẠO BẢNG Authors--
CREATE TABLE Authors (
AuthorID INT NOT NULL IDENTITY PRIMARY KEY,
Ten nvarchar(50),
QuocGia nvarchar(50)
)

--CHO DỮ LIỆU VÀO BẢNG Authors--
INSERT INTO [dbo].[Authors] (Ten, QuocGia)	
VALUES (N'Kazuo Ishiguro', N'Nhật Bản'), (N'Hector Malot', N'Pháp'), (N'Matt Haig', N'Anh'), (N'James Clear', N'Mỹ'), (N'Ernest Hermingway', N'Anh') 

-- KẾT HỢP THÔNG TIN TỪ BẢNG Books VÀ Authors--
SELECT b.TacGia, COUNT(*) as SoLuongSach FROM [dbo].[Books] b
INNER JOIN [dbo].[Authors] a
ON b.TacGia = a.Ten
GROUP BY b.TacGia

--TẠO BẢNG Orders--
CREATE TABLE Orders (
OrderID INT NOT NULL IDENTITY PRIMARY KEY,
NgayDatHang date,
TenKhachHang nvarchar(50),
DiaChiGiaoHang nvarchar(250),
TongTien bigint
)

--CHO DỮ LIỆU VÀO BẢNG Orders--
INSERT INTO [dbo].[Orders] (NgayDatHang, TenKhachHang, DiaChiGiaoHang, TongTien)	
VALUES (N'2024-05-01', N'Trần Quốc Dũng', N'Quận Thanh Xuân, Hà Nội', N'430000'), 
(N'2024-04-20', N'Nguyễn Văn A', N'Quận Hoàn Kiếm, Hà Nội', N'164000')

--TẠO BẢNG OrderDetails--
CREATE TABLE OrderDetails (
OrderID INT NOT NULL 
CONSTRAINT DatHangID FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
BookID INT NOT NULL 
CONSTRAINT SachID FOREIGN KEY (BookID) REFERENCES Books (BookID),
SoLuongSanPham INT,
GiaBanTaiThoiDiem Bigint
)

--CHO DỮ LIỆU VÀO BẢNG Orders--
INSERT INTO [dbo].[OrderDetails] (OrderID, BookID, SoLuongSanPham, GiaBanTaiThoiDiem)	
VALUES (N'1', N'1', N'1', N'150000'), (N'1', N'3', N'1', N'150000'), (N'1', N'5', N'1', N'130000'), (N'2', N'2', N'1', N'95000'), (N'2', N'6', N'1', N'69000')

SELECT * FROM Books
SELECT * FROM Authors
SELECT * FROM Orders
SELECT * FROM OrderDetails


