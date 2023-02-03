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
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using static System.Console;

namespace SpaceShip
{
    /// <summary>
    /// Логика взаимодействия для Records.xaml
    /// </summary>
    public partial class Records : Window
    {
        string path = "records.txt";
        public Records()
        {
            InitializeComponent();
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Settings.png"));
            cnv3.Background = bg;
            StreamReader sr = new StreamReader("records.txt");
            string line = sr.ReadLine();
            while(line!=null)
            {
                lb1.Items.Add(line);
                line = sr.ReadLine();
            }

            //using (FileStream _fs = new FileStream("records.json", FileMode.Open))
            //{
            //    _Player p = JsonSerializer.Deserialize<_Player>(_fs);


            //    pl_list.Add(p); //= JsonSerializer.Deserialize<_Player>(_fs);
            //    _fs.Close();
            //    _Player p = JsonSerializer.Deserialize<_Player>(_fs);
            //    _fs.Close();
            //    WriteLine("***********OK*************");
            //    WriteLine(p);
            //}
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (var item in pl_list)
            //{

            //}
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write("");
                lb1.Items.Clear();
            }
        }
    }
}
