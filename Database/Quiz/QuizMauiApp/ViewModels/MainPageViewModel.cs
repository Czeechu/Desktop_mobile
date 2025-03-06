using QuizDatabaseClassLibrary;
using QuizDatabaseClassLibrary.Models;
using QuizMauiApp.Extensions;
using QuizMauiApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private QuizRepository quizRepository = new QuizRepository();

        private ObservableCollection<AnswerOption> answerOptions;

        public ObservableCollection<AnswerOption> AnswerOptions
        {
            get { return answerOptions; }
            set { answerOptions = value; }
        }


        private ObservableCollection<TestQuestion> testQuestions;

        public ObservableCollection<TestQuestion> TestQuestions
        {
            get { return testQuestions; }
            set { testQuestions = value; OnPropertyChanged(); }

        }

        private TestQuestion currentQuestion;
        public TestQuestion CurrentQuestion
        {
            get { return currentQuestion; }
            set { currentQuestion = value; OnPropertyChanged(); }
        }

        private Command prevQuestionCommand;
        public Command PrevQuestionCommand
        {
            get
            {
                if (prevQuestionCommand == null)
                    prevQuestionCommand = new Command(() =>
                    {
                        CurrentQuestion = TestQuestions.GetPrevious(currentQuestion);
                    });
                return prevQuestionCommand;
            }
        }

        private Command nextQuestionCommand;
        public Command NextQuestionCommand
        {
            get
            {
                if (nextQuestionCommand == null)
                    nextQuestionCommand = new Command(() =>
                    {
                        CurrentQuestion = TestQuestions.GetNext(currentQuestion);
                    });
                return nextQuestionCommand;
            }
        }

        private string testResultMessage;

        public string TestResultMessage
        {
            get { return testResultMessage; }
            set { testResultMessage = value; OnPropertyChanged(); }
        }

        private Command checkQuestionsCommand;
        public Command CheckQuestionsCommand
        {
            get
            {
                if (checkQuestionsCommand == null)
                    checkQuestionsCommand = new Command(() =>
                    {
                        int countOfcorrect = TestQuestions
                        .Where(tq => tq.AnswerOptions
                                       .Where(ao => ao.IsCorrect)
                                       .All(ao => ao.IsSelected)
                                     && !tq.AnswerOptions
                                          .Where(ao => !ao.IsCorrect)
                                          .Any(ao => ao.IsSelected)
                        ).Count();
                        TestResultMessage = $"Wynik to {countOfcorrect}/{TestQuestions.Count()}";
                    });
                return checkQuestionsCommand;
            }
        }

        public MainPageViewModel()
        {
            QuizRepository quizRepository = new QuizRepository();
            LoadQuestions();

        }

        private void LoadQuestions()
        {
            List<Question> questions = quizRepository.LoadQuestions();
            AnswerOptions = new ObservableCollection<AnswerOption>();
            TestQuestions = new ObservableCollection<TestQuestion>();

            if (questions != null)
            {
                foreach (Question question in questions)
                {
                    List<Answer> dbAnswers = quizRepository.LoadAnswers(question.Id);
                    foreach (Answer dbAnswer in dbAnswers)
                    {
                        AnswerOptions.Add(new AnswerOption()
                        {
                            OptionText = dbAnswer.Content,
                            IsCorrect = dbAnswer.IsCorrect,
                            IsSelected = false
                        });
                    }
                    TestQuestions.Add(new TestQuestion()
                    {
                        QuestionText = question.Content,
                        AnswerOptions = AnswerOptions
                    });
                    AnswerOptions = [];
                }
            }
            
            CurrentQuestion = TestQuestions.FirstOrDefault();
            TestResultMessage = "";
        }

        private void LoadAnswers()
        {

        }
    }
}