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
        // GET api/<controller>
        public List<Term> Get(int id)
        {
            return new TermDAOImpl().GetTermsByQuizID(id);
            
        }

    }
}