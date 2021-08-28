using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace BachHoaXanh
{
    public class QL_NguoiDung
    {
        public int Check_Config()
        {
            if (Properties.Settings.Default.ChuoiKetNoi == string.Empty)
                return 1;
            SqlConnection _sqlCon = new SqlConnection(Properties.Settings.Default.ChuoiKetNoi);
            try
            {
                if (_sqlCon.State == System.Data.ConnectionState.Closed)
                    _sqlCon.Open();
                return 0;
            }
            catch
            {
                return 2;
            }

        }
        public int Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from NhanVien where MaNV='" + pUser + "' and MatKhau ='" + pPass + "'",
            Properties.Settings.Default.ChuoiKetNoi);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return 10;// User không tồn tại
            else if (dt.Rows[0][8] == null || dt.Rows[0][8].ToString() == "False")
            {
                return 20;// Không hoạt động
            }
            return 30;// Đăng nhập thành công
        }
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        public DataTable GetDBName(string pServer, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases",
            "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " +
            pPass + "");
            da.Fill(dt);
            return dt;
        }
        public void SaveConfig(string pServer, string pUser, string pPass, string pDBname)
        {
            BachHoaXanh.Properties.Settings.Default.ChuoiKetNoi = "Data Source=" + pServer +
            ";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";pwd = " + pPass + "";
            BachHoaXanh.Properties.Settings.Default.Save();
        }
        public DataTable Search(string tuKhoaTK, string table, string tenCot1, string tenCot2)
        {           
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + table + " WHERE " + tenCot1 + " LIKE N'%" + tuKhoaTK + "%' or " + tenCot1 + " ='"+tuKhoaTK+ "' or " +tenCot2 + " LIKE N'%" + tuKhoaTK + "%' or " + tenCot2 + " = '"+tuKhoaTK+"'",  Properties.Settings.Default.ChuoiKetNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SearchCT(string tuKhoaTK, string table1, string table2, string equal, string tenCot1)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " + table1 + ".* FROM " + table1 +", " + table2 + " WHERE "+ table1 + "." + equal + "=" + table2 + "." + equal +" and "  + table2 + "." + tenCot1 + " ='" + tuKhoaTK + "' ", Properties.Settings.Default.ChuoiKetNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
