using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiaoDienCuaHang.DataLayer
{
    public class HangHoaData
    {
        DataService ds = new DataService();
        public DataTable LayDSHangHoa()
        {

            ds.Load(new SqlCommand("select * from HANGHOA"));
            return ds;
        }
        public DataTable LayDSHHsaphethan(int month)
        {
            DateTime start = DateTime.Today.Date;
            DateTime end = DateTime.Today.Date.AddMonths(month);

            SqlCommand cmd = new SqlCommand("SELECT * FROM HANGHOA WHERE NGAYHETHAN >= @start AND NGAYHETHAN <= @end");
            cmd.Parameters.Add("start", SqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("end", SqlDbType.DateTime).Value = end;

            ds.Load(cmd);
            return ds;
        }
        public DataTable LayDSHangHoa(String hh)
        {
            SqlCommand cmd = new SqlCommand("select * from HANGHOA where MADVT=@d");

            cmd.Parameters.Add("d", SqlDbType.VarChar).Value = hh;
            ds.Load(cmd);
            return ds;
        }
        public DataTable Lay_vw_DVT()
        {
            SqlCommand cmd = new SqlCommand("exec crt_vw_thongke_hanghoatheodvt select * from vw_hanghoa");
            ds.Load(cmd);
            return ds;
        }
        public DataTable Lay_vw_DVTcodk(string dvt)
        {
            SqlCommand cmd = new SqlCommand("exec crt_vw_thongke_hanghoatheodvt select * from vw_hanghoa where MADVT = '" + dvt + "'");
            ds.Load(cmd);
            return ds;
        }


        public DataTable TimKiemHangHoa(String ten, String chonMaDVT, String MaDVT, String chonSL, String Soluong, String chonSLG, String SLGiam, String chonTLG, String TLGiam)
        {

            SqlCommand cmd = new SqlCommand();
            String SQL = "SELECT * FROM HANGHOA WHERE TENHH LIKE '%' + @tHH + '%' ";

            cmd.Parameters.Add("tHH", SqlDbType.VarChar).Value = ten;

            if (chonMaDVT != "NONE")
            {
                SQL += chonMaDVT + " MADVT= @Madvt ";
                cmd.Parameters.Add("Madvt", SqlDbType.VarChar).Value = MaDVT;

            }

            if (chonSL != "NONE")
            {
                SQL += chonSL + " SOLUONG= @soluong ";
                cmd.Parameters.Add("soluong", SqlDbType.Int).Value = Soluong;
            }

            if (chonSLG != "NONE")
            {
                SQL += chonSLG + " SOLUONGGIAM = @soluonggiam ";
                cmd.Parameters.Add("soluonggiam", SqlDbType.Int).Value = SLGiam;
            }
            if (chonTLG != "NONE")
            {
                SQL += chonTLG + " TILEGIAM = @TILEGIAM ";
                cmd.Parameters.Add("TILEGIAM", SqlDbType.Int).Value = TLGiam;
            }


            cmd.CommandText = SQL;

            ds.Load(cmd);

            return ds;


        }

        public DataTable TimKiemHangHoaNew(string MaHH, string tenHH, DateTime start, DateTime end, Int32 beginCount, Int32 endCount, Int32 beginPrice, Int32 endPrice)
        {
            SqlCommand cmd = new SqlCommand();
            String SQL = "SELECT * FROM HANGHOA WHERE MAHH LIKE '%' + @mHH + '%' AND TENHH LIKE '%' + @tHH + '%' AND NGAYHETHAN >= @start AND NGAYHETHAN <=  @end ";

            cmd.Parameters.Add("mHH", SqlDbType.VarChar).Value = MaHH;

            cmd.Parameters.Add("tHH", SqlDbType.VarChar).Value = tenHH;

            cmd.Parameters.Add("start", SqlDbType.DateTime).Value = start;

            cmd.Parameters.Add("end", SqlDbType.DateTime).Value = end;

            SQL += " AND SOLUONG >=  @beginCount ";
            cmd.Parameters.Add("beginCount", SqlDbType.Int).Value = beginCount;

            SQL += " AND SOLUONG <= @endCount ";
            cmd.Parameters.Add("endCount", SqlDbType.Int).Value = endCount;

            SQL += " AND DONGIA >=  @beginPrice ";
            cmd.Parameters.Add("beginPrice", SqlDbType.Int).Value = beginPrice;

            SQL += " AND DONGIA <= @endPrice ";
            cmd.Parameters.Add("endPrice", SqlDbType.Int).Value = endPrice;

            cmd.CommandText = SQL;
            ds.Load(cmd);

            return ds;
        }

        public void AddNewRow()
        {
            ds.Exec("EXEC dbo.Insert_New_Goods");
        }

        public void Update()
        {
            ds.Update();
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

                string SQL = "UPDATE HANGHOA SET TENHH = @name, MADVT = @dvt, NGAYHETHAN = @day, SOLUONG = @count, SOLUONGGIAM = @countdown, TILEGIAM = @ratiodown, DONGIA = @price WHERE MAHH = @id ";
                SqlCommand cmd = new SqlCommand(SQL, ds.m_Connection);

                cmd.Parameters.Add("id", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                cmd.Parameters.Add("dvt", SqlDbType.NVarChar).Value = row.Cells[2].Value;
                cmd.Parameters.Add("day", SqlDbType.NVarChar).Value = row.Cells[3].Value;
                cmd.Parameters.Add("count", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                cmd.Parameters.Add("countdown", SqlDbType.NVarChar).Value = row.Cells[5].Value;
                cmd.Parameters.Add("ratiodown", SqlDbType.NVarChar).Value = row.Cells[6].Value;
                cmd.Parameters.Add("price", SqlDbType.NVarChar).Value = row.Cells[7].Value;

                cmd.ExecuteNonQuery();
            }
            ds.m_Connection.Close();
        }
    }
}
