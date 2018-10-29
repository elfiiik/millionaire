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
        private int score = 0;
        private int num = 30;
        private Frame parentFrame;
        private List<Answers> RandomQA;


        public Game()
        {
            InitializeComponent();
            AnswerChoose ChooseQA = new AnswerChoose();
            DispatcherTimer timerEnemy = new DispatcherTimer();
            timerEnemy.Interval = TimeSpan.FromSeconds(1);
            timerEnemy.Tick += (s, args) => Tick();
            timerEnemy.Start();

            RandomQA = ChooseQA.Choose();
            foreach (Answers data in RandomQA)
            {
                Question.Content = data.Question;
                Answer1.Content = data.Answer[0];
                Answer2.Content = data.Answer[1];
                Answer3.Content = data.Answer[2];
                Answer4.Content = data.Answer[3];
            }
        }
        public Game(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }
   

        void Tick()
        {
            num--;
            Counter.Content = num.ToString();
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            parentFrame.Navigate(new Menu());
        }

        private void Answer_click(object sender, RoutedEventArgs e)
        {
            foreach (Answers data in RandomQA)
            {
                if (this.Content.Equals(data.Answer[data.Good]))
                {
                    score++;
                    Score.Content = score;
                }
            }
            
        }
    }
}
