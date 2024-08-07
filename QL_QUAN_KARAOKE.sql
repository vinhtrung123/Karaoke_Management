﻿CREATE DATABASE QL_QUANKARAOKE
GO
USE QL_QUANKARAOKE

GO
CREATE TABLE KHACHHANG
(
	MAKH NVARCHAR(50) PRIMARY KEY NOT NULL ,
	GIOITINH BIT NOT NULL,
	HOTEN NVARCHAR(50),
	NGAYSINH DATETIME,
	SDT INT,
	DIACHI NVARCHAR(50),
);
GO
CREATE TABLE PHONG
(
	MAPH NVARCHAR(50) NOT NULL,
	TENPHONG NVARCHAR(50),
	TRANGTHAI NVARCHAR(50),
	DONGIA NVARCHAR(50),
	THOIGIANBDAU DATETIME,
	THOIGIANKETTHUC DATETIME,
	CONSTRAINT PK_PHONG PRIMARY KEY(MAPH)
);

GO
CREATE TABLE MATHANG
(
	MAMH NVARCHAR(50) ,
	TENMATHANG NVARCHAR(50),
	DONGIABAN INT,
	SOLUONG INT,
	LOAI NVARCHAR(50),
	HINH NVARCHAR(30),
	CONSTRAINT PK_MATHANG PRIMARY KEY(MAMH)
);

GO
CREATE TABLE HOADONBANHANG
(
	MAHD NVARCHAR(50) NOT NULL,
	MAPH NVARCHAR(50),
	THOIGIANBDAU DATETIME,
	THOIGIANKETTHUC DATETIME,
	DONGIAPHONG INT,
	NGUOIBAN NVARCHAR(50),
	NGAYTAO DATETIME,
	NGUOITAO NVARCHAR(50),
	CONSTRAINT PK_HOADONBANHANG PRIMARY KEY(MAHD),
	CONSTRAINT FK_HOADONBANHANG_PHONG FOREIGN KEY (MAPH) REFERENCES PHONG(MAPH)
);

GO
CREATE TABLE CHITIETHDBAN
(
	MAHD NVARCHAR(50) NOT NULL,
	MAMH NVARCHAR(50) NOT NULL,
	SOLUONG INT,
	DONGIANHAP INT,
	CONSTRAINT PK_CHITIETHDBAN PRIMARY KEY (MAHD, MAMH ),
	CONSTRAINT FK_CHITIETHDBAN_HOADONBANHANG FOREIGN KEY (MAHD) REFERENCES HOADONBANHANG(MAHD),
	CONSTRAINT FK_CHITIETHDBAN_MATHANG FOREIGN KEY (MAMH) REFERENCES MATHANG(MAMH)
);

GO
CREATE TABLE NHACUNGCAP
(
	MANCC NVARCHAR(50) NOT NULL,
	TENNCC NVARCHAR(100),
	DIENTHOAI INT,
	DIACHI NVARCHAR(50),
	EMAIL NVARCHAR(50),
	NGAYTAO DATETIME,
	NGUOITAO NVARCHAR(50),
	CONSTRAINT PK_NHACUNGCAP PRIMARY KEY (MANCC)
);

GO
CREATE TABLE HOADONNHAP
(
	MAHDNHAP NVARCHAR(50) NOT NULL,
	NVNHAP NVARCHAR(50),
	MANCC NVARCHAR(50),
	NGAYNHAP DATETIME,
	TIENTHANHTOAN INT,
	NGAYTAO DATETIME,
	NGUOITAO NVARCHAR(50),
	CONSTRAINT PK_HOADONNHAP PRIMARY KEY (MAHDNHAP),
	CONSTRAINT FK_HOADONNHAP_NHACUNGCAP FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC)
);

GO
CREATE TABLE CHITIETHOADNHAP
(
	MAHDNHAP NVARCHAR(50) NOT NULL,
	MAMH NVARCHAR(50) ,
	SOLUONG INT,
	DONGIANHAP INT,
	CONSTRAINT PK_CHITIETHOADNHAP PRIMARY KEY (MAHDNHAP),
	CONSTRAINT FK_CHITIETHOADNHAP_MATHANG FOREIGN KEY (MAMH) REFERENCES MATHANG(MAMH)
);

