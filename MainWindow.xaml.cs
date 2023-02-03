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

namespace SpaceShip
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Menu.png"));
            cnv2.Background = bg;
            ConfigClass.Style = true;
        }
        public static class ConfigClass
        {
            public static bool Style { get; set; }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            Log_in log_In = new Log_in();
            this.Hide();
            log_In.ShowDialog();
            this.Show();

        }

        
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About  about = new About();
            this.Hide();
            about.ShowDialog();
            this.Show();
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.Hide();
            settings.ShowDialog();
            this.Show();
        }

        private void records_Click(object sender, RoutedEventArgs e)
        {
            Records records = new Records();
            this.Hide();
            records.ShowDialog();
            this.Show();
        }
    }
}
