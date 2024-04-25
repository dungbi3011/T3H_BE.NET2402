USE [BE.NET2402]

--TẠO BẢNG EMPLOYEES--
CREATE TABLE Employees (
EmployeeID INT NOT NULL IDENTITY PRIMARY KEY,
FirstName nvarchar(50),
LastName nvarchar(50),
Position nvarchar(50),
DepartmentID int NOT NULL,
Salary bigint
)

--CHO DỮ LIỆU VÀO BẢNG EMPLOYEES
INSERT INTO [dbo].[Employees] (FirstName, LastName, Position, DepartmentID, Salary)	
VALUES 
(N'Dũng', N'Trần', N'Xây Dựng Website', 1, 20000000),
(N'Hưng', N'Phùng', N'Hậu Cần', 1, 15000000),
(N'Huy', N'Nguyễn', N'Bảo Mật Thông Tin', 2, 18000000),
(N'Hiếu', N'Phạm', N'Machine Learning', 3, 25000000), 
(N'Quân', N'Nguyễn', N'Thiết Kế Đồ Họa', 3, 14000000),
(N'Tùng', N'Lưu', N'Tài Chính', 2, 15000000)

--HIỂN THỊ TẤT CẢ THÔNG TIN VỀ NHÂN VIÊN--
SELECT * FROM Employees

--TẠO BẢNG DEPARTMENTS--
CREATE TABLE Departments (
DepartmentID INT NOT NULL IDENTITY PRIMARY KEY,
DepartmentName nvarchar(50)
)

--CHO DỮ LIỆU VÀO BẢNG DEPARTMENTS--
INSERT INTO [dbo].[Departments] (DepartmentName)	
VALUES (N'Phòng Ban ABC'), (N'Phòng Ban DEF'), (N'Phòng Ban XYZ') 

-- KẾT HỢP THÔNG TIN TỪ BẢNG EMPLOYEES VÀ DEPARTMENTS--
SELECT e.FirstName, e.LastName, d.DepartmentName FROM [dbo].[Employees] e
INNER JOIN [dbo].[Departments] d
ON e.DepartmentID = d.DepartmentID


--BAI TAP AGGREGATION AND GROUP BY--
--1) Viết một truy vấn để tính toán tổng lương mỗi phòng ban đã chi trả.
SELECT d.DepartmentName AS 'Department', SUM(Salary) AS SalaryTotal
FROM [dbo].[Employees] e
INNER JOIN [dbo].[Departments] d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentName 

--2) Sắp xếp kết quả theo tổng lương giảm dần.
SELECT d.DepartmentName AS 'Department', SUM(Salary) AS SalaryTotal
FROM [dbo].[Employees] e
INNER JOIN [dbo].[Departments] d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentName 
ORDER BY SUM(Salary) DESC

--3) Hiển thị phòng ban có tổng lương cao nhất đứng đầu danh sách.
SELECT *
FROM (SELECT TOP (1) d.DepartmentName AS 'Department', SUM(Salary) AS SalaryTotal
	FROM [dbo].[Employees] e
	INNER JOIN [dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
	GROUP BY d.DepartmentName
	ORDER BY SalaryTotal DESC
) AS s
GROUP BY s.Department, s.SalaryTotal