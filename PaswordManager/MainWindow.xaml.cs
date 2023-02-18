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
        public Button SightUpBtn= new Button();
        public TextBlock SightUpBtnText = new TextBlock();
        public Button LogInBtn = new Button();
        public TextBlock LogInBtnText = new TextBlock();
        public TextBlock errorText = new TextBlock();
        string passwd1;
        string passwd2;
        //public Te
        public static string password;
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(Directory.GetCurrentDirectory() + @"/paswd.enc"))
            {
                BuildSighUpPage();
            }
            else
            {
                BuildLogInPage();
            }
            SightUpBtn.Click += CreateNewPassFile;
        }

        private void BuildLogInPage()
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
            pass1Hint.Text = "Введите пароль";
            MainStackPanel.Children.Add(pass1Hint);
            pass1Hint.TextAlignment = TextAlignment.Center;
            pass1Hint.FontSize = 8;
            pass1Hint.Foreground = Brushes.LightGray;
            MainStackPanel.Children.Add(LogInBtn);
            LogInBtn.Width = 150;
            LogInBtn.Height = 40;
            LogInBtn.Margin = new Thickness(0, 30, 0, 0);
            LogInBtn.Background = Brushes.RoyalBlue;
            LogInBtn.BorderBrush = null;
            LogInBtn.Foreground = Brushes.White;
            LogInBtn.Content = LogInBtnText;
            LogInBtnText.Text = "Войти";
            LogInBtnText.FontSize = 15;
            LogInBtnText.FontWeight = FontWeights.Bold;
            MainStackPanel.Children.Add(errorText);
        }

        private void CreateNewPassFile(object sender, RoutedEventArgs e)
        {
            passwd1=pass1.Text;
            passwd2=pass2.Text;
            if (passwd1 == passwd2)
            {
                if (passwd1!= null && passwd1.Length >= 8)
                {
                    if (!passwd1.Contains(" "))
                    {
                        File.Create(Directory.GetCurrentDirectory() + @"/paswd.enc");
                        password = passwd1;
                        Passwords paswordsWindow = new Passwords();
                        paswordsWindow.Show();
                        this.Close();
                    }
                    {
                        errorText.Text = "Пароль не должен содержать пробелы";
                        errorText.Foreground = Brushes.Red;
                        errorText.TextAlignment = TextAlignment.Center;
                    }
                }
                else
                {
                    errorText.Text = "Пароль должен содержать минимум 8 символов";
                    errorText.Foreground = Brushes.Red;
                    errorText.TextAlignment = TextAlignment.Center;
                }
            }
            else
            {
                errorText.Text = "Пароли не совпадают";
                errorText.Foreground=Brushes.Red;
                errorText.TextAlignment = TextAlignment.Center;
            }
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
            MainStackPanel.Children.Add(SightUpBtn);
            SightUpBtn.Width = 150;
            SightUpBtn.Height = 40;
            SightUpBtn.Margin = new Thickness(0, 30, 0, 0);
            SightUpBtn.Background = Brushes.RoyalBlue;
            SightUpBtn.BorderBrush = null;
            SightUpBtn.Foreground = Brushes.White;
            SightUpBtn.Content = SightUpBtnText;
            SightUpBtnText.Text = "Создать";
            SightUpBtnText.FontSize = 15;
            SightUpBtnText.FontWeight = FontWeights.Bold;
            MainStackPanel.Children.Add(errorText);
        }
    }
}
