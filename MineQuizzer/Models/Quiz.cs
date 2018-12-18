using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MineQuizzer.Models
{
    public class Quiz
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Course { get; set; }
        public int NumberOfQuestions { get; set; }
        public int Rating { get; set; }
        public string Progress { get; set; }
    }
    public class QuizDBContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
    }
}
