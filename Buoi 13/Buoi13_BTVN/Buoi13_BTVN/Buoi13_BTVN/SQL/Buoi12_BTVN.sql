USE [BE.NET2402]
--TẠO BẢNG Authors--
CREATE TABLE Authors (
AuthorID INT NOT NULL IDENTITY PRIMARY KEY,
Ten nvarchar(50),
QuocGia nvarchar(50)
)

--CHO DỮ LIỆU VÀO BẢNG Authors--
INSERT INTO [dbo].[Authors] (Ten, QuocGia)	
VALUES (N'Kazuo Ishiguro', N'Nhật Bản'), (N'Hector Malot', N'Pháp'), (N'Matt Haig', N'Anh'), (N'James Clear', N'Mỹ'), (N'Ernest Hermingway', N'Anh') 

--TẠO BẢNG Books--
CREATE TABLE Books (
BookID INT NOT NULL IDENTITY PRIMARY KEY,
Ten nvarchar(50),
TacGiaID INT NOT NULL FOREIGN KEY (TacGiaID) REFERENCES Authors (AuthorID),
TheLoai nvarchar(50),
Gia bigint,
SoLuong int NOT NULL
)

--CHO DỮ LIỆU VÀO BẢNG Books
INSERT INTO [dbo].[Books] (Ten, TacGiaID, TheLoai, Gia, SoLuong)	
VALUES 
(N'Klara Và Mặt Trời', N'1', N'Khoa học viễn tưởng', 150000, 30),
(N'Không Gia Đình', N'2', N'Văn học cổ điển', 95000, 50),
(N'Thư Viện Nửa Đêm', N'3', N'Khoa học viễn tưởng', 150000, 20),
(N'Tàn Ngày Để Lại', N'1', N'Văn học cổ điển', 135000, 50),
(N'Thay đổi tí hon - Hiệu quả bất ngờ', N'4', N'Phi hư cấu', 130000, 40),
(N'Ông già và Biển cả', N'5', N'Văn học cổ điển', 69000, 80)


--TẠO BẢNG Customers
CREATE TABLE Customers (
CustomerID INT NOT NULL IDENTITY PRIMARY KEY,
TenKhachHang nvarchar(50),
NgaySinh date,
GioiTinh nvarchar(10)
)

--CHO DỮ LIỆU VÀO BẢNG Customers--
INSERT INTO [dbo].[Customers] (TenKhachHang, NgaySinh, GioiTinh)	
VALUES (N'Trần Quốc Dũng', N'2003-11-30', N'Nam'), (N'Đào Hà My', N'2003-08-23', N'Nữ')

--TẠO BẢNG Orders--
CREATE TABLE Orders (
OrderID INT NOT NULL IDENTITY PRIMARY KEY,
NgayDatHang date,
KhachHangID INT NOT NULL FOREIGN KEY (KhachHangID) REFERENCES Customers (CustomerID),
DiaChiGiaoHang nvarchar(250),
TongTien bigint
)

--CHO DỮ LIỆU VÀO BẢNG Orders--
INSERT INTO [dbo].[Orders] (NgayDatHang, KhachHangID, DiaChiGiaoHang, TongTien)	
VALUES (N'2024-05-01', N'1', N'Quận Thanh Xuân, Hà Nội', N'430000'), 
(N'2024-04-20', N'2', N'Ecopark', N'164000')

--TẠO BẢNG OrderDetails--
CREATE TABLE OrderDetails (
OrderDetailsID INT NOT NULL IDENTITY PRIMARY KEY,
OrderID INT NOT NULL FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
BookID INT NOT NULL FOREIGN KEY (BookID) REFERENCES Books (BookID),
SoLuongSanPham INT,
GiaBanTaiThoiDiem Bigint
)

--CHO DỮ LIỆU VÀO BẢNG Orders--
INSERT INTO [dbo].[OrderDetails] (OrderID, BookID, SoLuongSanPham, GiaBanTaiThoiDiem)	
VALUES (N'1', N'1', N'1', N'150000'), (N'1', N'3', N'1', N'150000'), (N'1', N'5', N'1', N'130000'), (N'2', N'2', N'1', N'95000'), (N'2', N'6', N'1', N'69000')

SELECT * FROM Books
SELECT * FROM Authors
SELECT * FROM Customers
SELECT * FROM Orders
SELECT * FROM OrderDetails


