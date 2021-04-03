using PRN_Final_Project.DAO;
using PRN_Final_Project.DAO.Impl;
using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRN_Final_Project.Controllers
{
    public class QuizAPIController : ApiController
    {
        [Route("api/quiz/{id}")]
        public List<Term> Get(int id)
        {
            QuizDAO quizDAO = new QuizDAOImpl();
            if (quizDAO.CanAccess("", id))
            {
                return new TermDAOImpl().GetTermsByQuizID(id);
            }
            else
            {
                return new List<Term>();
            }
        }
        [Route("api/quiz/{name}/{id}")]
        public List<Term> Get(string name, int id)
        {
            QuizDAO quizDAO = new QuizDAOImpl();
            if (quizDAO.CanAccess(name, id))
            {
                return new TermDAOImpl().GetTermsByQuizID(id);
            }
            else
            {
                return new List<Term>();
            }


        }

        [Route("api/progress/{id}")]
        public Dictionary<string, int> GetProgress(int id)
        {
            return new ProgressDAOImpl().GetLearnProgress(id);
        }


        [Route("api/progress/reset{id}")]
        public Dictionary<string, int> ResetProgress(int id)
        {
            return new ProgressDAOImpl().ResetProgress(id);
        }

        [Route("api/progress/update/{id}/{amount}")]
        [HttpGet]
        public Dictionary<string, int> UpdateProgress(int id, int amount)
        {
            return new ProgressDAOImpl().SetProgress(id, amount);
        }
    }
}
