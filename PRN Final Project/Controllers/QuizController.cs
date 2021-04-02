using PRN_Final_Project.DAO.Impl;
using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRN_Final_Project.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult Course()
        {
            ViewBag.Result = new List<Quiz>();


                
            string username = Request.Cookies["user"].Value;

            ViewBag.Result = new QuizDAOImpl().GetQuizByUser(username);


            return View();

        }
      

        public ActionResult Search()
        {
            ViewBag.Result = new List<Quiz>();
            if (!String.IsNullOrEmpty(Request["keyword"]))
            {
                ViewBag.Result = new QuizDAOImpl().Search(Request["keyword"]);
            }
            return View();
        }

    }
}