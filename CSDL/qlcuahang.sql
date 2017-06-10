IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'QLCHmoi')
	DROP DATABASE QLCHmoi
GO

CREATE DATABASE QLCHmoi
GO
USE QLCHmoi
GO
------------------------------------
---------T?o c�c b?ng---------------
------------------------------------

-----------------------------------
----------KH�CH H�NG-------------
------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'KHACHHANG')
	DROP DATABASE KHACHHANG
GO
CREATE TABLE KHACHHANG
(
	MAKH VARCHAR(6)NOT NULL,
	HOTEN NVARCHAR(30) NULL,
	DIACHI NVARCHAR(50)NULL,
	DIENTHOAI VARCHAR(11)NULL
)
GO

-------------------------------------
-----------L?AI NH�N VI�N------------
-------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'LOAINHANVIEN')
	DROP DATABASE LOAINHANVIEN
GO

CREATE TABLE LOAINHANVIEN
(
	MALOAINV VARCHAR(6) NOT NULL,
	TENLOAINV NVARCHAR(20) NULL
)
GO

-------------------------------------
------------GI?I T�NH-----------------
--------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'GIOITINH')
	DROP DATABASE GIOITINH
GO 
CREATE TABLE GIOITINH
(
	GIOITINH VARCHAR(6)NOT NULL,
	TENGIOITINH NVARCHAR(10) NULL
)
GO

------------------------------------
-----------NH�N VI�N----------------
------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'NHANVIEN')
	DROP DATABASE NHANVIEN
GO
CREATE TABLE NHANVIEN
(
	MANV VARCHAR(6) NOT NULL,
	HOTEN NVARCHAR(30) NULL,
	DIACHI NVARCHAR(50) NULL,
	NGAYSINH DATETIME NULL,
	GIOITINH VARCHAR(6) NULL,
	DIENTHOAI VARCHAR(11)NULL,
	USERNAME VARCHAR(50)NULL,
	PASSWORDS VARCHAR(50)NULL,
	MALOAINV VARCHAR(6) NULL
)
GO

--------------------------------------
-----------NH� CUNG C?P---------------
--------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'NHACUNGCAP')
	DROP DATABASE NHACUNGCAP
GO
CREATE TABLE NHACUNGCAP
(
	MANCC VARCHAR(8) NOT NULL,
	TENNCC NVARCHAR(30) NULL,
	DIACHI NVARCHAR(40) NULL,
	DIENTHOAI VARCHAR(11)NULL
)
GO

--------------------------------------
------------�ON V? T�NH---------------
--------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'DONVITINH')
	DROP DATABASE DONVITINH
GO
CREATE TABLE DONVITINH
(
	MADVT VARCHAR(6) NOT NULL,
	TENDVT NVARCHAR(30) NULL
)
GO

--------------------------------------
------------H�NG H�A----------------
------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'HANGHOA')
	DROP DATABASE HANGHOA
GO
CREATE TABLE HANGHOA
(
	MAHH VARCHAR(8) NOT NULL,
	TENHH NVARCHAR(30) NULL,
	MADVT VARCHAR(6)NULL,	
	NGAYHETHAN DATETIME NULL,
	SOLUONG INT NULL,
	SOLUONGGIAM INT NULL,
	TILEGIAM INT NULL,
	DONGIA INT NULL
)
GO

-------------------------------------
------------PHI?U B�N H�NG-----------
-------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'PHIEUBANHANG')
	DROP DATABASE PHIEUBANHANG
GO
CREATE TABLE PHIEUBANHANG
(
	MAPHIEU VARCHAR(6) NOT NULL,
	MAKH VARCHAR(6) NULL,
	MANV VARCHAR(6)NOT NULL,	
	NGAYLAP DATETIME NULL,
	TONGTIEN INT NULL
	
)
GO

-----------------------------------
----------PHI?U �?T H�NG-----------
-----------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'PHIEUDATHANG')
	DROP DATABASE PHIEUDATHANG
