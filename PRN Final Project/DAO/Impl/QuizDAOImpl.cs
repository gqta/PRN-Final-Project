using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.DAO.Impl
{
    public class QuizDAOImpl : Database, QuizDAO
    {
        public List<Quiz> Search(string keyword)
        {
            string sql = "with Amount as(select count(*) as amount, quizId from QuizDetail group by quizId)" +
                " select[User].fullName, quiz.* , amount" +
                " from Quiz join[User] on Quiz.username = [User].username" +
                " join Amount on Quiz.quizId = Amount.quizId " +
                " where quizName like @key or quizDescription like @key and access=2 order by createdDate desc";
            SqlParameter parameter = new SqlParameter("@key", SqlDbType.NVarChar);
            parameter.Value = "%" + keyword + "%";
            List<Quiz> lst = new List<Quiz>();

            DataTable data = GetDataBySQL(sql, parameter);

            foreach(DataRow row in data.Rows)
            {
                lst.Add(new Quiz()
                {
                    Creator = row["fullName"].ToString(),
                    QuizId = int.Parse( row["QuizId"].ToString()),
                    QuizName = row["QuizName"].ToString(),
                    QuizDescription = row["QuizDescription"].ToString(),
                    CreatedDate = DateTime.Parse(row["CreatedDate"].ToString()),
                    TermAmount = int.Parse(row["amount"].ToString()),
                });
            }


            return lst;
        }

        public List<Quiz> GetQuizByUser(string username)
        {
            string sql = "with Amount as(select count(*) as amount, quizId from QuizDetail group by quizId)" +
                " select[User].fullName, quiz.* , amount " +
                "from Quiz join[User] on Quiz.username = [User].username " +
                "join Amount on Quiz.quizId = Amount.quizId " +
                "where Quiz.username = @user order by createdDate desc";
            SqlParameter parameter = new SqlParameter("@user", SqlDbType.NVarChar);
            parameter.Value = username;
            List<Quiz> lst = new List<Quiz>();

            DataTable data = GetDataBySQL(sql, parameter);

            foreach (DataRow row in data.Rows)
            {
                lst.Add(new Quiz()
                {
                    Creator = row["fullName"].ToString(),
                    QuizId = int.Parse(row["QuizId"].ToString()),
                    QuizName = row["QuizName"].ToString(),
                    QuizDescription = row["QuizDescription"].ToString(),
                    CreatedDate = DateTime.Parse(row["CreatedDate"].ToString()),
                    TermAmount = int.Parse(row["amount"].ToString()),
                });
            }


            return lst;
        }

        public bool DeleteQuiz(int quizID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuiz(int quizId, int quizName, int quizDes, int access)
        {
            throw new NotImplementedException();
        }

        public bool AddQuiz(int username, int quizName, int quizDes, int access)
        {
            throw new NotImplementedException();
        }
    }
}