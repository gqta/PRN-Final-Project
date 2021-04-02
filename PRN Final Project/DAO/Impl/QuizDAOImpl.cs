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
                " left join Amount on Quiz.quizId = Amount.quizId " +
                " where quizName like @key or quizDescription like @key and access=2 order by createdDate desc";
            SqlParameter parameter = new SqlParameter("@key", SqlDbType.NVarChar);
            parameter.Value = "%" + keyword + "%";
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
                    TermAmount = row["amount"]==null? 0 : int.Parse(row["amount"].ToString()),
                });
            }
            return lst;
        }

        public List<Quiz> GetQuizByUser(string username)
        {
            string sql = "with Amount as(select count(*) as amount, quizId from QuizDetail group by quizId)" +
                " select[User].fullName, quiz.* , amount " +
                "from Quiz join[User] on Quiz.username = [User].username " +
                "left join Amount on Quiz.quizId = Amount.quizId " +
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
                    TermAmount = row["amount"] == null ? 0 : int.Parse(row["amount"].ToString()),
                });
            }


            return lst;
        }
        public Quiz getQuizByQuizId(int quizId)
        {
            string sql = "select * from quiz where quizId = @quizId";
            SqlParameter parameter = new SqlParameter("@quizId", SqlDbType.Int);
            parameter.Value = quizId;
            Quiz quiz = new Quiz();
            DataTable data = GetDataBySQL(sql, parameter);
            foreach (DataRow row in data.Rows) {
                quiz = new Quiz()
                {
                    Creator = row["username"].ToString(),
                    QuizId = int.Parse(row["QuizId"].ToString()),
                    QuizName = row["QuizName"].ToString(),
                    QuizDescription = row["QuizDescription"].ToString(),
                    CreatedDate = DateTime.Parse(row["CreatedDate"].ToString()),
                   
                };
            }
            return quiz;
                
        }
        public bool DeleteQuiz(int quizID)
        {

            string sql = "DELETE FROM[dbo].[Quiz] WHERE quizId = @quizid ";
            SqlParameter parameter = new SqlParameter("@quizid", SqlDbType.Int);
            parameter.Value = quizID;

            return (ExecuteSQL(sql, parameter) > 0);

        }

        public bool UpdateQuiz(int quizId, string quizName, string quizDes, int access)
        {
            string sql = "delete from quizDetail where quizId = @quizId" +
            " UPDATE[dbo].[Quiz]"+
            " SET"+
            " [quizName] = @quizName" +
            " ,[quizDescription] = @quizDes " +
            " ,[createdDate] = GETDATE()"+
            " ,[access] = @access"+
            " WHERE quizId = @quizId ";
            
            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@quizName",SqlDbType.NVarChar),
                new SqlParameter("@quizDes",SqlDbType.NVarChar),
                new SqlParameter("@access",SqlDbType.Int),
                new SqlParameter("@quizId",SqlDbType.Int)
            };
            parameter[0].Value = quizName;
            parameter[1].Value = quizDes;
            parameter[2].Value = access;
            parameter[3].Value = quizId;
            return (ExecuteSQL(sql, parameter) > 0);

        }

        public int AddQuiz(string username, string quizName, string quizDes, int access)
        {

            string sql = "INSERT INTO [dbo].[Quiz] VALUES "+
           "(@userName"+
           ", @quizName"+
           ", @quizDes"+
           ", GETDATE()"+
           ", @access)";
            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@username",SqlDbType.VarChar),
                new SqlParameter("@quizName",SqlDbType.NVarChar),
                new SqlParameter("@quizDes",SqlDbType.NVarChar),
                new SqlParameter("@access",SqlDbType.Int),
            };
            parameter[0].Value = username;
            parameter[1].Value = quizName;
            parameter[2].Value = quizDes;
            parameter[3].Value = access;
            DataTable data = GetDataBySQL(sql,parameter);
            return int.Parse(data.Rows[0]["quizId"].ToString());

        }
    }
}