GO
CREATE TABLE NHANVIEN
(
	TAIKHOAN NVARCHAR(50) NOT NULL,
	MANV NVARCHAR(50) NOT NULL,
	TENNV NVARCHAR(50),
	MATKHAU NVARCHAR(50),
	DIENTHOAI INT,
	DIACHI NVARCHAR(50),
	HINHNV NVARCHAR(30),
	CONSTRAINT PK_NHAVIEN PRIMARY KEY (MANV)
);

GO
INSERT INTO PHONG(MAPH, TENPHONG, TRANGTHAI, DONGIA, THOIGIANBDAU, THOIGIANKETTHUC)
VALUES
	('1', N'PHÒNG THƯỜNG', NULL, 2000, NULL,NULL),
	('2', N'PHÒNG THƯỜNG', NULL, 2000, NULL,NULL),
	('3', N'PHÒNG THƯỜNG', NULL, 2000,NULL,NULL),
	('4', N'PHÒNG THƯỜNG', NULL, 2000,NULL,NULL),
	('5', N'PHÒNG THƯỜNG',NULL,2000,NULL,NULL),
	('6', N'PHÒNG THƯỜNG', NULL, 2000,NULL,NULL),
	('7', N'PHÒNG VIP', NULL, 5000,NULL,NULL),
	('8', N'PHÒNG VIP', NULL, 5000,NULL,NULL);

GO
INSERT INTO MATHANG(MAMH, TENMATHANG, LOAI, DONGIABAN, SOLUONG, HINH)
VALUES
	('VTKP01', N'Trái Cây Lớn', N'Món Ăn', 50000, 100,'../Icon/tra	icay.JPG'),
	('VTKP02', N'Snack', N'Món Ăn', 10000, 100,'../Icon/snack.JPG'),
	('VTKP03', N'Bia SaiGon', N'Thức Uống', 10000, 1000,'../Icon/bia.JPG'),
	('VTKP04', N'Nước Ngọt', N'Thức Uống', 30000, 1000,'../Icon/nngot.JPG'),
	('VTKP05', N'Rượu Trái Cây', N'Thức Uống', 50000, 100,'../Icon/ruoutraicay.JPG');

GO 
INSERT INTO HOADONBANHANG(MAHD, MAPH, THOIGIANBDAU, THOIGIANKETTHUC, DONGIAPHONG, NGUOIBAN, NGUOITAO, NGAYTAO)
VALUES
	('KPVT01', '1', null,null, 2000, N'Nguyễn Kim Phụng', N'Tô Vĩnh Trung', '2023-09-11'  ),
	('KPVT02', '3', null,null, 5000, N'Nguyễn Thị A ', N'Nguyễn Thị C', '2023-03-11'  ),
	('KPVT03', '5', null,null, 2500, N'Nguyễn Thị C', N'Nguyễn Thị C', '2023-06-07'  ),
	('KPVT04', '2', null,null, 3000, N'Tô Vĩnh Trung', N'Nguyễn Kim Phụng', '2023-09-21'  ),
	('KPVT05', '1', null,null, 3500, N'Nguyễn Kim Phụng', N'Nguyễn Thị C', '2023-08-30'  );

GO
INSERT INTO CHITIETHDBAN(MAHD, MAMH, SOLUONG, DONGIANHAP)
VALUES 
	('KPVT01', 'VTKP01', 100, 50000),
	('KPVT02', 'VTKP03', 10, 100000),
	('KPVT03', 'VTKP04', 100, 120000),
	('KPVT04', 'VTKP03', 10, 100000),
	('KPVT05', 'VTKP05', 10, 500000);

GO
INSERT INTO NHACUNGCAP(MANCC, TENNCC, DIENTHOAI, DIACHI, EMAIL, NGAYTAO)
VALUES
	('KL01','COOP.FOOD', 1900555568,'Co.op Food Tân Sơn Nhì 177', 'cskh@coopfoodnq.vn',2023-09-11),
	('KL02','Công Ty Cổ Phần Bánh Givral', 0908187379, 'Lô II-1B, Lê Trọng Tấn, KCN Tân Bình, Tân Phú', 'nguyennhp@saigongivral.com',2023-08-11),
	('KL03','Công ty Nước SUNTORY PEPSICO', 0283821943, '88 Đồng Khởi-Phường Bến Nghé, Q1', 'talent@suntorypepsico.vn',2023-09-18),
	('KL04','XƯỞNG SẢN XUẤT LARUVIE', 0899999550,'68 Cây Sung-Bến Đò, tỉnh Bình Thuận', 'laruvie@gmail.com',2023-010-11),
	('KL05','Công Ty Nước Giải Khát SaiGon', 0283829408, '187 Nguyễn Chí Thanh, Phường 12, Q5', 'sabeco@sabeco.com.vn',2023-09-21);
	
