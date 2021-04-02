using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN_Final_Project.DAO
{
    interface UserDAO
    {
        /// <summary>
        /// Use to insert a new account to database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="fullName"></param>
        /// <returns>Result of Register true => success and false => fail</returns>
        bool Register(string username, string password, string email, string fullName);

        /// <summary>
        /// Use to check password and usename in database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string username, string password);

        /// <summary>
        /// Forgot Password by username and email
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        /// 
    
        string ForgotPassword(string username, string email);

       /// <summary>
       /// Change password
       /// </summary>
       /// <param name="username"></param>
       /// <param name="oldpass"></param>
       /// <param name="password"></param>
       /// <returns></returns>
        bool ChangePassword(string username, string oldpass, string password);
        /// <summary>
        ///Change password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ChangePassword(string username, string password);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool isActive(string username);
        string getRandomPass();
        bool Register(string username, string password, string email, string fullName, string activeCode);
        bool setActive(string username, string code);
    }
}
