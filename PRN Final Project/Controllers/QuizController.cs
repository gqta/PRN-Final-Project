using PRN_Final_Project.DAO.Impl;
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

        public ActionResult Search()
        {

            if (!String.IsNullOrEmpty(Request["keyword"]))
            {
                ViewBag.Result = new QuizDAOImpl().Search(Request["keyword"]);
                //return Json(new QuizDAOImpl().Search(Request["keyword"]), JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}