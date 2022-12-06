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
    /// Interaction logic for Delete_win.xaml
    /// </summary>
    public partial class Delete_win : Window
    {
        public Delete_win(String Message)
        {
            InitializeComponent();
            Message_txt.Text= "Are You sure to delete "+ Message;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
