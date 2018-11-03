using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft.Json;
namespace Milionar
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public int score = 0;
        private int num = 5;
        private Frame parentFrame;
        private List<Answers> RandomQA;
        AnswerChoose ChooseQA = new AnswerChoose();


        public Game()
        {
            InitializeComponent();

            DispatcherTimer timerEnemy = new DispatcherTimer();
            timerEnemy.Interval = TimeSpan.FromSeconds(1);
            timerEnemy.Tick += (s, args) => Tick();
            timerEnemy.Start();

            Change_QA();
        }
        public Game(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }


        void Tick()
        {
            num--;
            Counter.Content = num.ToString();
            if (num < 0)
            {
                parentFrame.Navigate(new Endgame());
            }
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            //parentFrame.Navigate(new Menu());

            this.NavigationService.Navigate(new Menu(score,ChooseQA.Answered));
        }

        private void Answer_click(object sender, RoutedEventArgs e)
        {
            foreach (Answers data in RandomQA)
            {
                if ((sender as Button).Content.Equals(data.Answer[data.Good]))
                {
                    score++;
                    Score.Content = score;
                    Change_QA();
                    num = 30;
                }
                else
                {
                    parentFrame.Navigate(new Endgame());
                }
            }

        }

        private void Change_QA()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            //List<Answers> QA = JsonConvert.DeserializeObject<List<Answers>>(File.ReadAllText(@"C:\Users\admin\source\repos\millionaire\Milionar\data.json"), settings);
            List<Answers> QA = JsonConvert.DeserializeObject<List<Answers>>(File.ReadAllText(@"C:\Users\1\source\repos\millionaire\Milionar\data.json"), settings);
            if (QA.Count == ChooseQA.Answered.Count)
            {
                Question.Content = "Done";
            }
            else
            {
                RandomQA = ChooseQA.Choose();
                while (RandomQA.Count < 1)
                {
                    RandomQA = ChooseQA.Choose();
                }
                foreach (Answers data1 in RandomQA)
                {
                    Question.Content = data1.Question;
                    Answer1.Content = data1.Answer[0];
                    Answer2.Content = data1.Answer[1];
                    Answer3.Content = data1.Answer[2];
                    Answer4.Content = data1.Answer[3];
                }
            } 
        }




    }
}
