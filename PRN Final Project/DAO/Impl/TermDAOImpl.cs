using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.DAO.Impl
{
    public class TermDAOImpl : Database, TermDAO
    {
        public int AddTerms(int quizId, List<Term> terms)
        {
            int result = 0;
            
            for (int i = 0; i < terms.Count; i++)
            {
                result += AddTerm(quizId,terms[i]);              
            }
            return result;
        }

        public int AddTerm(int quizId, Term terms)
        {
            string sql = "INSERT INTO [dbo].[QuizDetail]" +
            " VALUES" +
           " (@quizid" +
           " ,@key" +
           " ,@value)";
            SqlParameter[] param = new SqlParameter[3];
            param = new SqlParameter[] {
                new SqlParameter("@quizid",SqlDbType.Int),
                new SqlParameter("@key",SqlDbType.NVarChar),
                new SqlParameter("@value",SqlDbType.NVarChar)
                };
            param[0].Value = quizId;
            param[1].Value = terms.Key;
            param[2].Value = terms.Definition;
            return ExecuteSQL(sql, param);

        }

        public bool DeleteTerm(int termID)
        {
            string sql = "DELETE FROM [dbo].[QuizDetail]" +
            " WHERE termId = @termId";
            SqlParameter parameter = new SqlParameter("termId", SqlDbType.Int);
            parameter.Value = termID;
            return ExecuteSQL(sql, parameter) > 0;
        }

        public List<Term> GetLearningTerms(int id)
        {
            throw new NotImplementedException();
        }

        public List<Term> GetTermsByQuizID(int id)
        {
            List<Term> terms = new List<Term>();

            string sql = "select * from QuizDetail where quizId = @id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;


            DataTable data = GetDataBySQL(sql, parameter);

            foreach (DataRow row in data.Rows)
            {
                terms.Add(new Term()
                {
                    TermID = int.Parse(row["TermId"].ToString()),
                    Key = row["Key"].ToString(),
                    Definition = row["value"].ToString()
                });
            }

            return terms;
        }

        public bool UpdateTerm(int termId, string key, string value)
        {
            string sql = "UPDATE [dbo].[QuizDetail]" +
        " SET" +
        " [key] = @key" +
        " ,[value] = @value" +
        " WHERE termId = @termId ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@key", SqlDbType.NVarChar),
                new SqlParameter("@value", SqlDbType.NVarChar),
                new SqlParameter("@termId", SqlDbType.Int)
            };
            parameters[0].Value = key;
            parameters[1].Value = value;
            parameters[2].Value = termId;
            return ExecuteSQL(sql, parameters) > 0;
        }
    }
}