using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiaoDienCuaHang.DataLayer
{
   public class KhachHangData
    {
       DataService ds = new DataService();
       public DataTable LayDSKhachHang()
       {
           SqlCommand cmd = new SqlCommand("select * from KHACHHANG");
           ds.Load(cmd);
           return ds;
       }
       public DataTable TKKhachHang(String tenkhachhang, String chondchi, String dchi, String chondthoai, String dthoai)
       {

           SqlCommand cmd = new SqlCommand();
           String SQL = "SELECT * FROM KHACHHANG WHERE HOTEN LIKE '%' + @tKH + '%' ";

           cmd.Parameters.Add("tKH", SqlDbType.NVarChar).Value = tenkhachhang;

           if (chondchi != "NONE")
           {
               SQL += chondchi + " DIACHI LIKE '%' + @dc  + '%' ";
               cmd.Parameters.Add("dc", SqlDbType.NVarChar).Value = dchi;

           }

           if (chondthoai != "NONE")
           {
               SQL += chondthoai + " DIENTHOAI LIKE '%' + @dt  + '%' ";
               cmd.Parameters.Add("dt", SqlDbType.VarChar).Value = dthoai;
           }

           cmd.CommandText = SQL;

           ds.Load(cmd);

           return ds;


       }

        public void AddNewRow()
        {
            ds.Exec("EXEC dbo.Insert_New_Customer");
        }

        public DataTable DataKhachHang(String id, String name, String address, String phone)
        {
            bool checkWhere = false;
            SqlCommand cmd = new SqlCommand();
            String SQL = "SELECT * FROM KHACHHANG ";

            // Find Id
            if (id != "")
            {
                if (checkWhere == false)
                {
                    checkWhere = true;
                    SQL += " WHERE ";
                }
                else
                {
                    SQL += " AND ";
                }

                SQL += " MAKH LIKE '%' + @mKH + '%' ";
                cmd.Parameters.Add("mKH", SqlDbType.NVarChar).Value = id;
            }

            // Find name
            if (name != "")
            {
                if (checkWhere == false)
                {
                    checkWhere = true;
                    SQL += " WHERE ";
                }
                else
                {
                    SQL += " AND ";
                }

                SQL += " HOTEN LIKE '%' + @tKH + '%' ";
                cmd.Parameters.Add("tKH", SqlDbType.NVarChar).Value = name;
            }

            // Find address
            if (address != "")
            {
                if (checkWhere == false)
                {
                    checkWhere = true;
                    SQL += " WHERE ";
                }
                else
                {
                    SQL += " AND ";
                }

                SQL += " DIACHI LIKE '%' + @dc  + '%' ";
                cmd.Parameters.Add("dc", SqlDbType.NVarChar).Value = address;
            }

            // Find phone
            if (phone != "")
            {
                if (checkWhere == false)
                {
                    checkWhere = true;
                    SQL += " WHERE ";
                }
                else
                {
                    SQL += " AND ";
                }

                SQL += " DIENTHOAI LIKE '%' + @dt  + '%' ";
                cmd.Parameters.Add("dt", SqlDbType.VarChar).Value = phone;
            }

            cmd.CommandText = SQL;

            ds.Load(cmd);

            return ds;
        }
        public void Update()
       {
           ds.Update();
       }
    }
}
