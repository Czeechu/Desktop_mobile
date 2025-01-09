using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Quiz.ViewModels
{
    public class QuizViewModel : BindableObject
    {

        //public Command CheckAnswerCommand => new Command(CheckAnswer);
        public Command NextQuestionCommand => new Command(NextQuestion);
        public Command PreviousQuestionCommand => new Command(PreviousQuestion);

        private int currentQuestionIndex = 0;
        private string feedback;

        private ObservableCollection<Question> questions;
        private ObservableCollection<Question> Questions
        {
            get
            {
                return questions;
            }
            set
            {
                questions = value;
                OnPropertyChanged();
            }
        }


        public QuizViewModel()
        {
            Questions = new ObservableCollection<Question>
            {
                new Question
                {
                    Text = "Czym jest inkrementacja:",
                    Answers = new List<string> { "Zmniejszenie wartości o 1", 
                        "Zwiększenie wartości o n, gdzie n>=2", 
                        "Zwiększenie wartości o 1", 
                        "Wrocław" },
                    CorrectAnswer = "Zwiększenie wartości o 1"
                },
                new Question
                {
                    Text = "Jaką metodę w języku Java używa się do uzyskania długości tablicy?",
                    Answers = new List<string> { "length()", "getLength()", "size()", "length" },
                    CorrectAnswer = "length"
                },
                new Question
                {
                    Text = "Jaki typ danych w języku C# służy do przechowywania liczb zmiennoprzecinkowych o podwójnej precyzji??",
                    Answers = new List<string> { "float", "double", "decimal", "int" },
                    CorrectAnswer = "double"
                },
                new Question
                {
                    Text = "Który z poniższych operatorów w C# służy do porównania dwóch obiektów pod względem równości?",
                    Answers = new List<string> { "==", "!=", "Equals()", "===" },
                    CorrectAnswer = "=="
                }
            };
        }


        public string CurrentQuestionText => questions[currentQuestionIndex].Text;

        public List<string> CurrentAnswers => questions[currentQuestionIndex].Answers;

        public string Feedback
        {
            get 
            { 
                return feedback; 
            }
            set
            {
                feedback = value;
                OnPropertyChanged();
            }
        }

        private string selectedAnswer;
        public string SelectedAnswer
        {
            get 
            { 
                return selectedAnswer; 
            }
            set
            {
                selectedAnswer = value;
                OnPropertyChanged();
            }
        }

        public int TotalQuestions => questions.Count;

        public void CheckAnswer()
        {
            if (SelectedAnswer == questions[currentQuestionIndex].CorrectAnswer)
            {
                Feedback = "Dobrze!";
            }
            else
            {
                Feedback = $"Źle!";
            }
        }

        public void NextQuestion()
        {
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                Feedback = string.Empty;
                SelectedAnswer = null;
                OnPropertyChanged(nameof(CurrentQuestionText));
                OnPropertyChanged(nameof(CurrentAnswers));
            }
        }

        public void PreviousQuestion()
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                Feedback = string.Empty;
                SelectedAnswer = null;
                OnPropertyChanged(nameof(CurrentQuestionText));
                OnPropertyChanged(nameof(CurrentAnswers));
            }
        }

    }
}
