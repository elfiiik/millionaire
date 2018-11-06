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
    /// Interakční logika pro Hall.xaml
    /// </summary>
    public partial class Hall : Page
    {
        private Frame parentFrame;
        public Hall()
        {
            InitializeComponent();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            List<Highscore> highscores = JsonConvert.DeserializeObject<List<Highscore>>(File.ReadAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\highscores.json"), settings);
            for (int i=0; i<10; i++)
            {
                switch (i)
                {
                    case 0:
                        Top1.Content = highscores[0].Name;
                        Top1_Score.Content = highscores[0].Score;
                        break;
                    case 1:
                        Top2.Content = highscores[1].Name;
                        Top2_Score.Content = highscores[1].Score;
                        break;
                    case 2:
                        Top3.Content = highscores[2].Name;
                        Top3_Score.Content = highscores[2].Score;
                        break;
                    case 3:
                        Top4.Content = highscores[3].Name;
                        Top4_Score.Content = highscores[3].Score;
                        break;
                    case 4:
                        Top5.Content = highscores[4].Name;
                        Top5_Score.Content = highscores[4].Score;
                        break;
                    case 5:
                        Top6.Content = highscores[5].Name;
                        Top6_Score.Content = highscores[5].Score;
                        break;
                    case 6:
                        Top7.Content = highscores[6].Name;
                        Top7_Score.Content = highscores[6].Score;
                        break;
                    case 7:
                        Top8.Content = highscores[7].Name;
                        Top8_Score.Content = highscores[7].Score;
                        break;
                    case 8:
                        Top9.Content = highscores[8].Name;
                        Top9_Score.Content = highscores[8].Score;
                        break;
                    case 9:
                        Top10.Content = highscores[9].Name;
                        Top10_Score.Content = highscores[9].Score;
                        break;
                }
            }
        }

        public Hall(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }
    }
}
