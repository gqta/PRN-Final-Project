using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.Models
{
    public class Quiz
    {
        private string creator;
        private int quizId;
        private string quizName;
        private string quizDescription;
        private DateTime createdDate;
        private int termAmount;

        public Quiz()
        {

        }

        public Quiz(string creator, int quizId, string quizName, string quizDescription, DateTime createdDate, int termAmount)
        {
            this.creator = creator;
            this.quizId = quizId;
            this.quizName = quizName;
            this.quizDescription = quizDescription;
            this.createdDate = createdDate;
            this.termAmount = termAmount;
        }

        public string Creator { get => creator; set => creator = value; }
        public int QuizId { get => quizId; set => quizId = value; }
        public string QuizName { get => quizName; set => quizName = value; }
        public string QuizDescription { get => quizDescription; set => quizDescription = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public int TermAmount { get => termAmount; set => termAmount = value; }
    }
}