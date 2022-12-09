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
using ContactsApp.Classes;
using SQLite;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactsDetailsWindow.xaml
    /// </summary>
    public partial class ContactsDetailsWindow : Window
    {
        Contact contact;
        public ContactsDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;
            
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<Contact>();
                sQLiteConnection.Update(contact);
                Close();
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using(SQLiteConnection sQLiteConnection = new SQLiteConnection(App.databasePath))
            {
                sQLiteConnection.CreateTable<Contact>();
                sQLiteConnection.Delete(contact);
                Close();
            }
        }
    }
}
