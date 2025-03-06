using Microsoft.EntityFrameworkCore;
using QuizDatabaseClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDatabaseClassLibrary
{
    public class QuizRepository
    {
        private QuizDBContext dBContext;

        public QuizRepository()
        {
            dBContext = new QuizDBContext();
        }

        public List<Question> LoadQuestions()
        {
            return dBContext.Questions
            .AsNoTracking()
            .Where(q => q.Answers.Any(a => a.IsCorrect))
            .OrderBy(q => q.Content)
            .ThenByDescending(q => q.Answers.Count(a => a.IsCorrect))
            .ToList();

        }

        //SELECT * FROM `answers`;
        public List<Answer> LoadAnswers(int id)
        {
            return dBContext.Answers
                .Where(a => a.QuestionId == id).ToList();
                
        }
    }

}