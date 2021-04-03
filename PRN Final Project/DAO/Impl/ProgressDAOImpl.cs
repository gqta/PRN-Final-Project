using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.DAO.Impl
{
    public class ProgressDAOImpl : Database, ProgressDAO
    {
        public int GetLearnProgress(string username, int quizID)
        {
            string sql = "select progressld, quizId, progress from Progress where quizId = @id and username = @user";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user", SqlDbType.VarChar),
                new SqlParameter("@id", SqlDbType.Int)
            };

            parameters[0].Value = username;
            parameters[1].Value = quizID;

            DataTable table = GetDataBySQL(sql, parameters);

            if (table.Rows.Count == 0)
                return StartLearnProgress(username, quizID);

            else
            {

                return Convert.ToInt32(table.Rows[0]["progressld"]);

            }

        }

        public Dictionary<string, int> GetLearnProgress( int progressID)
        {
            string sql = "select progressld, quizId, progress from Progress where progressld = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int)
            };

            parameters[0].Value = progressID;

            DataTable table = GetDataBySQL(sql, parameters);

            if (table.Rows.Count == 0) return new Dictionary<string, int>();

            else
            {
                Dictionary<string, int> keys = new Dictionary<string, int>();

                keys["progressld"] = Convert.ToInt32(table.Rows[0]["progressld"]);
                keys["quizId"] = Convert.ToInt32(table.Rows[0]["quizID"]);
                keys["progress"] = Convert.ToInt32(table.Rows[0]["progress"]);

                return keys;
            }

        }

        public Dictionary<string, int> ResetProgress(int progressID)
        {
            return SetProgress(progressID, 0);
        }

        public Dictionary<string, int> SetProgress(int progressID, int progress)
        {
            string sql = "update Progress set progress = @pro where progressld = @id";


            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pro", SqlDbType.Int),
                new SqlParameter("@id", SqlDbType.Int)
            };

            parameters[0].Value = progress;
            parameters[1].Value = progressID ;

            ExecuteSQL(sql, parameters);

            return GetLearnProgress(progressID);
        }

        public int StartLearnProgress(string username, int quizID)
        {
            string sql = "insert into Progress(username, quizId)values(@name, @id)";


            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", SqlDbType.VarChar),
                new SqlParameter("@id", SqlDbType.Int)
            };

            parameters[0].Value = username;
            parameters[1].Value = quizID;

            if(ExecuteSQL(sql, parameters) > 0)
            {
                return GetLearnProgress(username, quizID);
            }
            return -1;
        }




    }
}