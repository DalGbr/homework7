using System.Diagnostics.Metrics;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace hometask7
{
    public partial class Form1 : Form
    {
        ArrayList incorrect = new ArrayList();
        String[] answers = { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A" };
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mistakes = 0;

            const int size = 20;
            String[] AnswersFromFile = new String[size];

            int index = 0;

            StreamReader inputFile;
            inputFile = File.OpenText("answers.txt");

            while (index < AnswersFromFile.Length && !inputFile.EndOfStream)
            {
                AnswersFromFile[index] = inputFile.ReadLine();
                index++;
            }

            inputFile.Close();

            while (counter <= 19)
            {

                if (answers[counter] != AnswersFromFile[counter])
                {
                    incorrect.Add(counter);
                    mistakes++;
                }

                counter++;
            }

            StringBuilder sb = new StringBuilder();
            foreach (int item in incorrect)
            {
                sb.AppendLine(item.ToString().Replace("\n", " ") + " ");
            }

            string stringOfMistakes = sb.ToString();

            int personScore = 20 - mistakes;

            if (personScore >= 15)
            {
                label1.Text = "You have passed the exam!";
            }
            else
            {
                label1.Text = "You failed the exam!";
            }

            label2.Text = "You answered correctly " + (20 - mistakes) + " times. " +
                "You did mistakes in " + mistakes + " questions.";

            label3.Text = stringOfMistakes.ToString();
        }
    }
}