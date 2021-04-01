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
        public bool AddTerms(int quizId, List<Term> terms)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTerm(int termID)
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
            throw new NotImplementedException();
        }
    }
}