using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiaoDienCuaHang
{
    public class DataService:DataTable
    {
        static SqlConnection m_Connection;
        SqlDataAdapter m_DataAdapter;
        SqlCommand m_Command;
        string strConn = "Data Source=DESKTOP-BM7POO3\\SQLEXPRESS;Initial Catalog=QLCHmoi;Integrated Security=True";

        public DataService()
        {

        }
        public void Load(SqlCommand command)
        {
            if (m_Connection == null || m_Connection.State == ConnectionState.Closed)
            {
                m_Connection = new SqlConnection(strConn);
                m_Connection.Open();
            }
            m_Command = command;
            m_Command.Connection = m_Connection;

            m_DataAdapter = new SqlDataAdapter(m_Command);
            this.Clear();
            m_DataAdapter.Fill(this);
            m_Connection.Close();
        }

        public void Exec(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            m_Connection.Open();
            SqlCommandBuilder builder = new SqlCommandBuilder(m_DataAdapter);
            m_DataAdapter.Update(this);
            m_Connection.Close();
        }

        public void Update_to_database(System.Windows.Forms.DataGridView dataGridView1)
        {
            m_Connection.Open();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == dataGridView1.Rows.Count - 1)
                {
                    break;
                }

                string SQL = "UPDATE KHACHHANG SET HOTEN = @name, DIACHI = @address, DIENTHOAI = @phone WHERE MAKH = @id ";
                SqlCommand cmd = new SqlCommand(SQL, m_Connection);
  
                cmd.Parameters.Add("id", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                cmd.Parameters.Add("address", SqlDbType.NVarChar).Value = row.Cells[2].Value;
                cmd.Parameters.Add("phone", SqlDbType.NVarChar).Value = row.Cells[3].Value;

                cmd.ExecuteNonQuery();
            }
            m_Connection.Close();
        }
    }
}
