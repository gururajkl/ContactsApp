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
using ContactsApp.Classes;

namespace ContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl1.xaml
    /// </summary>
    public partial class ContactControl1 : UserControl
    {
        private Contact contact;

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl1), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl1 control = d as ContactControl1;
            if(control != null)
            {
                control.nameTb.Text = (e.NewValue as Contact).Name;
                control.emailTb.Text = (e.NewValue as Contact).Email;
                control.phoneTb.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl1()
        {
            InitializeComponent();
        }
    }
}
