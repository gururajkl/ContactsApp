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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using SQLite;
using ContactsApp.Classes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDataBase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDataBase();
        }

        void ReadDataBase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                // Similar to Select SQL stmt 
                contacts = connection.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
            }

            if(contacts != null)
            {
                contactsLV.ItemsSource = contacts;
            }

            if (contacts.Count > 0)
            {
                totalContacts.Content = $"Total contacts in your directory is {contacts.Count}";
            }
            else totalContacts.Content = $"Total contacts in your directory is 0";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (contacts != null)
            {
                var filteredContacts = contacts.Where(c => c.Name.ToLower().Contains(textBox.Text.ToLower())).ToList();
                contactsLV.ItemsSource = filteredContacts;
            }
        }

        private void contactsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsLV.SelectedItem;

            if(selectedContact != null)
            {
                ContactsDetailsWindow contactsDetailsWindow = new ContactsDetailsWindow(selectedContact);
                contactsDetailsWindow.ShowDialog();
                ReadDataBase();
            }
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbSearch.Text = "";
            tbSearch.Foreground = Brushes.Black;
        }
    }
}
