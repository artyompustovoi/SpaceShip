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
using System.Windows.Shapes;
using static SpaceShip.MainWindow;

namespace SpaceShip
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Settings.png"));
            cnv3.Background = bg;
            Style1.Background = Brushes.Brown;
        }

        private void Style1_Click(object sender, RoutedEventArgs e)
        {
            ConfigClass.Style = true;
            Style1.Background = Brushes.Brown;
            style2.Background = Brushes.Purple;
        }

        private void style2_Click(object sender, RoutedEventArgs e)
        {
            ConfigClass.Style = false;
            style2.Background = Brushes.Brown;
            Style1.Background = Brushes.Purple;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