GO
CREATE TABLE PHIEUDATHANG
(
	MAPHIEUDATHANG VARCHAR(6) NOT NULL,
	MANCC VARCHAR(8)NOT NULL,
	MANV VARCHAR(6) NOT NULL,
	NGAYLAP DATETIME NULL,
	
)
GO

----------------------------------------
-----------PHI?U NH?N H�NG--------------
-----------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'PHIEUNHANHANG')
	DROP DATABASE PHIEUNHANHANG
GO
CREATE TABLE PHIEUNHANHANG
(
	MAPHIEU VARCHAR(6) NOT NULL,
	MANCC VARCHAR(8)NOT NULL,
	MANV VARCHAR(6)NOT NULL,	
	NGAYLAP DATETIME NULL,
	TONGTIEN INT NULL
	
)
GO

--------------------------------------------
------------CHI TI?T PHI?U B�N H�NG----------
--------------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'CHITIETPHIEUBANHANG')
	DROP DATABASE CHITIETPHIEUBANHANG
GO
CREATE TABLE CHITIETPHIEUBANHANG
(
	MAPHIEU VARCHAR(6) NOT NULL,
	MAHH VARCHAR(8)NOT NULL,
	DONGIA INT NULL,
	SOLUONG INT NULL,
	THANHTIEN INT NULL
)
GO

-----------------------------------------------
------------CHI TI?T PHI?U �?T H�NG-----------
----------------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'CHITIETPHIEUDATHANG')
	DROP DATABASE CHITIETPHIEUDATHANG
GO
CREATE TABLE CHITIETPHIEUDATHANG
(
	MAPHIEUDATHANG VARCHAR(6) NOT NULL,
	MAHH VARCHAR(8)NOT NULL,
	SOLUONG INT NULL
)
GO

---------------------------------------------
----------CHI TI?T PHI?U NH?N H�NG------------
---------------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'CHITIETPHIEUNHANHANG')
	DROP DATABASE CHITIETPHIEUNHANHANG
GO
CREATE TABLE CHITIETPHIEUNHANHANG
(
	MAPHIEU VARCHAR(6) NOT NULL,
	MAHH VARCHAR(8) NOT NULL,
	DONGIA INT NULL,
	SOLUONG INT NULL,
	THANHTIEN INT NULL,
	MAPHIEUDATHANG VARCHAR(6)NOT NULL  
)
GO

-----------------------------------------------
----------------PHI?U S? C?--------------------
------------------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'PHIEUSUCO')
	DROP DATABASE PHIEUSUCO
GO
CREATE TABLE PHIEUSUCO
(
	MAPHIEUSUCO VARCHAR(6) NOT NULL,
	MAHH VARCHAR(8) NOT NULL,
	NGAYHUHONG DATETIME NULL,
	LYDO VARCHAR(1000) NULL,
	SOLUONGHUHONG INT NULL,
	DONGIA INT NULL,
	TONGTIENHUHONG INT NULL
)
GO

-----------------------------------------------
-----------------T?N KHO-------------------
-----------------------------------------------
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'TONKHO')
	DROP DATABASE TONKHO
GO
CREATE TABLE TONKHO
(
	THOIGIAN DATETIME NOT NULL,
	MAHH VARCHAR(8)NOT NULL,
	SLTON INT NULL
)
GO

------------------------------------------
--==========T?O KH�A CH�NH==============
------------------------------------------
ALTER TABLE KHACHHANG
ADD CONSTRAINT P_MAKH PRIMARY KEY(MAKH)

ALTER TABLE LOAINHANVIEN
ADD CONSTRAINT P_MALOAINV PRIMARY KEY(MALOAINV)

ALTER TABLE GIOITINH
ADD CONSTRAINT P_GIOITINH PRIMARY KEY(GIOITINH)

ALTER TABLE NHANVIEN
ADD CONSTRAINT P_MANV PRIMARY KEY(MANV)

