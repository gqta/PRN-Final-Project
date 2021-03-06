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
                    TermAmount = row["amount"] == null ? 0 : int.Parse(row["amount"].ToString()),
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

            string sql = "INSERT INTO [dbo].[Quiz]([username],[quizName],[quizDescription],[access]) values" +
           "(@userName" +
           ", @quizName" +
           ", @quizDes" +
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
            DataTable data = GetDataBySQL(sql, parameter);
            return int.Parse(data.Rows[0]["quizId"].ToString());

        }


        public bool CanAccess(string username, int quiz)
        {
            username = username == null ? "" : username;
            string sql = "select username, access from Quiz where quizId = @id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = quiz;

            DataTable data = GetDataBySQL(sql, parameter);

            if (data.Rows.Count == 0) return false;

            else
            {
                int access = Convert.ToInt32(data.Rows[0]["access"].ToString());

                string user = data.Rows[0]["username"].ToString();

                return access > 0 || user.ToLower().Equals(username.ToLower());
            }
        }

        public bool CanEdit(string username, int quiz)
        {
            string sql = "select username, access from Quiz where quizId = @id and username = @name";
            SqlParameter[] parameter = new SqlParameter[] {
                 new SqlParameter("@id", SqlDbType.Int),
                 new SqlParameter("@name", SqlDbType.VarChar)
            };

            DataTable data = GetDataBySQL(sql, parameter);

            if (data.Rows.Count == 0) return false;

            else return true;
        }

        public List<Quiz> LearnHistory(string username)
        {
            string sql = " with Amount as (select count(*) as amount, quizId from QuizDetail group by quizId) " +
                "select[User].fullName, quiz.* , amount " +
                "from[User] join Progress on[User].username = progress.username " +
                "join Quiz on Progress.quizId = Quiz.quizId " +
                "left join Amount on Quiz.quizId = Amount.quizId " +
                "where Progress.username = @user order by lastLearn desc";
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
    }
}