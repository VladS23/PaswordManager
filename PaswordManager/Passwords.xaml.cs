using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PaswordManager
{
    /// <summary>
    /// Логика взаимодействия для Passwords.xaml
    /// </summary>
    public partial class Passwords : Window
    {
        public List<Grid> rows = new();
        public Passwords(bool isNew, string password)
        {
            InitializeComponent();
            if (isNew)
            {
                addPasswordRecord("Сайт", "Логин", "Пароль", "Комментарий");
            }
            else
            {
                DatabaseHolder newDb = MainWindow.dbhold.LoadDb(password);
                MainWindow.dbhold.passwordsListBox = new ListBox();
                MainWindow.dbhold.database = new();
                for (int i=0; i < newDb.database.Count; i++)
                {
                    addPasswordRecord(newDb.database[i][0], newDb.database[i][1], newDb.database[i][2], newDb.database[i][3]);
                }
            }
            AddButton.Click += CreateButtonClicked;
            SaveButton.Click += SaveButtonClicked;
            ExitButton.Click += ExitButtonClicked;
        }

        private void ExitButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindow.dbhold.SaveDb(MainWindow.password);
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            AddPasswordWindow nps = new();
            if (nps.ShowDialog() == true)
            {
                if (nps.site != "" || nps.login != "" || nps.paswd != "" || nps.comm != "")
                {
                    String paswordRegexPattern = @"^[а-яА-ЯёЁa-zA-Z0-9\.\,\\\-\;\:\#\&\@\$\%\^\+\=_/]*$";
                    if (Regex.IsMatch(nps.site, paswordRegexPattern))
                    {
                        if (Regex.IsMatch(nps.login, paswordRegexPattern))
                        {
                            if (Regex.IsMatch(nps.paswd, paswordRegexPattern))
                            {
                                if (Regex.IsMatch(nps.comm, paswordRegexPattern))
                                {
                                    addPasswordRecord(nps.site, nps.login, nps.paswd, nps.comm);
                                }
                                else
                                {
                                    MessageBox.Show("Недопустимые символы в комментарии");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Недопустимые символы в пароле");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Недопустимые символы в логине");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Недопустимые символы в имени сайта");
                    }
                }
            }
            nps.Close();
        }

        public void addPasswordRecord(string site, string log, string pasw, string comm)
        {
            Grid r = new();
            ColumnDefinition siteColumn = new();
            ColumnDefinition loginColumn = new();
            ColumnDefinition passwordColumn = new();
            ColumnDefinition commentColumn = new();
            r.ColumnDefinitions.Add(siteColumn);
            r.ColumnDefinitions.Add(loginColumn);
            r.ColumnDefinitions.Add(passwordColumn);
            r.ColumnDefinitions.Add(commentColumn);
            TextBlock siteTextBlock = new();
            siteTextBlock.Text = site;
            TextBlock loginTextBlock = new();
            loginTextBlock.Text = log;
            TextBlock passwordTextBlock = new();
            passwordTextBlock.Text = pasw;
            TextBlock commentTextBlock = new();
            commentTextBlock.Text = comm;
            Grid.SetColumn(siteTextBlock, 0);
            Grid.SetColumn(loginTextBlock, 1);
            Grid.SetColumn(passwordTextBlock, 2);
            Grid.SetColumn(commentTextBlock, 3);
            r.Children.Add(siteTextBlock);
            r.Children.Add(loginTextBlock);
            r.Children.Add(passwordTextBlock);
            r.Children.Add(commentTextBlock);
            r.Width = this.Width - 29;
            MainWindow.dbhold.passwordsListBox.Items.Add(r);
            MainWindow.dbhold.database.Add(new List<string> { site, log, pasw, comm });
            Grid.SetRow(MainWindow.dbhold.passwordsListBox, 0);
            UpdateMainGrid(MainWindow.dbhold.passwordsListBox);
            rows.Add(r);
        }
        public void UpdateMainGrid(ListBox passwordsListBox)
        {
            mainGrid.Children.Remove(passwordsListBox);
            mainGrid.Children.Add(passwordsListBox);
        }
    }
}
