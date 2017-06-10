using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiaoDienCuaHang.DataLayer
{
   public class DonViTinhData
    {
       DataService ds = new DataService();
       public DataTable LayDSDonViTinh()
       {
           SqlCommand cmd = new SqlCommand("select * from DONVITINH");
           ds.Load(cmd);
           return ds;
       }
       public DataTable TimKiemDVT(String ten)
       {
          
           
           SqlCommand cmd = new SqlCommand();
           String SQL = "SELECT * FROM DONVITINH WHERE TENDVT LIKE '%' + @ht + '%' ";

           cmd.Parameters.Add("ht", SqlDbType.VarChar).Value = ten;

           cmd.CommandText = SQL;

           ds.Load(cmd);

           return ds;

       }

    
       public void Update()
       {
           ds.Update();
       }

       public void AddNewRow()
        {
            ds.Exec("EXEC dbo.Insert_New_Unit");
        }

        public DataTable DataDonViTinh(String id, String name)
        {
            bool checkWhere = false;
            SqlCommand cmd = new SqlCommand();
            String SQL = "SELECT * FROM DONVITINH ";

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

                SQL += " MADVT LIKE '%' + @mKH + '%' ";
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

                SQL += " TENDVT LIKE '%' + @tKH + '%' ";
                cmd.Parameters.Add("tKH", SqlDbType.NVarChar).Value = name;
            }

            cmd.CommandText = SQL;

            ds.Load(cmd);

            return ds;
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

                string SQL = "UPDATE DONVITINH SET TENDVT = @name WHERE MADVT = @id ";
                SqlCommand cmd = new SqlCommand(SQL, ds.m_Connection);

                cmd.Parameters.Add("id", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = row.Cells[1].Value;

                cmd.ExecuteNonQuery();
            }
            ds.m_Connection.Close();
        }

    }
}
