
--1------------------------------------------------------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'crt_vw_thongke_tonkho')
DROP PROCEDURE dbo.crt_vw_thongke_tonkho;
GO
create procedure crt_vw_thongke_tonkho
AS
GO
	IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_tonkho')
	DROP view dbo.vw_tonkho
	GO
	create view dbo.vw_tonkho 
	as
	SELECT "TONKHO"."THOIGIAN", "TONKHO"."MAHH", "TONKHO"."SLTON", "HANGHOA"."TENHH" FROM   "QLCHmoi"."dbo"."TONKHO" "TONKHO" INNER JOIN "QLCHmoi"."dbo"."HANGHOA" "HANGHOA" ON "TONKHO"."MAHH"="HANGHOA"."MAHH"
	GO
GO
GO
--2-----------------------------------------------------------------
IF EXISTS(SELECT name FROM sys.objects WHERE name = N'crt_vw_thongke_hanghoatheodvt')
DROP PROCEDURE dbo.crt_vw_thongke_hanghoatheodvt;
GO
create procedure crt_vw_thongke_hanghoatheodvt
AS
GO
	IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_hanghoa')
	DROP view dbo.vw_hanghoa
	GO
	create view dbo.vw_hanghoa
	as
 SELECT "HANGHOA"."MAHH", "HANGHOA"."TENHH", "HANGHOA"."MADVT", "HANGHOA"."NGAYHETHAN", "HANGHOA"."SOLUONG", "HANGHOA"."DONGIA", "DONVITINH"."TENDVT"
 FROM   "QLCHmoi"."dbo"."HANGHOA" "HANGHOA" INNER JOIN "QLCHmoi"."dbo"."DONVITINH" "DONVITINH" ON "HANGHOA"."MADVT"="DONVITINH"."MADVT"
	GO
GO
GO

--3------------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_donvitinh')
	DROP view dbo.vw_donvitinh
	GO
	create view dbo.vw_donvitinh
	as
 SELECT "DONVITINH"."MADVT", "DONVITINH"."TENDVT"
 FROM   "QLCHmoi"."dbo"."DONVITINH" "DONVITINH"
go
---4-------------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_khachhang')
	DROP view dbo.vw_khachhang
	GO
	create view dbo.vw_khachhang
	as
    SELECT "KHACHHANG"."MAKH", "KHACHHANG"."HOTEN", "KHACHHANG"."DIACHI", "KHACHHANG"."DIENTHOAI"
    FROM   "QLCHmoi"."dbo"."KHACHHANG" "KHACHHANG"
go
---5------------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_nhacungcap')
	DROP view dbo.vw_nhacungcap
	GO
	create view dbo.vw_nhacungcap
	as
	SELECT "NHACUNGCAP"."MANCC", "NHACUNGCAP"."TENNCC", "NHACUNGCAP"."DIACHI", "NHACUNGCAP"."DIENTHOAI"
	FROM   "QLCHmoi"."dbo"."NHACUNGCAP" "NHACUNGCAP"
go
----6----------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_nhanvien')
	DROP view dbo.vw_nhanvien
	GO
	create view dbo.vw_nhanvien
	as
	SELECT "NHANVIEN"."MANV", "NHANVIEN"."HOTEN", "NHANVIEN"."DIACHI", "NHANVIEN"."NGAYSINH", "NHANVIEN"."GIOITINH", "NHANVIEN"."DIENTHOAI", "NHANVIEN"."MALOAINV"
	FROM   "QLCHmoi"."dbo"."NHANVIEN" "NHANVIEN"
