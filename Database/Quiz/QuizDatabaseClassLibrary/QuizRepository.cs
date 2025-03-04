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

        
    }
}
