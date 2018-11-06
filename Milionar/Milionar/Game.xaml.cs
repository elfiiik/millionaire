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
        private int num = 30;
        private Frame parentFrame;
        private List<Answers> RandomQA;
        public List<object> LoadedData;
        public bool help1 = true;
        public bool help2 = true;
        public bool help3 = true;
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

        public Game(List<object> ldata) : this()
        {
            LoadedData = ldata;
            score = Convert.ToInt32(ldata[0]);
            help1 = Convert.ToBoolean(ldata[2]);
            help2 = Convert.ToBoolean(ldata[3]);
            help3 = Convert.ToBoolean(ldata[4]);
            Loaded += new RoutedEventHandler(Game_Loaded);
        }
        void Game_Loaded(object sender, RoutedEventArgs e)
        {
        }


        void Tick()
        {
            num--;
            Counter.Content = num.ToString();
            if (num == 0)
            {
                //parentFrame.Navigate(new Endgame());   
                this.NavigationService.Navigate(new Endgame(score));
            }
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            //parentFrame.Navigate(new Menu());
            List<bool> Helps = new List<bool> {help1, help2, help3 };
            this.NavigationService.Navigate(new Menu(score,ChooseQA.Answered, help1, help2, help3));
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
                    Answer1.IsEnabled = true;
                    Answer2.IsEnabled = true;
                    Answer3.IsEnabled = true;
                    Answer4.IsEnabled = true;
                    if (score >= 15)
                    {
                        num = 100000000;
                        this.NavigationService.Navigate(new Wingame(score));
                    }
                }
                else
                {
                    //parentFrame.Navigate(new Endgame());
                    num = 100000000;
                    this.NavigationService.Navigate(new Endgame(score));
                }
            }

        }

        private void Change_QA()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            List<Answers> QA = JsonConvert.DeserializeObject<List<Answers>>(File.ReadAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\data.json"), settings);
            //List<Answers> QA = JsonConvert.DeserializeObject<List<Answers>>(File.ReadAllText(@"C:\Users\1\source\repos\millionaire\Milionar\data.json"), settings);
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

        private void Help50(object sender, RoutedEventArgs e)
        {
            if (help1)
            {
                int good = RandomQA[0].Good;
                Random rnd = new Random();
                int Random = rnd.Next(0, 4);
                int Random1 = rnd.Next(0, 4);
                while (good == Random)
                {
                    Random = rnd.Next(0, 4);
                }
                while (good == Random1 || Random == Random1)
                {
                    Random1 = rnd.Next(0, 4);
                }
                Help1.IsEnabled = false;
                help1 = false;

                switch (Random)
                {
                    case 0:
                        Answer1.IsEnabled = false;
                        break;
                    case 1:
                        Answer2.IsEnabled = false;
                        break;
                    case 2:
                        Answer3.IsEnabled = false;
                        break;
                    case 3:
                        Answer4.IsEnabled = false;
                        break;
                }
                switch (Random1)
                {
                    case 0:
                        Answer1.IsEnabled = false;
                        break;
                    case 1:
                        Answer2.IsEnabled = false;
                        break;
                    case 2:
                        Answer3.IsEnabled = false;
                        break;
                    case 3:
                        Answer4.IsEnabled = false;
                        break;
                }
            }
            else
            {
                Help1.IsEnabled = false;
            }
            
        }
    }
}
