using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.DAO.Impl
{
    public class UserDAOImpl : Database, UserDAO
    {
       
        public bool ChangePassword(string username,string oldpass, string password)
        {

            string sql = "UPDATE [dbo].[User] SET[password] = @pass WHERE[username] = @user and [password] = @oldpass";

            string md5Password = CreateMD5(username.ToLower() + "_" + password);
            string md5Oldpass = CreateMD5(username.ToLower() + "_" + oldpass);

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@user", SqlDbType.VarChar),
                new SqlParameter("@oldpass", SqlDbType.VarChar),
                new SqlParameter("@pass", SqlDbType.VarChar),
            };

            parameter[0].Value = username;

            parameter[1].Value = md5Oldpass;
            parameter[2].Value = md5Password;

            return ExecuteSQL(sql, parameter) > 0;
        }

        public string ForgotPassword(string username, string email)
        {

            string sql = "select * from [User] where username = @user and email = @email";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@user", SqlDbType.VarChar),
                new SqlParameter("@email", SqlDbType.VarChar),
            };

            parameter[0].Value = username;
            parameter[1].Value = email;

            string randomPass = getRandomPass();

            if(GetDataBySQL(sql, parameter).Rows.Count > 0 && ChangePassword(username, randomPass))
            {
                 return randomPass;
            
            }
            else
            {
                return null;
            }
            
        }

        private string getRandomPass()
        {
            string chars = "1234567890qwertyuiopasdfghjklzxcvbnm";
            string rpass = "";

            Random rd = new Random();
            

            for(int i = 0; i < 8; i++)
            {
                rpass += chars[rd.Next(0, chars.Length)];
            }

            return rpass;
        }

        public bool Login(string username, string password)
        {
            string sql = "select * from [User] where username = @user and password = @pass";

            string md5Password = CreateMD5(username.ToLower() + "_" + password);

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@user", SqlDbType.VarChar),
                new SqlParameter("@pass", SqlDbType.VarChar),
            };

            parameter[0].Value = username;
            parameter[1].Value = md5Password;

            return GetDataBySQL(sql, parameter).Rows.Count > 0;
        }

        public bool Register(string username, string password, string email, string fullName)
        {
            string sql = "INSERT INTO [User]([username],[password],[email],[fullName])" +
                " VALUES(@user, @pass, @email, @fullName)";

            string md5Password = CreateMD5(username.ToLower() + "_" + password);

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@user", SqlDbType.VarChar),
                new SqlParameter("@pass", SqlDbType.VarChar),
                new SqlParameter("@email", SqlDbType.VarChar),
                new SqlParameter("@fullName", SqlDbType.NVarChar)
            };

            parameter[0].Value = username;
            parameter[1].Value = md5Password;
            parameter[2].Value = email;
            parameter[3].Value = fullName;

            return ExecuteSQL(sql, parameter) > 0;
        }
    }
}