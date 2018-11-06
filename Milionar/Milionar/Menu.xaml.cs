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
    /// Interakční logika pro Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public int score = 0;
        public List<int> Answered = new List<int>();
        public List<bool> HelpStat = new List<bool>();
        public bool Hel1;
        public bool Hel2;
        public bool Hel3;
        private Frame parentFrame;
        public Menu()
        {
            InitializeComponent();
            Save_button.IsEnabled = false;
        }
        public Menu(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }

        public Menu(int val, List<int> vals, bool h1, bool h2, bool h3) : this()
        {
            score = val;
            Answered = vals;
            Hel1 = h1;
            Hel2 = h2;
            Hel3 = h3;
            Loaded += new RoutedEventHandler(Menu_Loaded);
        }

        private void Game_start(object sender, RoutedEventArgs e)
        {
            //parentFrame.Navigate(new Game());
            this.NavigationService.Navigate(new Game());
        }

        private void create(object sender, RoutedEventArgs e)
        {

        }

        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string str = (string)e.ExtraData; 
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (score>0)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                List<object> SaveData = new List<object> { (Int32)score,Answered, Hel1, Hel2, Hel3};
                string json = JsonConvert.SerializeObject(SaveData, settings);
                File.WriteAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\save.json", json);
                //File.WriteAllText(@"C:\Users\1\source\repos\millionaire\Milionar\save.json", json);
                RightText.Content = "saved";
            }
            
        }
        void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            RightText.Content = score;
            if (score > 0)
            { Save_button.IsEnabled = true; }
            else { Save_button.IsEnabled = false; }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            List<object> LoadedData = JsonConvert.DeserializeObject<List<object>>(File.ReadAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\save.json"), settings);
            //List<object> LoadedData = JsonConvert.DeserializeObject<List<object>>(File.ReadAllText(@"C:\Users\1\source\repos\millionaire\Milionar\save.json"), settings);
            //List obsahuje Score a Answered, zajistit přepsání listu v AnswerChoose a score v Game
            this.NavigationService.Navigate(new Game(LoadedData));
        }
    }
}
