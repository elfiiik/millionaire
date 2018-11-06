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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            List<Answers> QA = new List<Answers>();
            List<Highscore> highscores = new List<Highscore>();
            QA.Add(new Answers
            {
                Question = "Jake je pocasi?",
                Answer = new List<string> { "ano", "slunicko", "pekne nahovno", "prosil bych bez cibule" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "Jak se máš?",
                Answer = new List<string> { "Vážně", "mě", "to", "nezajímá" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "wow",
                Answer = new List<string> { "k1", "k2", "k3", "k4" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "jees",
                Answer = new List<string> { "okuj", "jtzj", "toop", "weee" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "wef",
                Answer = new List<string> { "fwe", "wef", "gerge", "gerger" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "gerge",
                Answer = new List<string> { "gerge", "greger", "egg", "eer" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "qweq",
                Answer = new List<string> { "wefw", "fwe", "fwef", "re" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "rreeeeee",
                Answer = new List<string> { "gege", "rrr", "ewwe", "rewwe" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "werwe",
                Answer = new List<string> { "werw", "eere", "rrre", "trtrtr" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "ererge",
                Answer = new List<string> { "qwdq", "qwqwd", "sad", "qwdqwq" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "qwdqwdq",
                Answer = new List<string> { "qwdq", "fwefwef", "gerg", "wqewe" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "wefwe",
                Answer = new List<string> { "wefwe", "gerger", "rth", "hrth" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "wefw",
                Answer = new List<string> { "ewwefwe", "qwdqwe", "wefwe", "egrger" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "gerge",
                Answer = new List<string> { "qweqwe", "qweqw", "wewe", "rewr" },
                Good = 0
            });
            QA.Add(new Answers
            {
                Question = "rewrerw",
                Answer = new List<string> { "werwe", "gerge", "gerg", "werwerwer" },
                Good = 0
            });
            string json = JsonConvert.SerializeObject(QA, settings);
            File.WriteAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\data.json", json);
            //File.WriteAllText(@"C:\Users\1\source\repos\millionaire\Milionar\data.json", json);

            /*highscores.Add(new Highscore
            {
                Position = 1,
                Score = 15,
                Name = "Ching Chong"
            });
            highscores.Add(new Highscore
            {
                Position = 2,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 3,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 4,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 5,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 6,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 7,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 8,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 9,
                Score = 0,
                Name = ""
            });
            highscores.Add(new Highscore
            {
                Position = 10,
                Score = 0,
                Name = ""
            });
            string json2 = JsonConvert.SerializeObject(highscores, settings);
            File.WriteAllText(@"C:\Users\admin\source\repos\millionaire2\Milionar\highscores.json", json2);*/

            myFrame.Navigate(new Menu(myFrame));
        }
        
    }
}
