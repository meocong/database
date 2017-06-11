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