ALTER TABLE NHACUNGCAP
ADD CONSTRAINT P_MANCC PRIMARY KEY(MANCC)

ALTER TABLE DONVITINH
ADD CONSTRAINT P_MADVT PRIMARY KEY(MADVT)

ALTER TABLE HANGHOA
ADD CONSTRAINT P_MAHH PRIMARY KEY(MAHH)

ALTER TABLE PHIEUBANHANG
ADD CONSTRAINT P_MAPHIEU PRIMARY KEY(MAPHIEU)

ALTER TABLE PHIEUDATHANG
ADD CONSTRAINT P_MAPHIEUDATHANG PRIMARY KEY(MAPHIEUDATHANG)

ALTER TABLE PHIEUNHANHANG
ADD CONSTRAINT PN_MAPHIEU PRIMARY KEY(MAPHIEU)

ALTER TABLE CHITIETPHIEUBANHANG
ADD CONSTRAINT P_CT_PBH PRIMARY KEY(MAPHIEU,MAHH)

ALTER TABLE CHITIETPHIEUDATHANG
ADD CONSTRAINT P_CT_PDH PRIMARY KEY(MAPHIEUDATHANG,MAHH)

ALTER TABLE CHITIETPHIEUNHANHANG
ADD CONSTRAINT P_CT_PNH PRIMARY KEY(MAPHIEU,MAHH)

ALTER TABLE PHIEUSUCO
ADD CONSTRAINT P_MAPHIEUSUCO PRIMARY KEY(MAPHIEUSUCO)

ALTER TABLE TONKHO
ADD CONSTRAINT P_TONKHO PRIMARY KEY(THOIGIAN)

----------------------------------------------
--=============T?O KH�A NGO?I================
----------------------------------------------
ALTER TABLE NHANVIEN 
ADD CONSTRAINT F_NV_GIOITINH FOREIGN KEY(GIOITINH) REFERENCES GIOITINH(GIOITINH)

ALTER TABLE NHANVIEN 
ADD CONSTRAINT F_NV_LOAINHANVIEN FOREIGN KEY(MALOAINV) REFERENCES LOAINHANVIEN(MALOAINV)

ALTER TABLE HANGHOA 
ADD CONSTRAINT F_HANGHOA_DONVITINH FOREIGN KEY(MADVT) REFERENCES DONVITINH(MADVT)

ALTER TABLE PHIEUBANHANG 
ADD CONSTRAINT F_PHIEUBANHANG_KHACHHANG FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE PHIEUBANHANG 
ADD CONSTRAINT F_PBH_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE PHIEUDATHANG 
ADD CONSTRAINT F_PDH_NHACUNGCAP FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC)

ALTER TABLE PHIEUDATHANG 
ADD CONSTRAINT F_PDH_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE CHITIETPHIEUBANHANG 
ADD CONSTRAINT FF_CTPBH_PBH FOREIGN KEY(MAPHIEU) REFERENCES PHIEUBANHANG(MAPHIEU)

ALTER TABLE CHITIETPHIEUBANHANG 
ADD CONSTRAINT F_CTPBH_HH FOREIGN KEY(MAHH) REFERENCES HANGHOA(MAHH)

ALTER TABLE CHITIETPHIEUDATHANG 
ADD CONSTRAINT F_CTPDH_PDH FOREIGN KEY(MAPHIEUDATHANG) REFERENCES PHIEUDATHANG(MAPHIEUDATHANG)

ALTER TABLE CHITIETPHIEUDATHANG 
ADD CONSTRAINT F_CTPDH_HH FOREIGN KEY(MAHH) REFERENCES HANGHOA(MAHH)

ALTER TABLE CHITIETPHIEUNHANHANG 
ADD CONSTRAINT F_CTPNH_PNH FOREIGN KEY(MAPHIEU) REFERENCES PHIEUNHANHANG(MAPHIEU)

