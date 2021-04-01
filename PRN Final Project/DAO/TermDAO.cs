using PRN_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN_Final_Project.DAO
{
    interface TermDAO
    {
        /// <summary>
        /// Get term by id of a quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Term> GetTermsByQuizID(int id);

        /// <summary>
        /// Return terms have id less than 2( term is not familial)
        /// and for term is equal 2 is not need to get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Term> GetLearningTerms(int id);

        /// <summary>
        /// Update term to new key and new value
        /// </summary>
        /// <param name="termId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool UpdateTerm(int termId, string key, string value);

        /// <summary>
        /// Detele term by termID
        /// </summary>
        /// <param name="termID"></param>
        /// <returns></returns>
        bool DeleteTerm(int termID);

        /// <summary>
        /// Add terms to quiz 
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="terms"></param>
        /// <returns></returns>
        bool AddTerms(int quizId, List<Term> terms);

    }
}
