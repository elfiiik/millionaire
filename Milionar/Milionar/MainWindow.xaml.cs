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
            QA.Add(new Answers
            {
                Question = "Jake je pocasi?",
                Answer = new List<string> {"ano", "slunicko", "pekne nahovno", "prosil bych bez cibule" },
                Good = 3
            });
            QA.Add(new Answers
            {
                Question = "Jak se máš?",
                Answer = new List<string> { "Vážně", "mě", "to", "nezajímá" },
                Good = 0
            });
            string json = JsonConvert.SerializeObject(QA, settings);
            File.WriteAllText(@"C:\Users\1\source\repos\millionaire\Milionar\data.json", json);
            myFrame.Navigate(new Menu(myFrame));
        }
        
    }
}