go
-----7---------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_phieubanhang')
	DROP view dbo.vw_phieubanhang
	GO
	create view dbo.vw_phieubanhang
	as
	SELECT "PHIEUBANHANG"."MAPHIEU", "CHITIETPHIEUBANHANG"."MAHH", "CHITIETPHIEUBANHANG"."THANHTIEN", "NHANVIEN"."HOTEN" as HOTENNV, "NHANVIEN"."MALOAINV", "KHACHHANG"."HOTEN", "KHACHHANG"."MAKH"
	FROM   (("QLCHmoi"."dbo"."CHITIETPHIEUBANHANG" "CHITIETPHIEUBANHANG" 
	INNER JOIN "QLCHmoi"."dbo"."PHIEUBANHANG" "PHIEUBANHANG" ON "CHITIETPHIEUBANHANG"."MAPHIEU"="PHIEUBANHANG"."MAPHIEU") 
	INNER JOIN "QLCHmoi"."dbo"."KHACHHANG" "KHACHHANG" ON "PHIEUBANHANG"."MAKH"="KHACHHANG"."MAKH") 
	INNER JOIN "QLCHmoi"."dbo"."NHANVIEN" "NHANVIEN" ON "PHIEUBANHANG"."MANV"="NHANVIEN"."MANV"
go
------8--------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_phieudathang')
	DROP view dbo.vw_phieudathang
	GO
	create view dbo.vw_phieudathang
	as
	SELECT "PHIEUDATHANG"."MAPHIEUDATHANG", "CHITIETPHIEUDATHANG"."MAHH", "CHITIETPHIEUDATHANG"."SOLUONG", "NHANVIEN"."HOTEN", "NHANVIEN"."MALOAINV", "NHACUNGCAP"."TENNCC", "PHIEUDATHANG"."MANCC"
	FROM   (("QLCHmoi"."dbo"."CHITIETPHIEUDATHANG" "CHITIETPHIEUDATHANG" 
	INNER JOIN "QLCHmoi"."dbo"."PHIEUDATHANG" "PHIEUDATHANG" ON "CHITIETPHIEUDATHANG"."MAPHIEUDATHANG"="PHIEUDATHANG"."MAPHIEUDATHANG") 
	INNER JOIN "QLCHmoi"."dbo"."NHACUNGCAP" "NHACUNGCAP" ON "PHIEUDATHANG"."MANCC"="NHACUNGCAP"."MANCC") 
	INNER JOIN "QLCHmoi"."dbo"."NHANVIEN" "NHANVIEN" ON "PHIEUDATHANG"."MANV"="NHANVIEN"."MANV"
go
-------9-------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_phieunhanhang')
	DROP view dbo.vw_phieunhanhang
	GO
	create view dbo.vw_phieunhanhang
	as
	SELECT "CHITIETPHIEUNHANHANG"."MAPHIEU", "CHITIETPHIEUNHANHANG"."MAPHIEUDATHANG", "NHACUNGCAP"."TENNCC", "NHANVIEN"."HOTEN"
	FROM   (("QLCHmoi"."dbo"."CHITIETPHIEUNHANHANG" "CHITIETPHIEUNHANHANG" 
	INNER JOIN "QLCHmoi"."dbo"."PHIEUNHANHANG" "PHIEUNHANHANG" ON "CHITIETPHIEUNHANHANG"."MAPHIEU"="PHIEUNHANHANG"."MAPHIEU") 
	INNER JOIN "QLCHmoi"."dbo"."NHACUNGCAP" "NHACUNGCAP" ON "PHIEUNHANHANG"."MANCC"="NHACUNGCAP"."MANCC") 
	INNER JOIN "QLCHmoi"."dbo"."NHANVIEN" "NHANVIEN" ON "PHIEUNHANHANG"."MANV"="NHANVIEN"."MANV"
go
--------10-------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.objects WHERE name = N'vw_phieusuco')
	DROP view dbo.vw_phieusuco
	GO
	create view dbo.vw_phieusuco
	as
	SELECT "PHIEUSUCO"."MAPHIEUSUCO", "PHIEUSUCO"."NGAYHUHONG", "PHIEUSUCO"."SOLUONGHUHONG", "PHIEUSUCO"."DONGIA", "PHIEUSUCO"."TONGTIENHUHONG", "HANGHOA"."TENHH"
	FROM   "QLCHmoi"."dbo"."PHIEUSUCO" "PHIEUSUCO" 
	INNER JOIN "QLCHmoi"."dbo"."HANGHOA" "HANGHOA" ON "PHIEUSUCO"."MAHH"="HANGHOA"."MAHH"
go




