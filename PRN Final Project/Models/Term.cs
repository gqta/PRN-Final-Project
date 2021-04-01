using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.Models
{
    public class Term
    {
        private int termID;
        private string key;
        private string definition;

        public Term()
        {

        }

        public Term( int termID, string key, string definition)
        {

            this.termID = termID;
            this.key = key;
            this.definition = definition;
        }

        public int TermID { get => termID; set => termID = value; }
        public string Key { get => key; set => key = value; }
        public string Definition { get => definition; set => definition = value; }
    }
}