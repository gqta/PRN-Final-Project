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
        List<Term> GetTermsByQuizID(int id);

        bool UpdateTerm(int termId, string key, string value);

        bool DeleteTerm(int termID);

        bool AddTerms(int quizId, List<Term> terms);

    }
}
