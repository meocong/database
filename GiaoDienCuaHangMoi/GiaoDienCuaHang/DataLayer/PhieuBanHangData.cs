using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiaoDienCuaHang.DataLayer
{
   public class PhieuBanHangData
    {
       DataService ds = new DataService();
       
       public DataTable LayDSPBH()
       {
           
           ds.Load(new SqlCommand("select * from PHIEUBANHANG"));
           return ds;
       }
       public DataTable LayDSCTPBH()
       {

           ds.Load(new SqlCommand("select * from CHITIETPHIEUBANHANG"));
           return ds;
       }
       public DataTable LayDSPhieuBanHang(String pbh)
       {
           SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUBANHANG WHERE MAKH=@k");
           cmd.Parameters.Add("k", SqlDbType.VarChar).Value = pbh;
           ds.Load(cmd);
           return ds;
       }
        public DataTable LayDSPhieuBanHangkhongdk()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUBANHANG");
            ds.Load(cmd);
            return ds;
        }
        public DataTable TimKiemPhieuBanHang(String MaKH, String chonMaNV, String MaNV, String chonNgayLap,DateTime TuNgay,DateTime DenNgay)
       {

           SqlCommand cmd = new SqlCommand();
           String SQL = "SELECT * FROM PHIEUBANHANG WHERE MAKH LIKE '%' + @Makh + '%' ";

           cmd.Parameters.Add("Makh", SqlDbType.VarChar).Value = MaKH;

           if (chonMaNV != "NONE")
           {
               SQL += chonMaNV + " MANV= @Manv ";
               cmd.Parameters.Add("Manv", SqlDbType.VarChar).Value = MaNV;

           }

           if (chonNgayLap!= "NONE")
           {
               SQL += chonNgayLap+ " (NGAYLAP BETWEEN @tn AND @dn) ";
               cmd.Parameters.Add("tn", SqlDbType.DateTime).Value = TuNgay;
               cmd.Parameters.Add("dn", SqlDbType.DateTime).Value = DenNgay;
           }

           cmd.CommandText = SQL;

           ds.Load(cmd);

           return ds;


       }
       public DataRow NewRow()
       {
           return ds.NewRow();
       }
       public void Add(DataRow r)
       {
           ds.Rows.Add(r);
       }
       public void Update()
       {
           ds.Update();
       }

        public void AddNewOrders()
        {
            ds.Exec("EXEC dbo.Insert_New_PhieuBanHang");
        }

        internal void AddNewDetailOrders(string text)
        {
            ds.Exec("EXEC dbo.Insert_New_ChiTietPhieuBanHang " + text);
        }

        public DataTable FindingPBH(string kh, DateTime start, DateTime end, string nv)
        {
            string SQL = "SELECT * from PHIEUBANHANG WHERE MAKH LIKE '%' + @kh+ '%' AND MANV LIKE '%' + @nv+ '%' AND NGAYLAP >= @start AND NGAYLAP <= @end";

            SqlCommand cmd = new SqlCommand(SQL);

            cmd.Parameters.Add("kh", SqlDbType.VarChar).Value = kh;
            cmd.Parameters.Add("nv", SqlDbType.VarChar).Value = nv;
            cmd.Parameters.Add("start", SqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("end", SqlDbType.DateTime).Value = end;
            ds.Load(cmd);
            return ds;
        }
    }
}
