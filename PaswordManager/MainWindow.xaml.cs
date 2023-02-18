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
        public TextBlock logo = new TextBlock();
        public TextBox pass1 = new TextBox();
        public TextBlock pass1Hint = new TextBlock();
        public TextBox pass2 = new TextBox();
        public TextBlock pass2Hint = new TextBlock();
        public Button createBtn= new Button();
        public TextBlock createBtnText = new TextBlock();
        string passwd1;
        string passwd2;
        //public Te
        public string password;
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(Directory.GetCurrentDirectory() + @"/paswd.enc"))
            {
                BuildSighUpPage();
            }
            createBtn.Click += CreateNewPassFile;
            pass1.TextChanged += Pass1TextChange;
            pass2.TextChanged += Pass2TextChange;
        }

        private void Pass1TextChange(object sender, TextChangedEventArgs e)
        {
            TextBox mytb = (TextBox)sender;
            if (mytb.Text.Length > 0)
            {
                passwd1 += mytb.Text[0];
                char[] chars = mytb.Text.ToCharArray();
                chars[0] = '*';
                mytb.Text = new string(chars);
            }
        }
        private void Pass2TextChange(object sender, TextChangedEventArgs e)
        {
            TextBox mytb = (TextBox)sender;
            if (mytb.Text.Length > 0)
            {
                passwd2 += mytb.Text[0];
                char[] chars = mytb.Text.ToCharArray();
                chars[0] = '*';
                mytb.Text = new string(chars);
            }
        }

        private void CreateNewPassFile(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void BuildSighUpPage()
        {
            logo.Text = "Password Manager";
            MainStackPanel.Children.Add(logo);
            logo.TextAlignment = TextAlignment.Center;
            logo.FontWeight = FontWeights.Bold;
            logo.FontSize = 50;
            logo.FontFamily = new FontFamily("Cooper Black");
            logo.Foreground = Brushes.RoyalBlue;
            MainStackPanel.Children.Add(pass1);
            pass1.Margin = new Thickness(0, 30, 0, 0);
            pass1.Width = 150;
            pass1Hint.Text = "Придумайте пароль для доступа к паролям";
            MainStackPanel.Children.Add(pass1Hint);
            pass1Hint.TextAlignment = TextAlignment.Center;
            pass1Hint.FontSize = 8;
            pass1Hint.Foreground = Brushes.LightGray;
            MainStackPanel.Children.Add(pass2);
            pass2.Margin = new Thickness(0, 10, 0, 0);
            pass2.Width = 150;
            pass2Hint.Text = "Повторите его";
            MainStackPanel.Children.Add(pass2Hint);
            pass2Hint.TextAlignment = TextAlignment.Center;
            pass2Hint.FontSize = 8;
            pass2Hint.Foreground = Brushes.LightGray;
            MainStackPanel.Children.Add(createBtn);
            createBtn.Width = 150;
            createBtn.Height = 40;
            createBtn.Margin = new Thickness(0, 30, 0, 0);
            createBtn.Background = Brushes.RoyalBlue;
            createBtn.BorderBrush = null;
            createBtn.Content = "Создать!";
            createBtn.Foreground = Brushes.White;
            createBtn.Content = createBtnText;
            createBtnText.Text = "Создать";
            createBtnText.FontSize = 15;
            createBtnText.FontWeight = FontWeights.Bold;
        }
    }
}