ALTER TABLE CHITIETPHIEUNHANHANG 
ADD CONSTRAINT F_CTPNH_HH FOREIGN KEY(MAHH) REFERENCES HANGHOA(MAHH)

ALTER TABLE PHIEUSUCO 
ADD CONSTRAINT F_PSC_HH FOREIGN KEY(MAHH) REFERENCES HANGHOA(MAHH)

ALTER TABLE TONKHO 
ADD CONSTRAINT F_TONKHO_HH FOREIGN KEY(MAHH) REFERENCES HANGHOA(MAHH)

------------------------------------------------------------------
----===========FUNCTION========================-------------------
------------------------------------------------------------------

------------------Khach Hang---------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'AUTO_IDKhachHang')
DROP FUNCTION dbo.AUTO_IDKhachHang;
GO
	CREATE FUNCTION dbo.AUTO_IDKhachHang()
	RETURNS VARCHAR(8)
	AS
	BEGIN
		DECLARE @ID VARCHAR(8)
		IF (SELECT COUNT(MAKH) FROM KHACHHANG) = 0
			SET @ID = '001'
		ELSE
		BEGIN
			SELECT @ID = MAX(RIGHT(MAKH, LEN(MAKH) - 2)) FROM KHACHHANG;
			SET @ID = @ID + 1
			WHILE LEN(@ID) < 3 
			BEGIN 
				SET @ID = '0' + @ID 
			END
		END
		SET @ID = 'KH' + @ID

		RETURN @ID
	END
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'Insert_New_Customer')
DROP PROCEDURE dbo.Insert_New_Customer;
GO
	CREATE PROCEDURE dbo.Insert_New_Customer
	AS
	BEGIN
		DECLARE @ID VARCHAR(8)
		SELECT @ID = dbo.AUTO_IDKhachHang() 
		INSERT INTO KHACHHANG
		VALUES(@ID,'','','')
	END
GO


------------------Nha cung cap---------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'AUTO_IDNhaCungCap')
DROP FUNCTION dbo.AUTO_IDNhaCungCap;
GO
	CREATE FUNCTION dbo.AUTO_IDNhaCungCap()
	RETURNS VARCHAR(8)
	AS
	BEGIN
		DECLARE @ID VARCHAR(8)
		IF (SELECT COUNT(MANCC) FROM NHACUNGCAP) = 0
			SET @ID = '001'
		ELSE
		BEGIN
			SELECT @ID = MAX(RIGHT(MANCC, LEN(MANCC) - 3)) FROM NHACUNGCAP;
			SET @ID = @ID + 1
			WHILE LEN(@ID) < 3 
			BEGIN 
				SET @ID = '0' + @ID 
			END
		END
		SET @ID = 'NCC' + @ID

		RETURN @ID
	END
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'Insert_New_Supplier')
DROP PROCEDURE dbo.Insert_New_Supplier;
GO
	CREATE PROCEDURE dbo.Insert_New_Supplier
	AS
	BEGIN
		DECLARE @ID VARCHAR(8)
		SELECT @ID = dbo.AUTO_IDNhaCungCap() 
		INSERT INTO NHACUNGCAP
		VALUES(@ID,'','','')
	END
GO

------------------Don Vi Tinh---------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'AUTO_IDDonViTinh')
DROP FUNCTION dbo.AUTO_IDDonViTinh;
GO
	CREATE FUNCTION dbo.AUTO_IDDonViTinh()
	RETURNS VARCHAR(6)
	AS
	BEGIN
		DECLARE @ID VARCHAR(6)
		IF (SELECT COUNT(MADVT) FROM DONVITINH) = 0
			SET @ID = '001'
		ELSE
		BEGIN
			SELECT @ID = MAX(RIGHT(MADVT, LEN(MADVT) - 3)) FROM DONVITINH;
			SET @ID = @ID + 1
			WHILE LEN(@ID) < 3 
			BEGIN 
				SET @ID = '0' + @ID 
			END
		END
		SET @ID = 'DVT' + @ID

		RETURN @ID
	END
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'Insert_New_Unit')
DROP PROCEDURE dbo.Insert_New_Unit;
GO
	CREATE PROCEDURE dbo.Insert_New_Unit
	AS
	BEGIN
		DECLARE @ID VARCHAR(6)
		SELECT @ID = dbo.AUTO_IDDonViTinh() 
		INSERT INTO DONVITINH
		VALUES(@ID,'')
	END
