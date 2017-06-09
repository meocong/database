using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
            SqlCommandBuilder builder = new SqlCommandBuilder(m_DataAdapter);
            m_DataAdapter.Update(this);
        }
    }
}
