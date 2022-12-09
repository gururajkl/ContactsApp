using ContactsApp.Classes;
using SQLite;
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
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Getting value from UI and setting those to contact object
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text,
            };

            // Database operations
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // Creating table of Contact type with properties defined
                connection.CreateTable<Contact>();

                // Inserting object (has UI values)
                connection.Insert(contact);

                // No use of conn.Close() bcz SQLite implements IDisposable which gonna close once it comes out of using
            }

            Close();
        }

        private void nameTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            nameTextBox.Text = "";
            nameTextBox.Foreground = Brushes.Black;
        }

        private void emailTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            emailTextBox.Text = "";
            emailTextBox.Foreground = Brushes.Black;
        }

        private void phoneTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            phoneTextBox.Text = "";
            phoneTextBox.Foreground = Brushes.Black;
        }
    }
}
