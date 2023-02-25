using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionStr { get; set; }
        public Guid CourseID { get; set; }

        public int Type { get; set; }
        public List<SetAnswer> Answers { get; set; }
        public int QuestionResult { get; set; }
    }

    public class SetAnswer
    {
        public string Question { get; set; }
        public int Answer { get; set; }
    }

    public class ResultTest
    {
        public int QuestionID { get; set; }
        public bool CorrectAnswer { get; set; }
    }
}
