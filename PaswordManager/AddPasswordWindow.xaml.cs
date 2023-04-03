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
    /// Логика взаимодействия для AddPasswordWindow.xaml
    /// </summary>
    public partial class AddPasswordWindow : Window
    {
        public string site;
        public string login;
        public string paswd;
        public string comm;

        public AddPasswordWindow()
        {
            InitializeComponent();
            Save.Click += SaveButtonClicked;
            Close.Click += CloseButtonClicked;
        }

        private void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            site= sitetextBox.Text is null ? " " : sitetextBox.Text;
            login = logintextBox.Text is null ? " " : logintextBox.Text;
            paswd = paswdtextBox.Text is null ? " " : paswdtextBox.Text;
            comm = commtextBox.Text is null ? " " : commtextBox.Text;
            this.DialogResult = true;
        }
    }
}
