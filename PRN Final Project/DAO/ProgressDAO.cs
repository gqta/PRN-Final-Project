using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN_Final_Project.DAO
{
    interface ProgressDAO
    {
        /// <summary>
        /// Reset progress quiz 
        /// reset learn(1) to not lean (0)
        /// and progress to 0
        /// </summary>
        /// <param name="progressID"></param>
        /// <returns></returns>
        bool ResetProgress(int progressID);

        /// <summary>
        /// Set Term Progress and return current progress 
        /// </summary>
        /// <param name="progressID"></param>
        /// <param name="termID"></param>
        /// <param name="progress"></param>
        /// <returns>< -frequency rank-> and progress [{"good": 2}, {"default": 1}]</returns>
        Dictionary<string, int> SetTermProgress(int progressID, int termID, int progress);

        /// <summary>
        /// Get current learn progress
        /// </summary>
        /// <param name="username"></param>
        /// <param name="quizID"></param>
        /// <returns>include < -frequency rank-> and progress </frequency></returns>
        Dictionary<string, int> GetLearnProgress(string username, int quizID);

    }
}