GO
INSERT INTO CHITIETHOADNHAP(MAHDNHAP, MAMH, SOLUONG, DONGIANHAP)
VALUES
	('EB01', 'VTKP01', 100, 3000000),
	('EB02', 'VTKP02', 100, 500000),
	('EB03', 'VTKP03', 1000, 7000000),
	('EB04', 'VTKP04', 1000, 3000000),
	('EB05', 'VTKP05', 1000, 30000000);

GO
INSERT INTO NHANVIEN(TAIKHOAN, MANV, TENNV, MATKHAU, DIENTHOAI, DIACHI, HINHNV)
VALUES
	('kp','NV01', 'Nguyễn Kim Phụng',123, 0398858873, 'Tân Phú','../Icon/nv1.JPG'),
	('vt','NV02', 'Tô Vĩnh Trung',123, 0765590615, 'Quận 11','../Icon/nv2.JPG'),
	('tt','NV03', 'Nguyễn Thị A',123, 0123456789, 'Bình Tân','../Icon/nv3.JPG'),
	('pu','NV04', 'Nguyễn Văn B',123, 0123456789, 'Quận 8','../Icon/nv4.JPG'),
	('py','NV05', 'Nguyễn Thị C',123, 0123456789, 'Tân Phú','../Icon/nv5.JPG');

GO 
INSERT INTO KHACHHANG(MAKH, GIOITINH, HOTEN, NGAYSINH, SDT, DIACHI)
VALUES
	(N'KH036', 0, N'NGUYỄN NGỌC MỸ', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'0945601352', N'DC00036'),
	(N'KH037', 0, N'LÊ THỊ THU HÀ', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'0945601353', N'DC00037'),
	(N'KH038', 0, N'NGUYỄN THỊ CÚC', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'0945601354', N'DC00038'),
	(N'KH039', 0, N'HUỲNH THỊ HỒNG NGA', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'0945601355', N'DC00039'),
	(N'KH040', 1, N'NGUYỄN HỒNG HẢI', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'0945601356', N'DC00040'),
	(N'KH041', 0, N'TRÀ THỊ TUYẾT THU', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'0945601357', N'DC00041');
GO

-- Tạo một thủ tục lưu trữ để đổi tên cột trong DICHVU
CREATE PROCEDURE ChangeColumnName_DICHVUTHEM
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DICHVUTHEM' AND COLUMN_NAME = 'TENDV')
    BEGIN
        EXEC sp_rename 'DICHVUTHEM.TENDV', 'TENMATHANG', 'COLUMN';
        PRINT 'Đã đổi tên cột từ TENDV thành TENMATHANG trong bảng DICHVU.';
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy cột TENDV trong bảng DICHVUTHEM.';
    END
END;

-- Tạo một thủ tục lưu trữ để đổi tên cột trong CTHD
CREATE PROCEDURE ChangeColumnName_CTHD
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CTHD' AND COLUMN_NAME = 'TENDV')
    BEGIN
        EXEC sp_rename 'CTHD.TENDV', 'TENMATHANG', 'COLUMN';
        PRINT 'Đã đổi tên cột từ TENDV thành TENMATHANG trong bảng CTHD.';
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy cột TENDV trong bảng CTHD.';
    END
END;


EXEC ChangeColumnName_DICHVUTHEM;
EXEC ChangeColumnName_CTHD;

-- Tạo một thủ tục lưu trữ để đổi tên cột trong HOADONBANHANG
CREATE PROCEDURE ChangeColumnName_DONGIAPHONG
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'HOADONBANHANG' AND COLUMN_NAME = 'DONGIAPHONG')
    BEGIN
        EXEC sp_rename 'HOADONBANHANG.DONGIAPHONG', 'DONGIA', 'COLUMN';
        PRINT 'Đã đổi tên cột từ DONGIAPHONG thành DONGIA trong bảng HOADONBANHANG.';
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy cột DONGIAPHONG trong bảng HOADONBANHANG.';
    END
END;

EXEC ChangeColumnName_DONGIAPHONG;




ALTER TABLE MATHANG
ADD HINH NVARCHAR(30);

ALTER TABLE MATHANG
DROP COLUMN HINH;

DELETE FROM MATHANG;

