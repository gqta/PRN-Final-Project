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


        bool DeleteQuiz(int quizID);

        /// <summary>
        /// Update information about quiz include name, des and who can access
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="quizName"></param>
        /// <param name="quizDes"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        bool UpdateQuiz(int quizId, int quizName, int quizDes, int access);

        /// <summary>
        /// Add new quiz to database include name, des, access
        /// </summary>
        /// <param name="quizName"></param>
        /// <param name="quizDes"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        bool AddQuiz(int username, int quizName, int quizDes, int access);
    }
}
