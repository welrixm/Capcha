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

namespace Lesson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static Random random = new Random();
        private static int countsymbol = 6;
        private void but1_Click(object sender, RoutedEventArgs e)
        {
            countsymbol = random.Next(5, 8);
            UpdateCapcha();

        }
        public void GenerateSymbol()
        {
            string alp = "1234567890ABCDEFGHIJKLMNOP";
            for(int i = 0; i < countsymbol; i++)
            {
                string symbol = alp.ElementAt(random.Next(0, alp.Length)).ToString();
                TextBlock textblock = new TextBlock();
                textblock.Text = symbol;
                textblock.FontSize = random.Next(10, 20);
                textblock.RenderTransform = new RotateTransform(random.Next(-45, 45));
                textblock.Margin = new Thickness(10, 0, 10, 0);
                Stack1.Children.Add(textblock);
            }
        }
        public void GenerateShum(int noise)
        {
            for(int i =0; i< noise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256)));
                ellipse.Height = ellipse.Width = random.Next(20, 50);
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, random.Next(0, 300));
                Canvas.SetTop(ellipse, random.Next(0, 200));
            }
            for(int i =0; i<noise; i ++)
            {
                Rectangle ellipse = new Rectangle();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)random.Next(100, 200),
                        (byte)random.Next(100, 256),
                         (byte)random.Next(100, 256),
                          (byte)random.Next(100, 256)));
                ellipse.Height = ellipse.Width = random.Next(20, 50);
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, random.Next(0, 300));
                Canvas.SetTop(ellipse, random.Next(0, 120));
            }
        }
        public void UpdateCapcha()
        {
            Stack1.Children.Clear();
            canvas.Children.Clear();
            GenerateSymbol();
            GenerateShum(100);
        }
    }
}
