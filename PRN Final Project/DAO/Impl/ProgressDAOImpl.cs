using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.DAO.Impl
{
    public class ProgressDAOImpl : Database, ProgressDAO
    {
        public Dictionary<string, int> GetLearnProgress(string username, int quizID)
        {
            throw new NotImplementedException();
        }

        public bool ResetProgress(int progressID)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> SetTermProgress(int progressID, int termID, int progress)
        {
            throw new NotImplementedException();
        }
    }
}