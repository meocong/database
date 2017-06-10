using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        public DataTable TimKiemTonKho(string v1, string v2)
        {
            SqlCommand cmd = new SqlCommand();

            if (v1.Length == 1)
            {
                v1 = '0' + v1;
            }

            if (v2.Length == 1)
            {
                v2 = '0' + v2;
            }

            DateTime dateTimeStart = DateTime.Parse(v1 + "/" + "01/" + v2);
            if (int.Parse(v1) == 12)
            {
                v1 = "01";
                v2 = (int.Parse(v2) + 1).ToString();
            }
            else
            {
                v1 = (int.Parse(v1) + 1).ToString();
                if (v1.Length == 1)
                {
                    v1 = '0' + v1;
                }
            }
            DateTime dateTimeEnd   = DateTime.Parse(v1 + "/" + "01/" + v2);

            String SQL = "SELECT * FROM TONKHO WHERE THOIGIAN >= @start AND THOIGIAN <=  @end ";

            //MessageBox.Show(dateTimeStart.Date.ToString());
            cmd.Parameters.Add("start", SqlDbType.DateTime).Value = dateTimeStart.Date;

            cmd.Parameters.Add("end", SqlDbType.DateTime).Value = dateTimeEnd.Date;

            cmd.CommandText = SQL;
            ds.Load(cmd);

            return ds;
        }

        public DataTable TimKiemTonKho(string v1)
        {
            SqlCommand cmd = new SqlCommand();

            String SQL = "SELECT * FROM TONKHO WHERE MAHH=@sp ";

            cmd.Parameters.Add("sp", SqlDbType.VarChar).Value = v1;

            cmd.CommandText = SQL;
            ds.Load(cmd);

            return ds;
        }

        public void AddNewRow()
        {
            ds.Exec("EXEC dbo.Insert_New_TonKho");
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

                string SQL = "UPDATE TONKHO SET MAHH = @mHH, SLTON = @count WHERE THOIGIAN = @tg";
                SqlCommand cmd = new SqlCommand(SQL, ds.m_Connection);

                cmd.Parameters.Add("tg", SqlDbType.DateTime).Value = row.Cells[0].Value;
                cmd.Parameters.Add("mHH", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                cmd.Parameters.Add("count", SqlDbType.NVarChar).Value = row.Cells[2].Value;

                cmd.ExecuteNonQuery();
            }
            ds.m_Connection.Close();
        }
    }
}
