
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace GPT
{
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private int score;

        public Form1()
        {
            InitializeComponent();
            InitializeQuiz();
            this.BackgroundImage = Image.FromFile("C:\\Users\\User\\Desktop\\foto.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void InitializeQuiz()
        {
            
            questions = new List<Question>
            {
                new Question("�� � ������ �� �������� Intel �� AMD?", new List<string>{"���� �� ������ ���������", "� ������ � ����������", "Intel �� �����, AMD �� ������", "AMD �� ����������� ������"}, new List<int>{2}),
                new Question("�������������� ��� ��?", new List<string>{"Android", "Windows", "Apple", "Linux"}, new List<int>{4}),
                new Question("��� �������� ������� ������ ���� Ethernet �����?", new List<string>{ "72 �����", "123 �����", "58 �����", "96 �����"}, new List<int>{1}),
                new Question("���� ��� ����� ����?", new List<string>{ "WI-FI", "NET,HTML", "VPN,LAN,MAN", "PAN,LAN,WAN,MAN"}, new List<int>{4}),
                new Question("������ ���� �������� �� ������ ��������?", new List<string>{ "11", "12", "10", "12 + 3 ��������"}, new List<int>{4}),
                
            };

            currentQuestionIndex = 0;
            score = 0;

            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
               
                labelQuestion.Text = questions[currentQuestionIndex].Text;
                radioButton1.Text = questions[currentQuestionIndex].Answers[0];
                radioButton2.Text = questions[currentQuestionIndex].Answers[1];
                radioButton3.Text = questions[currentQuestionIndex].Answers[2];
                radioButton4.Text = questions[currentQuestionIndex].Answers[3];
            }
            else
            {
                // ³������� ���������
                MessageBox.Show($"��� �������: {score} � {questions.Count} ���������� ��������");
            }
        }

        

        private bool CheckAnswer(List<int> selectedAnswers)
        {
          
            List<int> correctAnswers = questions[currentQuestionIndex].CorrectAnswers;

            return (selectedAnswers.Count == correctAnswers.Count) && selectedAnswers.All(correctAnswers.Contains);
        }

        private void buttonNext_Click_1(object sender, EventArgs e)
        {
          
            List<int> selectedAnswers = new List<int>();
            if (radioButton1.Checked) selectedAnswers.Add(1);
            if (radioButton2.Checked) selectedAnswers.Add(2);
            if (radioButton3.Checked) selectedAnswers.Add(3);
            if (radioButton4.Checked) selectedAnswers.Add(4);

            if (CheckAnswer(selectedAnswers))
            {
                score++;
            }

            // ������� �� ���������� �������
            currentQuestionIndex++;
            DisplayQuestion();
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public List<int> CorrectAnswers { get; set; }

        public Question(string text, List<string> answers, List<int> correctAnswers)
        {
            Text = text;
            Answers = answers;
            CorrectAnswers = correctAnswers;
        }
    }
}
