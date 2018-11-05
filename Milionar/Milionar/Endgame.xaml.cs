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
    /// Interakční logika pro Endgame.xaml
    /// </summary>
    public partial class Endgame : Page
    {
        private Frame parentFrame;
        private int score;
        public Endgame()
        {
            InitializeComponent();
        }

        public Endgame(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }

        public Endgame(int val) : this()
        {
            score = val;
            Loaded += new RoutedEventHandler(Endgame_Loaded);
        }

        void Endgame_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }
    }
}
