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

namespace Backkk
{
    /// <summary>
    /// Interaction logic for UpdateWieldWindow1.xaml
    /// </summary>
    public partial class UpdateWieldWindow1 : Window
    {
        private string _wieldNo= null;
        public UpdateWieldWindow1(string wieldNo)
        {
            InitializeComponent();
            _wieldNo = wieldNo;
        }

        private void txt_EXE_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_service_name_Copy4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateWieldWindow1_OnLoaded(object sender, RoutedEventArgs e)
        {
            Material_T_A.Text = "Material Type" + Environment.NewLine + " Side A";
            PIPE.Text = "Pipe/fitting " + Environment.NewLine + " number side A/side B";
           
            var shop = DbSetup.getOneWield(_wieldNo);
            Combo_wield.Text = shop.Weld_Number;
            Line_Class.Text = shop.Line_Class;
            Combo_Line_number.Text = shop.Line_Number;
        }
    }
}
