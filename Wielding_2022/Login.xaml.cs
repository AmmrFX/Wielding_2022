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

namespace Wielding_2022
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_password != null && txt_username.Text != "")
                {
                    if (txt_password.Password.ToString().Equals("123") && txt_username.Text == "admin")
                    {

                        this.Close();

                    }
                    else
                    {
                        //mbo message1 = new message_window("Check user and pass");
                      //  message1.Show();
                        txt_password.Password = null;

                    }
                }
                else
                {
                   // message_window message = new message_window("Check user and pass");
                    //message.Show();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Txt_password_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            // your event handler here
            e.Handled = true;
           btn_add_Click(this,new RoutedEventArgs());
        }
    }
}
