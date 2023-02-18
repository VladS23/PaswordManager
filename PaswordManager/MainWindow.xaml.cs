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

namespace PaswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(Directory.GetCurrentDirectory() + @"/paswd.enc"))
            {
                TextBlock logo = new TextBlock();
                logo.Text = "Password Manager";
                MainStackPanel.Children.Add(logo);
                logo.TextAlignment = TextAlignment.Center;
                logo.FontWeight = FontWeights.Bold;
                logo.FontSize = 25;
                logo.FontFamily = new FontFamily("Cooper Black");
                logo.Foreground = Brushes.RoyalBlue;
                TextBlock createFile=new TextBlock();
                createFile.Text = "Не обнаружены файлы с паролями.\n Создание нового файла";
                MainStackPanel.Children.Add(createFile);
                createFile.TextAlignment = TextAlignment.Center;
                createFile.Margin=new Thickness(0, 10,0,0);
            }
        }
    }
}
