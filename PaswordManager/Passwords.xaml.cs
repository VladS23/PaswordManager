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

namespace PaswordManager
{
    /// <summary>
    /// Логика взаимодействия для Passwords.xaml
    /// </summary>
    public partial class Passwords : Window
    {
        public List<Grid> rows = new();
        public ListBox passwordsListBox = new();
        public Passwords()
        {
            InitializeComponent();
            addPasswordRecord("Сайт", "Логин", "Пароль", "Комментарий");
            AddButton.Click += CreateButtonClicked;
        }

        private void CreateButtonClicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
            passwordsListBox.Items.Add(r);
            Grid.SetRow(passwordsListBox, 0);
            UpdateMainGrid(passwordsListBox);
            rows.Add(r);
        }
        public void UpdateMainGrid(ListBox passwordsListBox)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(passwordsListBox);
        }
    }
}
