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
        public Passwords()
        {
            InitializeComponent();
            ListBox passwordsListBox = new();
            List<Grid> rows = new();
            Grid firstRow = new();
            ColumnDefinition site = new();
            ColumnDefinition login = new();
            ColumnDefinition password = new();
            ColumnDefinition comment = new();
            firstRow.ColumnDefinitions.Add(site);
            firstRow.ColumnDefinitions.Add(login);
            firstRow.ColumnDefinitions.Add(password);
            firstRow.ColumnDefinitions.Add(comment);
            TextBlock siteTextBlock = new();
            siteTextBlock.Text = "Сайт";
            TextBlock loginTextBlock = new();
            loginTextBlock.Text = "Логин";
            TextBlock passwordTextBlock = new();
            passwordTextBlock.Text = "Пароль";
            TextBlock commentTextBlock = new();
            commentTextBlock.Text = "Комментарий";
            Grid.SetColumn(siteTextBlock, 0);
            Grid.SetColumn(loginTextBlock, 1);
            Grid.SetColumn(passwordTextBlock, 2);
            Grid.SetColumn(commentTextBlock, 3);
            firstRow.Children.Add(siteTextBlock);
            firstRow.Children.Add(loginTextBlock);
            firstRow.Children.Add(passwordTextBlock);
            firstRow.Children.Add(commentTextBlock);
            firstRow.Width = this.Width;
            passwordsListBox.Items.Add(firstRow);
            Grid.SetRow(passwordsListBox, 0);
            mainGrid.Children.Add(passwordsListBox);

        }
    }
}
