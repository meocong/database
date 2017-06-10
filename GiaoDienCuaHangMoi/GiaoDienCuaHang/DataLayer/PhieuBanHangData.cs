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

        public DataTable LayDS_TK_PBH_ToanBo()
        {
            SqlCommand cmd = new SqlCommand("SELECT CHITIETPHIEUBANHANG.THANHTIEN, PHIEUBANHANG.MAPHIEU, KHACHHANG.HOTEN, NHANVIEN.HOTEN, NHANVIEN.MALOAINV FROM CHITIETPHIEUBANHANG , PHIEUBANHANG, KHACHHANG, NHANVIEN WHERE CHITIETPHIEUBANHANG.MAPHIEU = PHIEUBANHANG.MAPHIEU AND KHACHHANG.MAKH = PHIEUBANHANG.MAKH AND NHANVIEN.MANV = PHIEUBANHANG.MANV");
            ds.Load(cmd);
            return ds;
        }


       public DataTable LayDSCTPBH()
       {

           ds.Load(new SqlCommand("select * from CHITIETPHIEUBANHANG"));
           return ds;
       }
       public DataTable LayDSPhieuBanHang(String pbh)
       {
            if(pbh == "")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUBANHANG");
                cmd.Parameters.Add("k", SqlDbType.VarChar).Value = pbh;
                ds.Load(cmd);
                return ds;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUBANHANG WHERE MAKH=@k");
                cmd.Parameters.Add("k", SqlDbType.VarChar).Value = pbh;
                ds.Load(cmd);
                return ds;
            }
           
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
    }
}
