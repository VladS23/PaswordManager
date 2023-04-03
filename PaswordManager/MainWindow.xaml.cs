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
using System.Text.RegularExpressions;

namespace PaswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DatabaseHolder dbhold = new();
        public TextBlock logo = new();
        public TextBox pass1 = new();
        public TextBlock pass1Hint = new();
        public TextBox pass2 = new();
        public TextBlock pass2Hint = new();
        public Button SightUpBtn= new();
        public TextBlock SightUpBtnText = new();
        public Button LogInBtn = new();
        public TextBlock LogInBtnText = new();
        public TextBlock errorText = new ();
        string passwd1;
        string passwd2;
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
            LogInBtn.Click += LogInPressed;
        }

        private void LogInPressed(object sender, RoutedEventArgs e)
        {
            passwd1=pass1.Text;
            if (passwd1 == "123456789")
            {
                password = passwd1;
                Passwords paswordsWindow = new(false);
                paswordsWindow.Show();
                this.Close();
            }
            else
            {
                errorText.Text = "Неверный пароль";
                errorText.Foreground = Brushes.Red;
                errorText.TextAlignment = TextAlignment.Center;
            }
        }

        private void BuildLogInPage()
        {
            CreateLogo();
            CreatePass1TextBlock();
            CreatePasswordHint();
            CreateLogInButton();
            MainStackPanel.Children.Add(errorText);
        }

        private void CreateNewPassFile(object sender, RoutedEventArgs e)
        {
            passwd1=pass1.Text;
            passwd2=pass2.Text;
            String paswordRegexPattern = @"(?=.*[0-9])(?=.*[!@#$%^&*_\-+№,.;:])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*_\-+№,.;:]{8,}";
            if (passwd1 == passwd2)
            {
                    if (Regex.IsMatch(passwd1, paswordRegexPattern, RegexOptions.IgnoreCase))
                    {
                            File.Create(Directory.GetCurrentDirectory() + @"/paswd.enc");
                            password = passwd1;
                            Passwords paswordsWindow = new(true);
                            paswordsWindow.Show();
                            this.Close();
                    }
                    else
                    {
                        errorText.Text = "Пароль должен содержать хотя бы одну цифру, \n" +
                        "латинские буквы разных регистров \n" +
                        "и символ из набора !@#$%^&*-_+№,. \n" +
                        "И не должен содержать другие символы. \n" +
                        "Минимальная длинна пароля 8";
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
            CreateLogo();
            CreatePass1TextBlock();
            CreateNewPassHint();
            CreatePass2TextBlock();
            CreateRepeatPassHint();
            CreateSighUpButton();
            MainStackPanel.Children.Add(errorText);
        }
        void CreateLogo()
        {
            logo.Text = "Password Manager";
            MainStackPanel.Children.Add(logo);
            logo.TextAlignment = TextAlignment.Center;
            logo.FontWeight = FontWeights.Bold;
            logo.FontSize = 50;
            logo.FontFamily = new FontFamily("Cooper Black");
            logo.Foreground = Brushes.RoyalBlue;
        }
        void CreatePass1TextBlock()
        {
            MainStackPanel.Children.Add(pass1);
            pass1.Margin = new Thickness(0, 30, 0, 0);
            pass1.Width = 150;
        }
        void CreateNewPassHint()
        {
            pass1Hint.Text = "Придумайте пароль для доступа к паролям";
            MainStackPanel.Children.Add(pass1Hint);
            pass1Hint.TextAlignment = TextAlignment.Center;
            pass1Hint.FontSize = 8;
            pass1Hint.Foreground = Brushes.LightGray;
        }
        void CreatePass2TextBlock()
        {
            MainStackPanel.Children.Add(pass2);
            pass2.Margin = new Thickness(0, 10, 0, 0);
            pass2.Width = 150;
        }
        void CreateRepeatPassHint()
        {
            pass2Hint.Text = "Повторите его";
            MainStackPanel.Children.Add(pass2Hint);
            pass2Hint.TextAlignment = TextAlignment.Center;
            pass2Hint.FontSize = 8;
            pass2Hint.Foreground = Brushes.LightGray;
        }
        void CreateSighUpButton()
        {
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
        }
        void CreatePasswordHint()
        {
            pass1Hint.Text = "Введите пароль";
            MainStackPanel.Children.Add(pass1Hint);
            pass1Hint.TextAlignment = TextAlignment.Center;
            pass1Hint.FontSize = 8;
            pass1Hint.Foreground = Brushes.LightGray;
        }
        void CreateLogInButton()
        {
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
        }
    }
}
