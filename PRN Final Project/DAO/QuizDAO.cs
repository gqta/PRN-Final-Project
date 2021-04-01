using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN_Final_Project.DAO
{
    interface QuizDAO
    {
        /// <summary>
        /// Search quiz by keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A list of Quiz</returns>
        List<Quiz> Search(string keyword);

        /// <summary>
        /// Get all quiz by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of quiz</returns>
        List<Quiz> GetQuizByUser(string username);



    }
}