GO

------------------Hang Hoa---------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'AUTO_IDHangHoa')
DROP FUNCTION dbo.AUTO_IDHangHoa;
GO
	CREATE FUNCTION dbo.AUTO_IDHangHoa()
	RETURNS VARCHAR(8)
	AS
	BEGIN
		DECLARE @ID VARCHAR(8)
		IF (SELECT COUNT(MAHH) FROM HANGHOA) = 0
			SET @ID = '001'
		ELSE
		BEGIN
			SELECT @ID = MAX(RIGHT(MAHH, LEN(MAHH) - 2)) FROM HANGHOA;
			SET @ID = @ID + 1
			WHILE LEN(@ID) < 3 
			BEGIN 
				SET @ID = '0' + @ID 
			END
		END
		SET @ID = 'HH' + @ID

		RETURN @ID
	END
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'Insert_New_Goods')
DROP PROCEDURE dbo.Insert_New_Goods;
GO
	CREATE PROCEDURE dbo.Insert_New_Goods
	AS
	BEGIN
		DECLARE @ID VARCHAR(8)
		SELECT @ID = dbo.AUTO_IDHangHoa() 
		INSERT INTO HANGHOA
		VALUES(@ID,'','DVT001','1/1/2017','0','0','0','')
	END
GO

------------------Nhan Vien---------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'AUTO_IDNhanVien')
DROP FUNCTION dbo.AUTO_IDNhanVien;
GO
	CREATE FUNCTION dbo.AUTO_IDNhanVien()
	RETURNS VARCHAR(6)
	AS
	BEGIN
		DECLARE @ID VARCHAR(6)
		IF (SELECT COUNT(MANV) FROM NHANVIEN) = 0
			SET @ID = '001'
		ELSE
		BEGIN
			SELECT @ID = MAX(RIGHT(MANV, LEN(MANV) - 2)) FROM NHANVIEN;
			SET @ID = @ID + 1
			WHILE LEN(@ID) < 3 
			BEGIN 
				SET @ID = '0' + @ID 
			END
		END
		SET @ID = 'NV' + @ID

		RETURN @ID
	END
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'Insert_New_Candidate')
DROP PROCEDURE dbo.Insert_New_Candidate;
GO
	CREATE PROCEDURE dbo.Insert_New_Candidate
	AS
	BEGIN
		DECLARE @ID VARCHAR(6)
		SELECT @ID = dbo.AUTO_IDNhanVien() 
		INSERT INTO NHANVIEN
		VALUES (@ID,'','','1/1/1996','GT001','','admin1','admin1','MNV002')
	END
GO

------------------Nhan Vien---------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'AUTO_IDTonKho')
DROP FUNCTION dbo.AUTO_IDTonKho;
GO
	CREATE FUNCTION dbo.AUTO_IDTonKho()
	RETURNS DATETIME
	AS
	BEGIN
		DECLARE @ID DATETIME
		IF (SELECT MAX(THOIGIAN) FROM TONKHO) = 0
			SET @ID = '2007-04-03 00:00:00.000'
		ELSE
		BEGIN
			SELECT @ID = MAX(THOIGIAN) FROM TONKHO;
			SET @ID = @ID + 1
		END
		RETURN @ID
	END
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'Insert_New_TonKho')
DROP PROCEDURE dbo.Insert_New_TonKho;
GO
	CREATE PROCEDURE dbo.Insert_New_TonKho
	AS
	BEGIN
		DECLARE @ID DATETIME
		SELECT @ID = dbo.AUTO_IDTonKho() 
		INSERT INTO TONKHO
		VALUES (@ID,'HH001','')
	END
