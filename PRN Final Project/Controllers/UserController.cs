using PRN_Final_Project.DAO;
using PRN_Final_Project.DAO.Impl;
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
                Response.Cookies.Add(new HttpCookie("user", username));
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

                    if (userDao.Register(username, password, email, fullname))
                    {
                        Response.Cookies.Add(new HttpCookie("user", username));
                        return Redirect("/");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Username or email is existed";
                    return View();
                }
            }


        }
    }
}