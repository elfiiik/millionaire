using System;
using System.Collections.Generic;
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

namespace Milionar
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        private Frame parentFrame;
        public Game()
        {
            InitializeComponent();
            DispatcherTimer timerEnemy = new DispatcherTimer();
            timerEnemy.Interval = TimeSpan.FromSeconds(1);
            timerEnemy.Tick += (s, args) => Tick();
            timerEnemy.Start();
        }
        public Game(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }

        int num = 0;

        void Tick()
        {
            num++;
            Counter.Content = num.ToString();
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            parentFrame.Navigate(new Menu());
        }
    }
}
