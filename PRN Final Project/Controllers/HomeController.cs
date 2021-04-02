using PRN_Final_Project.DAO.Impl;
using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRN_Final_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Get()
        {
            return Json(new QuizDAOImpl().Search("VNI"));
        }


    }
}