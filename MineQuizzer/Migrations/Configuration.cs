using MineQuizzer.Models;

namespace MineQuizzer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MineQuizzer.Models.QuizDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MineQuizzer.Models.QuizDBContext context)
        {
            context.Quizzes.AddOrUpdate(i => i.Name,
                new Quiz
                {
                    Name = "Ben og knogler",
                    Date = DateTime.Parse("11.7.2018"),
                    Course = "Anatomi",
                    NumberOfQuestions = 182,
                    Rating = 5,
                    Progress = "Gennemført"
                    
                },

                new Quiz
                {
                    Name = "Lunger",
                    Date = DateTime.Parse("18.2.2018"),
                    Course = "Organer",
                    NumberOfQuestions = 12,
                    Rating = 5,
                    Progress = "Du er igang"

                },

                new Quiz
                {
                    Name = "kroniske Sygdomme",
                    Date = DateTime.Parse("21.2.2018"),
                    Course = "Sygdomme",
                    NumberOfQuestions = 92,
                    Rating = 5,
                    Progress = "Ikke gennemført"

                },

                new Quiz
                {
                    Name = "Hjertet",
                    Date = DateTime.Parse("11.3.2018"),
                    Course = "Organer",
                    NumberOfQuestions = 67,
                    Rating = 5,
                    Progress = "Gennemført"

                }
            );
        }
    }
}
