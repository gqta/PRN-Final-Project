using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace PRN_Final_Project.DAO
{
    public class Database
    {
        /// <summary>
        /// Hàm trả về 1 SqlConnection là nền tảng cho việc sử lý các bước tiếp theo
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection GetConnection()
        {
            string strCon = ConfigurationManager.ConnectionStrings["DBString"].ToString();
            return new SqlConnection(strCon);
        }

        /// <summary>
        /// Hàm trả về 1 datatable chứa dữ liệu đc truy xuất bởi câu lệnh sql
        /// </summary>
        /// <param name="sql">1 câu lệnh sql sử dụng để truy vấn trên database</param>
        /// <returns>DataTable</returns>
        protected DataTable GetDataBySQL(string sql)
        {
            
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        /// <summary>
        /// Hàm trả về 1 datatable chứa dữ liệu đc truy xuất bởi câu lệnh sql và parameters của câu lệnh sql
        /// </summary>
        /// <param name="sql">Câu lệnh sql dùng để thực thi truy vấn</param>
        /// <param name="parameter">tham số truyền vào của sql</param>
        /// <returns>Datatable chứa các dữ liệu truy vấn bởi sql</returns>
        protected DataTable GetDataBySQL(string sql, params SqlParameter[] parameter)
        {

            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Parameters.AddRange(parameter);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// Thực thi câu lệnh sql cùng với tham số của nó
        /// </summary>
        /// <param name="sql">Câu lệnh sql</param>
        /// <param name="para">Tham số của câu lệnh sql</param>
        /// <returns>Số bản ghi bị tác động</returns>
        protected int ExecuteSQL(string sql, params SqlParameter[] para)
        {

            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Parameters.AddRange(para);
            cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        /// <summary>
        /// Trả về số bản ghi tồn tại thoải mãn câu lệnh sql và tham số đầu vào
        /// </summary>
        /// <param name="sql">Câu lệnh sql</param>
        /// <param name="pram">tham số đầu vào</param>
        /// <returns></returns>
        protected int GetAmountRecord(string sql, params SqlParameter[] pram)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Parameters.AddRange(pram);
            cmd.Connection.Open();
            int result = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            return result;
        }

        /// <summary>
        /// Compute a md5 hash string from a string
        /// </summary>
        /// <param name="input">text want to convert</param>
        /// <returns>Result of hashing</returns>
        protected string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public int ExecuteSQL(string sql)
        {

            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
    }
}