ALTER TABLE CHITIETHDBAN
DROP CONSTRAINT FK_CHITIETHDBAN_HOADONBANHANG;

ALTER TABLE CHITIETHOADNHAP
DROP CONSTRAINT FK_CHITIETHOADNHAP_MATHANG;

ALTER TABLE NHANVIEN
ADD ACCESSLEVEL NVARCHAR(30);

ALTER TABLE HOADONBANHANG
ADD TONGTIEN INT;

ALTER TABLE PHONG
ALTER COLUMN DONGIA decimal(18,0);

ALTER TABLE MATHANG
ALTER COLUMN DONGIA decimal(18,0);

ALTER TABLE phong
ALTER COLUMN trangthai INT;

ALTER TABLE HOADONBANHANG
ADD GIAMGIA INT;
ALTER TABLE HOADONBANHANG
ADD TONGTIEN DECIMAL(18,0);

-- Xóa điều kiện NOT NULL và thiết lập giá trị mặc định cho cột MAHD trong bảng HOADONBANHANG
ALTER TABLE HOADONBANHANG
ALTER COLUMN MAHD NVARCHAR(50) NULL;

-- Thiết lập giá trị mặc định cho cột MAHD (ví dụ: 'DEFAULT_VALUE')
ALTER TABLE HOADONBANHANG
ADD CONSTRAINT DF_HOADONBANHANG_MAHD DEFAULT 'DEFAULT_VALUE' FOR MAHD;

-- Xóa khóa chính của cột MAHD trong bảng HOADONBANHANG
ALTER TABLE HOADONBANHANG
DROP CONSTRAINT PK_HOADONBANHANG;
-- Xóa khóa ngoại của cột MAHD trong bảng HOADONBANHANG
ALTER TABLE HOADONBANHANG
DROP CONSTRAINT FK_HOADONBANHANG_PHONG;

-- Thêm cột MAHD làm khóa chính
ALTER TABLE HOADONBANHANG
ADD CONSTRAINT PK_HOADONBANHANG PRIMARY KEY(MAHD);

ALTER TABLE CTHD
ADD CONSTRAINT FK_CTHD_HOADONBANHANG FOREIGN KEY (MAHD) REFERENCES HOADONBANHANG(MAHD);
 
CREATE TABLE DICHVU (
     TENDV  NVARCHAR(20),
	 GIADV  INT

	 CONSTRAINT PK_DICHVU PRIMARY KEY (TENDV),
);

GO

CREATE TABLE CTHD(
	MACTHD INT PRIMARY KEY IDENTITY(1,1),
    MAHD INT,
    TENDV NVARCHAR(20),
	DONGIA DECIMAL(18,0),
    SOLUONG INT,
    THANHTIEN DECIMAL(18,0) NOT NULL,
);
GO

CREATE TABLE DICHVUTHEM(
     TENDV NVARCHAR(20),
	 MABAN INT,
	 SOLUONG INT

	 CONSTRAINT PK_DICHVUTHEM PRIMARY KEY (TENDV,MABAN),
);

GO

ALTER TABLE MATHANG
ADD Quantity INT NOT NULL DEFAULT 0;

UPDATE MATHANG
SET tenmathang = 'TENDV'
WHERE tenmathang = 'TENMATHANG';



SELECT MAPH, DONGIA FROM PHONG WHERE MAPH IN ('1', '2', '3', '4', '5', '6', '7', '8');

CREATE TABLE DichVuThem (
     ID INT IDENTITY(1,1) PRIMARY KEY,
	 MAPH NVARCHAR(50),
     TENDV NVARCHAR(20),
	 DONGIA DECIMAL(18,0),
	 SOLUONG INT,
	 THANHTIEN DECIMAL(18,0) NOT NULL,
     CONSTRAINT FK_DichVuThem_Ban FOREIGN KEY (MAPH) REFERENCES PHONG(MAPH),
);

-- Tạo một thủ tục lưu trữ để đổi tên cột trong HOADONBANHANG
CREATE PROCEDURE ChangeColumnName_DONGIABAN
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MATHANG' AND COLUMN_NAME = 'DONGIABAN')
    BEGIN
        EXEC sp_rename 'MATHANG.DONGIABAN', 'DONGIA', 'COLUMN';
        PRINT 'Đã đổi tên cột từ DONGIABAN thành DONGIA trong bảng MATHANG.';
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy cột DONGIABAN trong bảng MATHANG.';
    END
END;

EXEC ChangeColumnName_DONGIABAN;
