using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiaoDienCuaHang.DataLayer
{
   public class TonKhoData
    {
       DataService ds = new DataService();
       public DataTable LayDSTonKho()
       {
           SqlCommand cmd = new SqlCommand("select * from TONKHO");
           ds.Load(cmd);
           return ds;
       }
       public DataTable LayDS_TonKho(String tkho)
       {
           SqlCommand cmd = new SqlCommand("select * from PHIEUSUCO where MAHH=@sp");

           cmd.Parameters.Add("sp", SqlDbType.VarChar).Value = tkho;
           ds.Load(cmd);
           return ds;
       }
       public void Update()
       {
           ds.Update();
       }
        public DataTable LayDS_TK_TonKho()
        {
            SqlCommand cmd = new SqlCommand("select THANG, NAM, SLTON, HANGHOA.TENHH  from TONKHO, HANGHOA where HANGHOA.MAHH = TONKHO.MAHH");
            ds.Load(cmd);
            return ds;
        }
        public DataTable LayDS_TK_TonKho_MotPhan(string mahh)
        {
            SqlCommand cmd = new SqlCommand("select THANG, NAM, SLTON, HANGHOA.TENHH  from TONKHO, HANGHOA where HANGHOA.MAHH = TONKHO.MAHH and TONKHO.MAHH = '" + mahh + "'");
            ds.Load(cmd);
            return ds;
        }
    }
}
