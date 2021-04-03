using PRN_Final_Project.DAO;
using PRN_Final_Project.DAO.Impl;
using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRN_Final_Project.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string key)
        {
            string username = Request["username"];
            string password = Request["password"];
            UserDAO userDao = new UserDAOImpl();
          

            if (userDao.Login(username, password))
            { 
                if( userDao.isActive(username))
                {
Response.Cookies.Add(new HttpCookie("user", username));
                }

                else
                {
                    return Redirect("/activation");
                }
                
                return Redirect("/");
            }
            else
            {
                ViewBag.ErrorMessage = "User or password is not correct!";
                return View();
            }

        }


        [HttpGet]
        public ActionResult Logout()
        {

            if (Response.Cookies.Get("user").Value != null)
            {
                Response.Cookies.Remove("user");
            }
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(params string[] prs)
        {
            string username = Request["username"];
            string password = Request["password"];
            string email = Request["email"];
            string fullname = Request["fullname"];
          
            if (Response.Cookies.Get("user").Value != null)
            {
                return Redirect("/");
            }
            else
            {
                try
                {
                    UserDAO userDao = new UserDAOImpl();
                    string codeActive = userDao.getRandomPass();
                    if (userDao.Register(username, password, email, fullname,codeActive))
                    {

                        //Response.Cookies.Add(new HttpCookie("user", username));

                        string host = Request.Url.Host +":"+Request.Url.Port;
                        

                        MailHelper mail = new MailHelper();
                        mail.SendMail(email, "Xác nhận tài khoản", "Bấm vào link để xác nhận tài khoản: " + "https://"+ host+"/activation?user="+username+"&code="+codeActive);
                        return Redirect("/activation");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Username or email is existed"+ex.Message;
                    return View();
                }
            }


        }

        public ActionResult ForgotPassword()
        {

            
            return View();

        }
        [HttpPost]
        public ActionResult ForgotPassword(string username, string email)
        {


            UserDAO userDao = new UserDAOImpl();

            if (userDao.ForgotPassword(username,email) != null)
            {
                Session["usernamee"] = username;
             
                string newpass = userDao.ForgotPassword(username, email);
                MailHelper mail = new MailHelper();
                mail.SendMail(email, "Mật khẩu OneDu của bạn đã được đổi", "Mật khẩu mới của bạn là: " + newpass);

                return Redirect("ChangePassword");

            }
            return View();

        }
        
       
        [HttpGet]
        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePass(params string[] prs)
        {
            string username = "";
            if (Request.Cookies["user"] == null) { username = Session["usernamee"].ToString(); }
            else
            {
                username = Request.Cookies["user"].Value.ToString();
            }




            string oldpassword = Request["oldpassword"];
            string newpassword = Request["newpassword"];
          

            UserDAO user = new UserDAOImpl();

            bool rs = user.ChangePassword(username, oldpassword, newpassword);
            if (rs)
            {
                return Redirect("/");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult ActivationMail()
        {
            UserDAO user = new UserDAOImpl();
            string username = Request["user"]==null?"": Request["user"];
            string code = Request["code"]==null?"": Request["code"];
            
            if(user.setActive(username, code)) {
                Response.Cookies.Add(new HttpCookie("user", username));
                return Redirect("/");

            }

            ViewData["active"] = string.IsNullOrEmpty(username)?null:"Bạn chưa Active thành công!" ;
            return View();

        }
        

    }
}