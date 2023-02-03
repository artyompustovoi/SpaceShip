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
using System.Windows.Threading;
using static SpaceShip.MainWindow;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace SpaceShip
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {

        DispatcherTimer gameTimer = new DispatcherTimer();
        bool moveLeft, moveRight;
        List<Rectangle> itemRemover = new List<Rectangle>();
        Random rand = new Random();
        int enemySpriteCounter = 0;
        int enemyCounter = 100;
        int playerSpeed = 15;
        int limit = 50;
        int score = 0;
        int damage = 0;
        int enemySpeed = 10;
        int level = 1;

        string path = "records.txt";

        bool check1 = true;
        bool check2 = true;
        bool check3 = true;
        bool check4 = true;
        bool check5 = true;
        bool check6 = true;
        bool check7 = true;
        bool check8 = true;
        bool check9 = true;
        bool check10 = true;


        Rect playerHitBox;
        public Menu()
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
            cnv1.Focus();
            ImageBrush bg = new ImageBrush();
            if (ConfigClass.Style == true)
            {
                bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Spase2.png"));
                cnv1.Background = bg;
            }
           else
            {
                bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/purple.png"));
                bg.TileMode = TileMode.Tile;
                bg.Viewport = new Rect(0, 0, 0.15, 0.15);
                bg.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
                cnv1.Background = bg;
            }
            

            ImageBrush playerImage = new ImageBrush();
            if (ConfigClass.Style == true)
                playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Player2.png"));
            else
                playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/player.png"));
            player.Fill = playerImage;

        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
            enemyCounter -= 1;
            scoreText.Content = "Score: " + score;
            damageText.Content = "Damage: " + damage;
            levelText.Content = "Level: " + level;
            if (enemyCounter < 0)
            {
                MakeEnemies();
                enemyCounter = limit;
            }
            if (moveLeft == true && Canvas.GetLeft(player) > 0)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
            }
            if (moveRight == true && Canvas.GetLeft(player) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed);
            }
            foreach (var x in cnv1.Children.OfType<Rectangle>())
            {
                if (x is Rectangle && (string)x.Tag == "bullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                    Rect bulletHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (Canvas.GetTop(x) < 10)
                    {
                        itemRemover.Add(x);
                    }
                    foreach (var y in cnv1.Children.OfType<Rectangle>())
                    {
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            Rect enemyHit = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                            if (bulletHitBox.IntersectsWith(enemyHit))
                            {
                                itemRemover.Add(x);
                                itemRemover.Add(y);
                                score++;
                            }
                        }
                    }
                }
                if (x is Rectangle && (string)x.Tag == "enemy")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + enemySpeed);
                    if (Canvas.GetTop(x) > 750)
                    {
                        itemRemover.Add(x);
                        damage += 10;
                    }
                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (playerHitBox.IntersectsWith(enemyHitBox))
                    {
                        itemRemover.Add(x);
                        damage += 5;
                    }
                }
            }
            foreach (Rectangle i in itemRemover)
            {
                cnv1.Children.Remove(i);
            }


            if (score > 0 && score % 5 == 0 && check1 == true)
            {
                check1 = false;
                level++;
                limit -= 4;
                enemySpeed++;
            }
            if (score > 0 && score % 10 == 0 && check2 == true)
            {
                check2 = false;
                level++;
                limit -= 6;
                enemySpeed++;
            }

            if (score > 0 && score % 15 == 0 && check3 == true)
            {
                check3 = false;
                level++;
                limit -= 8;
                enemySpeed++;
            }
            if (score > 0 && score % 20 == 0 && check4 == true)
            {
                check4 = false;
                level++;
                limit -= 10;
                enemySpeed++;
            }
            if (score > 0 && score % 25 == 0 && check5 == true)
            {
                check5 = false;
                level++;
                limit -= 12;
                enemySpeed++;
            }
            if (score > 0 && score % 30 == 0 && check6 == true)
            {
                check6 = false;
                level++;
               
                enemySpeed++;
            }
            if (score > 0 && score % 35 == 0 && check7 == true)
            {
                check7 = false;
                level++;
               
                enemySpeed++;
            }
            if (score > 0 && score % 40 == 0 && check8 == true)
            {
                check8 = false;
                level++;
                
                enemySpeed++;
            }
            if (score > 0 && score % 45 == 0 && check9 == true)
            {
                check9 = false;
                level++;

                enemySpeed++;
            }
            if (score > 0 && score % 50 == 0 && check10 == true)
            {
                check10 = false;
                level++;

                enemySpeed++;
            }
           
            if (damage > 99)
            {
               
                gameTimer.Stop();
                damageText.Content = "Damage: 100";
                damageText.Foreground = Brushes.Red;
                MessageBox.Show("Game over. You have destroyed " + score + " alien ships");

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(Player.Name + " " + score);


                    //await writer.WriteLineAsync("Addition");
                    //await writer.WriteAsync("4,5");
                }

                //using (FileStream fs = new FileStream("records.json", FileMode.Open))
                //{
                //    _Player p = new _Player() { Name = Player.Name, Score = score };
                //    JsonSerializer.Serialize<_Player>(fs, p);
                //    fs.Close();
                //}
                this.Close();

            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                moveLeft = true;
            }
            if (e.Key == Key.Right)
            {
                moveRight = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                moveLeft = false;
            }
            if (e.Key == Key.Right)
            {
                moveRight = false;
            }
            if (e.Key == Key.Space)
            {
                Rectangle newBullet = new Rectangle
                {
                    Tag = "bullet",
                    Height = 20,
                    Width = 5,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };
                Canvas.SetLeft(newBullet, Canvas.GetLeft(player) + player.Width / 2);
                Canvas.SetTop(newBullet, Canvas.GetTop(player) - newBullet.Height);
                cnv1.Children.Add(newBullet);
            }
        }
        private void MakeEnemies()
        {
            ImageBrush enemySprite = new ImageBrush();
            enemySpriteCounter = rand.Next(1, 5);
            if (ConfigClass.Style == true)
            {
                switch (enemySpriteCounter)
                {
                    case 1:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/11.png"));
                        break;
                    case 2:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/22.png"));
                        break;
                    case 3:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/33.png"));
                        break;
                    case 4:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/44.png"));
                        break;
                    case 5:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/55.png"));
                        break;
                }
            }
            else
            {
                switch (enemySpriteCounter)
                {
                    case 1:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/1.png"));
                        break;
                    case 2:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/2.png"));
                        break;
                    case 3:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/3.png"));
                        break;
                    case 4:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/4.png"));
                        break;
                    case 5:
                        enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/5.png"));
                        break;
                }
            }
            Rectangle newEnemy = new Rectangle
            {
                Tag = "enemy",
                Height = 50,
                Width = 56,
                Fill = enemySprite
            };
            Canvas.SetTop(newEnemy, -100);
            Canvas.SetLeft(newEnemy, rand.Next(30, 430));
            cnv1.Children.Add(newEnemy);
        }
    }

}
