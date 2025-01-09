using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Quiz.ViewModels
{
    internal class QuizViewModel : BindableObject
    {

        //public Command CheckAnswerCommand => new Command(CheckAnswer);
        public Command NextQuestionCommand => new Command(NextQuestion);
        public Command PreviousQuestionCommand => new Command(PreviousQuestion);

        private int currentQuestionIndex;

        public int CurrentQuestionIndex
        {
            get { return currentQuestionIndex; }
            set { currentQuestionIndex = value; OnPropertyChanged(); }
        }

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
        private string currQues;

        public string CurrQues
        {
            get { return currQues; }
            set { currQues = value; OnPropertyChanged(); }
        }


        private string currAns1;

        public string CurrAns1
        {
            get { return currAns1; }
            set { currAns1 = value; OnPropertyChanged(); }
        }

        private string currAns2;
        public string CurrAns2
        {
            get { return currAns2; }
            set { currAns2 = value; OnPropertyChanged(); }
        }

        private string currAns3;
        public string CurrAns3
        {
            get { return currAns3; }
            set { currAns3 = value; OnPropertyChanged(); }
        }

        private string currAns4;
        public string CurrAns4
        {
            get { return currAns4; }
            set { currAns4 = value; OnPropertyChanged(); }
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


            DisplayAnswers();
        }

        void DisplayAnswers()
        {
            CurrQues = Questions[CurrentQuestionIndex].Text;

            CurrAns1 = Questions[CurrentQuestionIndex].Answers[0];
            CurrAns2 = Questions[CurrentQuestionIndex].Answers[1];
            CurrAns3 = Questions[CurrentQuestionIndex].Answers[2];
            CurrAns4 = Questions[CurrentQuestionIndex].Answers[3];

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
            CurrentQuestionIndex++;
            DisplayAnswers();
        }

        public void PreviousQuestion()
        {
            CurrentQuestionIndex--;
            DisplayAnswers();
        }

    }
}