GO
-----------------------------------------------
--==============NH?P LI?U ====================
-----------------------------------------------

--------------KH�CH H�NG-----------------
INSERT INTO KHACHHANG
VALUES('KH001','NGUYEN VAN A','THOAI SON','123456')

INSERT INTO KHACHHANG
VALUES('KH002','NGUYEN THI THANH','CHAU DOC','234567')

INSERT INTO KHACHHANG
VALUES('KH003','TRAN NGUYEN ANH THU','CHAU THANH','687456')

INSERT INTO KHACHHANG
VALUES('KH004','LE TRAN NGUYEN','THOAI SON','781236')

INSERT INTO KHACHHANG
VALUES('KH005','BUI DUC THINH','CAO LANH','124756')

-----------------LO?I NH�N VI�N----------------
INSERT INTO LOAINHANVIEN
VALUES('MNV001','QUAN LY')

INSERT INTO LOAINHANVIEN
VALUES('MNV002','BAN HANG')

---------------GI?I T�NH--------------------
INSERT INTO GIOITINH
VALUES('GT001','NAM')

INSERT INTO GIOITINH
VALUES('GT002','NU')

---------------NH�N VI�N------------------
INSERT INTO NHANVIEN
VALUES ('NV001','MAC THI HONG LAM','DONG THAP','10/10/1984','GT002','012345','admin1','admin1','MNV001')

INSERT INTO NHANVIEN
VALUES ('NV002','TRAN QUOC TRUNG','TINH BIEN','05/11/1986','GT001','122345','admin2','admin2','MNV001')

INSERT INTO NHANVIEN
VALUES ('NV003','NGUYEN THI HONG VAN','CHAU DOC','12/05/1985','GT002','067954','user1','user1','MNV002')

INSERT INTO NHANVIEN
VALUES ('NV004','CHE THI MAI HIEU','SA DEC','11/01/1987','GT002','123489','user2','user2','MNV002')

INSERT INTO NHANVIEN
VALUES ('NV005','PHAM PHUOC NGUYEN','PHU TAN','02/03/1981','GT001','698745','user3','user3','MNV002')

------------------NH� CUNG C?P------------------
INSERT INTO NHACUNGCAP
VALUES ('NCC001','NHA MAY THUOC LA �ONG THAP','CAO LANH-�ONG THAP','067987455')

INSERT INTO NHACUNGCAP
VALUES ('NCC002','NHA MAY BAI SAI GON','NGUYEN CHI THANH-TP HCM','08987455')

INSERT INTO NHACUNGCAP
VALUES ('NCC003','CTY DUOC HAU GIANG','CAN THO','071897455')

INSERT INTO NHACUNGCAP
VALUES ('NCC004','CTY BANH KEO BIEN HOA','BIEN HOA','0917987455')

----------------�ON V? T�NH---------------------
INSERT INTO DONVITINH
VALUES ('DVT001','KILOGAM')

INSERT INTO DONVITINH
VALUES ('DVT002','GOI')

INSERT INTO DONVITINH
VALUES ('DVT003','KET')

INSERT INTO DONVITINH
VALUES ('DVT004','BICH')

INSERT INTO DONVITINH
VALUES ('DVT005','THUNG')

-----------------H�NG H�A----------------------
INSERT INTO HANGHOA
VALUES ('HH001','BIA SAI GON','DVT003','11/10/2008','200','20','5','5000')

INSERT INTO HANGHOA
VALUES ('HH002','KEO','DVT004','04/06/2007','300','100','10','3000')

INSERT INTO HANGHOA
VALUES ('HH003','�UONG','DVT001','10/12/2006','500','50','5','8000')

INSERT INTO HANGHOA
VALUES ('HH004','THUOC LA','DVT002','01/01/2008','200','10','5','8000')

