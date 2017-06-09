using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiaoDienCuaHang.DataLayer
{
   public class NhaCungCapData
    {
       DataService ds = new DataService();
       public DataTable LayDSNhaCungCap()
       {
           SqlCommand cmd = new SqlCommand("select * from NHACUNGCAP");
           ds.Load(cmd);
           return ds;
       }
       public DataTable LayNhaCungCap(String username)
       {
           String sql = "SELECT * FROM NHANVIEN WHERE USERNAME = @ten";
           SqlCommand cd = new SqlCommand(sql);
           cd.Parameters.Add("ten", SqlDbType.VarChar).Value = username;
           ds.Load(cd);

           return ds;

       }
       public DataTable TKNhaCungCap(String TenNCC, String chondchi, String dchi, String chondthoai, String dthoai)
       {

           SqlCommand cmd = new SqlCommand();
           String SQL = "SELECT * FROM NHACUNGCAP WHERE TENNCC LIKE '%' + @tNCC + '%' ";

           cmd.Parameters.Add("tNCC", SqlDbType.NVarChar).Value = TenNCC; 
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
       public void Update()
       {
           ds.Update();
       }

        public DataTable DataNhaCungCap(String id, String name, String address, String phone)
        {
            bool checkWhere = false;
            SqlCommand cmd = new SqlCommand();
            String SQL = "SELECT * FROM NHACUNGCAP ";

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

                SQL += " MANCC LIKE '%' + @mKH + '%' ";
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

                SQL += " TENNCC LIKE '%' + @tKH + '%' ";
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

        public void AddNewRow()
        {
            ds.Exec("EXEC dbo.Insert_New_Supplier");
        }

        public void Update_to_database(DataGridView dataGridView1)
        {
            ds.m_Connection.Open();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == dataGridView1.Rows.Count - 1)
                {
                    break;
                }

                string SQL = "UPDATE NHACUNGCAP SET TENNCC = @name, DIACHI = @address, DIENTHOAI = @phone WHERE MANCC = @id ";
                SqlCommand cmd = new SqlCommand(SQL, ds.m_Connection);

                cmd.Parameters.Add("id", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                cmd.Parameters.Add("address", SqlDbType.NVarChar).Value = row.Cells[2].Value;
                cmd.Parameters.Add("phone", SqlDbType.NVarChar).Value = row.Cells[3].Value;

                cmd.ExecuteNonQuery();
            }
            ds.m_Connection.Close();
        }
    }
}
