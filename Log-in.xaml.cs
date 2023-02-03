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
    /// Логика взаимодействия для Log_in.xaml
    /// </summary>
    public partial class Log_in : Window
    {
        public Log_in()
        {
            InitializeComponent();
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Settings.png"));
            cnv3.Background = bg;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
           
            if (tb1.Text != "")
            {
                Menu menu = new Menu();
                this.Hide();
                menu.ShowDialog();

            }
            else
            {
                MessageBox.Show("Enter the name");
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Player.Name = tb1.Text;
        }
    }
}