INSERT INTO HANGHOA
VALUES ('HH005','THUOC TAY','DVT005','06/06/2006','100','10','10','6000')

INSERT INTO HANGHOA
VALUES ('HH006','MUOI','DVT002','10/04/2008','400','50','10','2000')

INSERT INTO HANGHOA
VALUES ('HH007','SUA','DVT003','7/01/2017','400','50','10','6000')

INSERT INTO HANGHOA
VALUES ('HH008','SACH','DVT004','9/01/2017','400','50','10','4000')

----------PHI?U B�N H�NG---------------------
INSERT INTO PHIEUBANHANG
VALUES ('PBH001','KH001','NV002','10/11/2006','')

INSERT INTO PHIEUBANHANG
VALUES ('PBH002','KH004','NV003','08/10/2007','')

INSERT INTO PHIEUBANHANG
VALUES ('PBH003','KH002','NV001','12/04/2007','')

INSERT INTO PHIEUBANHANG
VALUES ('PBH004','KH001','NV004','05/09/2005','')

-----------PHI?U �?T H�NG---------------------
INSERT INTO PHIEUDATHANG
VALUES ('PDH001','NCC001','NV002','10/11/2006')

INSERT INTO PHIEUDATHANG
VALUES ('PDH002','NCC002','NV004','07/10/2007')

INSERT INTO PHIEUDATHANG
VALUES ('PDH003','NCC004','NV001','01/06/2006')

-------------PHI?U NH?N H�NG------------------
INSERT INTO PHIEUNHANHANG
VALUES ('PNH001','NCC001','NV001','01/06/2007','')

INSERT INTO PHIEUNHANHANG
VALUES ('PNH002','NCC004','NV002','10/10/2006','')

INSERT INTO PHIEUNHANHANG
VALUES ('PNH003','NCC003','NV005','11/12/2006','')

-------------CHI TI?T PHI?U B�N H�NG------------
INSERT INTO CHITIETPHIEUBANHANG
VALUES ('PBH001','HH002','3000','100','300000')

INSERT INTO CHITIETPHIEUBANHANG
VALUES ('PBH002','HH001','5000','1000','5000000')

INSERT INTO CHITIETPHIEUBANHANG
VALUES ('PBH003','HH004','8000','200','1600000')

INSERT INTO CHITIETPHIEUBANHANG
VALUES ('PBH004','HH005','6000','500','3000000')


-------------CHI TI?T PHI?U �?T H�NG------------
INSERT INTO CHITIETPHIEUDATHANG
VALUES ('PDH001','HH002','300')

INSERT INTO CHITIETPHIEUDATHANG
VALUES ('PDH002','HH003','1000')

INSERT INTO CHITIETPHIEUDATHANG
VALUES ('PDH003','HH005','500')


------------CHI TI?T PHI?U NH?N H�NG-----------
INSERT INTO CHITIETPHIEUNHANHANG
VALUES ('PNH001','HH004','5000','500','','PDH003')

INSERT INTO CHITIETPHIEUNHANHANG
VALUES ('PNH002','HH001','10000','200','','PDH004')

INSERT INTO CHITIETPHIEUNHANHANG
VALUES ('PNH003','HH002','15000','200','','PDH001')

--------------PHI?U S? C?------------------
INSERT INTO PHIEUSUCO
VALUES ('PSC001','HH001','10/12/2005','','50','10000','')

INSERT INTO PHIEUSUCO
VALUES ('PSC002','HH002','01/01/2006','','100','15000','')



---------------T?N KHO------------------

INSERT INTO TONKHO
VALUES ('04/06/2007','HH001','100')


INSERT INTO TONKHO
VALUES ('04/05/2007','HH002','90')

INSERT INTO TONKHO
VALUES ('04/04/2007','HH003','50')

INSERT INTO TONKHO
VALUES ('04/03/2007','HH004','70')
















 




