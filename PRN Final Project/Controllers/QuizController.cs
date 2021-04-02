using PRN_Final_Project.DAO;
using PRN_Final_Project.DAO.Impl;
using PRN_Final_Project.Models;
using System;
using System.Collections;
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
            ViewBag.Result = new List<Quiz>();
            if (!String.IsNullOrEmpty(Request["keyword"]))
            {
                ViewBag.Result = new QuizDAOImpl().Search(Request["keyword"]);
                //return Json(new QuizDAOImpl().Search(Request["keyword"]), JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(params string[] args)
        {
            string username = Request.Cookies["user"].Value;
            string quizName = Request["title"];
            string quizDes = Request["description"];
            int access = int.Parse(Request["quiz-access"]);
            List<Term> lstTerm = new List<Term>();
            List<string> lstKey = Request.Form.GetValues("key").ToList<string>();
            List<string> lstValue = Request.Form.GetValues("value").ToList<string>();
            for(int i = 0;i<lstKey.Count; i++)
            {
                lstTerm.Add(new Term(lstKey[i], lstValue[i]));
            }
            try
            {
                QuizDAO quizDAO = new QuizDAOImpl();
                TermDAO termDAO = new TermDAOImpl();
                int quizId = quizDAO.AddQuiz(username, quizName, quizDes, access);
 
                foreach (Term x in lstTerm)
                {
                    int result = termDAO.AddTerm(quizId, x);
                }
                return Redirect("~/quiz/add");


            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}