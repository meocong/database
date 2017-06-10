using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiaoDienCuaHang.DataLayer
{
   public class NhanVienData
    {
       DataService ds = new DataService();
       public DataTable LayDSNhanVien()
       {
           SqlCommand cmd = new SqlCommand("select * from NHANVIEN");
           ds.Load(cmd);
           return ds;   
       }
       public DataTable LayNhanvien(String username)
       {
           String sql = "SELECT * FROM NHANVIEN WHERE USERNAME = @ten";
           SqlCommand cd = new SqlCommand(sql);
           cd.Parameters.Add("ten", SqlDbType.VarChar).Value = username;
           ds.Load(cd);

           return ds;

       }
       public void Update()
       {
           ds.Update();
       }

        public void AddNewRow()
        {
            ds.Exec("EXEC dbo.Insert_New_Candidate");
        }

        public DataTable TimKiemNhanVienNew(string text1, string text2, string text3, string text4, string selectedValue1, string selectedValue2)
        {
            SqlCommand cmd = new SqlCommand();
            String SQL = "SELECT * FROM NHANVIEN WHERE MANV LIKE '%' + @mNV + '%' AND HOTEN LIKE '%' + @tNV + '%' AND DIACHI LIKE '%' + @dcNV + '%' AND DIENTHOAI LIKE '%' + @dtNV + '%' ";

            cmd.Parameters.Add("mNV", SqlDbType.VarChar).Value = text1;

            cmd.Parameters.Add("tNV", SqlDbType.VarChar).Value = text2;

            cmd.Parameters.Add("dcNV", SqlDbType.VarChar).Value = text3;

            cmd.Parameters.Add("dtNV", SqlDbType.VarChar).Value = text4;
            
            if (selectedValue1 != "")
            {
                SQL += " AND MALOAINV = @loaiNV";
                cmd.Parameters.Add("loaiNV", SqlDbType.VarChar).Value = selectedValue1;
            }

            if (selectedValue2 != "")
            {
                SQL += " AND GIOITINH = @gt";
                cmd.Parameters.Add("gt", SqlDbType.VarChar).Value = selectedValue2;
            }
            //SQL += " AND SOLUONG >=  @beginCount ";
            //cmd.Parameters.Add("beginCount", SqlDbType.Int).Value = beginCount;

            //SQL += " AND SOLUONG <= @endCount ";
            //cmd.Parameters.Add("endCount", SqlDbType.Int).Value = endCount;

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

                string SQL = "UPDATE NHANVIEN SET HOTEN = @name, DIACHI = @dc, NGAYSINH = @day, GIOITINH = @gt, DIENTHOAI = @dt, USERNAME = @username, PASSWORDS = @pass, MALOAINV = @loainv WHERE MAHV = @id ";
                SqlCommand cmd = new SqlCommand(SQL, ds.m_Connection);

                cmd.Parameters.Add("id", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                cmd.Parameters.Add("dc", SqlDbType.NVarChar).Value = row.Cells[2].Value;
                cmd.Parameters.Add("day", SqlDbType.NVarChar).Value = row.Cells[3].Value;
                cmd.Parameters.Add("dt", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                cmd.Parameters.Add("gt", SqlDbType.NVarChar).Value = row.Cells[5].Value;
                cmd.Parameters.Add("username", SqlDbType.NVarChar).Value = row.Cells[6].Value;
                cmd.Parameters.Add("pass", SqlDbType.NVarChar).Value = row.Cells[7].Value;
                cmd.Parameters.Add("loainv", SqlDbType.NVarChar).Value = row.Cells[8].Value;

                cmd.ExecuteNonQuery();
            }
            ds.m_Connection.Close();
        }
    }
}
