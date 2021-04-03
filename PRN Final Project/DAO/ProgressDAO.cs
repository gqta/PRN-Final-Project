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
        Dictionary<string, int> ResetProgress(int progressID);

        /// <summary>
        /// Set Term Progress and return current progress 
        /// </summary>
        /// <param name="progressID"></param>
        /// <param name="termID"></param>
        /// <param name="progress"></param>
        /// <returns>< -frequency rank-> and progress [{"good": 2}, {"default": 1}]</returns>
        Dictionary<string, int> SetProgress(int progressID, int progress);

        /// <summary>
        /// Get current learn progress
        /// </summary>
        /// <param name="username"></param>
        /// <param name="quizID"></param>
        /// <returns>include < -frequency rank-> and progress </frequency></returns>
        int GetLearnProgress(string username, int quizID);
        int StartLearnProgress(string username, int quizID);



        Dictionary<string, int> GetLearnProgress(int progressID);

    }
}
