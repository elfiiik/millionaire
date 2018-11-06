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
using Newtonsoft.Json;
namespace Milionar
{
    /// <summary>
    /// Interakční logika pro Wingame.xaml
    /// </summary>
    public partial class Wingame : Page
    {
        private Frame parentFrame;
        private int score;

        public Wingame()
        {
            InitializeComponent();
        }

        public Wingame(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }

        public Wingame(int val) : this()
        {
            score = val;
            Loaded += new RoutedEventHandler(Endgame_Loaded);
        }

        void Endgame_Loaded(object sender, RoutedEventArgs e)
        {
            Textscore.Content = score;
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }

        private void Highscore_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Hall());
        }

        private void Score_submit(object sender, RoutedEventArgs e)
        {
            
            string name = Nametext.Text;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            List<Highscore> highscores = JsonConvert.DeserializeObject<List<Highscore>>(File.ReadAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\highscores.json"), settings);
            highscores.Add(new Highscore
            {
                Name = name,
                Score = score
            });
            highscores = highscores.OrderBy(o => o.Score * -1).ToList();
            string json2 = JsonConvert.SerializeObject(highscores, settings);
            File.WriteAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\highscores.json", json2);
            Namesubmit.IsEnabled = false;
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
