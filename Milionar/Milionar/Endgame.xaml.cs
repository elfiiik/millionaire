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
        public Endgame()
        {
            InitializeComponent();
        }

        public Endgame(Frame parentFrame) : this()
        {
            this.parentFrame = parentFrame;
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }
    }
}
