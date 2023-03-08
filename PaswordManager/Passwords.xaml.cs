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
            RowDefinition site = new();
            RowDefinition login = new();
            RowDefinition password = new();
            RowDefinition comment = new();
            firstRow.RowDefinitions.Add(site);
            firstRow.RowDefinitions.Add(login);
            firstRow.RowDefinitions.Add(password);
            firstRow.RowDefinitions.Add(comment);

        }
    }
}
