
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


        public ActionResult Course()
        {


            string username = Request.Cookies["user"].Value;

            ViewBag.Result = new QuizDAOImpl().GetQuizByUser(username);
            ViewBag.History = new QuizDAOImpl().LearnHistory(username);




            return View();

        }


        public ActionResult DeleteQuiz()
        {
            QuizDAO quizDao = new QuizDAOImpl();
            string user = Request.Cookies["user"] == null ? "" : Request.Cookies["user"].Value;
            try
            {
                if (!String.IsNullOrEmpty(Request["id"]) && quizDao.CanAccess(user, Convert.ToInt32(Request["id"])))
                {
                    ViewBag.user = Request.Cookies["user"];

                    if (quizDao.DeleteQuiz(int.Parse(Request["id"])))
                    {
                        return Redirect("/quiz/course");
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return Redirect("/error/404");
            }
        }
        public ActionResult ViewCourse()
        {
            ViewBag.Result = new List<Term>();
            QuizDAO quizDao = new QuizDAOImpl();
            string user = Request.Cookies["user"] == null ? "" : Request.Cookies["user"].Value;
            try
            {
                if (!String.IsNullOrEmpty(Request["id"]) && quizDao.CanAccess(user, Convert.ToInt32(Request["id"])))
                {
                    ViewBag.Result = new TermDAOImpl().GetTermsByQuizID(int.Parse(Request["id"]));
                    List<Term> lst = ViewBag.Result;
                    Quiz quiz = new QuizDAOImpl().getQuizByQuizId(int.Parse(Request["id"]));
                    ViewBag.quiz = quiz;
                    ViewBag.user = user;
                    return View();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return Redirect("/error/404");
            }


        }
        [HttpGet]
        public ActionResult EditCourse()
        {
            ViewBag.Result = new List<Term>();
            QuizDAO quizDao = new QuizDAOImpl();
            string user = Request.Cookies["user"] == null ? "" : Request.Cookies["user"].Value;
            try
            {
                if (!String.IsNullOrEmpty(Request["id"]) && quizDao.CanAccess(user, Convert.ToInt32(Request["id"])))
                {
                    ViewBag.Result = new TermDAOImpl().GetTermsByQuizID(int.Parse(Request["id"]));
                    List<Term> lst = ViewBag.Result;
                    Quiz quiz = new QuizDAOImpl().getQuizByQuizId(int.Parse(Request["id"]));
                    ViewBag.quiz = quiz;
                    return View();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return Redirect("/error/404");
            }
        }


        [HttpPost]
        public ActionResult EditCourse(params string[] args)
        {
            QuizDAO quizDAO = new QuizDAOImpl();
            TermDAO termDAO = new TermDAOImpl();
            string username = Request.Cookies["user"].Value;
            string quizName = Request["title"];
            string quizDes = Request["description"];
            int access = int.Parse(Request["quiz-access"]);

            quizDAO.UpdateQuiz(int.Parse(Request["id"]), quizName, quizDes, access);
            List<Term> lstTerm = new List<Term>();
            List<string> lstKey = Request.Form.GetValues("key").ToList<string>();
            List<string> lstValue = Request.Form.GetValues("value").ToList<string>();
            for (int i = 0; i < lstKey.Count; i++)
            {
                lstTerm.Add(new Term(lstKey[i], lstValue[i]));
            }
            try
            {

                foreach (Term x in lstTerm)
                {
                    int result = termDAO.AddTerm(int.Parse(Request["id"]), x);
                }

                return Redirect("~/quiz/course");
            }
            catch (Exception ex)
            {
                return View();
            }
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
            for (int i = 0; i < lstKey.Count; i++)
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
                return Redirect("~/quiz/course");


            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Test(int id)
        {
            string username = Request.Cookies["user"] == null ? null : Request.Cookies["user"].Value;

            if (new QuizDAOImpl().CanAccess(username, id))
            {
                if (String.IsNullOrEmpty(username))
                {
                    ViewBag.apiLink = String.Format("/api/quiz/{0}", id);
                }
                else
                {
                    ViewBag.apiLink = String.Format("/api/quiz/{0}/{1}", username, id);
                }

                return View();
            }
            else
            {
                return Redirect("/error/404");
            }


        }

        public ActionResult Learn(int id)
        {
            string username = Request.Cookies["user"] == null ? null : Request.Cookies["user"].Value;

            if (new QuizDAOImpl().CanAccess(username, id))
            {
                ViewBag.ID = id;
                if (String.IsNullOrEmpty(username))
                {
                    ViewBag.apiLink = String.Format("/api/quiz/{0}", id);
                }
                else
                {
                    ViewBag.apiLink = String.Format("/api/quiz/{0}/{1}", username, id);
                    ProgressDAO pro = new ProgressDAOImpl();
                    int progress = pro.GetLearnProgress(username, id);
                    ViewBag.ProgressAPI = "/api/progress/" + progress;
                    ViewBag.ResetProgressAPI = "/api/progress/reset/" + progress;
                    ViewBag.SetProgressAPI = "/api/progress/update/" + progress;
                }
            }
            else
            {
                return Redirect("/error/404");
            }

            return View();
        }


    }


}
