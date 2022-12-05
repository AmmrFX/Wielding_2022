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
using Wielding_2022;

namespace Backkk
{
    /// <summary>
    /// Interaction logic for Wielding.xaml
    /// </summary>
    public partial class Wielding : Window
    {
        public Main_Tables DrawingNumber { get; set; }
        public int No { get; set; }
        public Wielding(Main_Tables DrawingNum,int no )
        {
            DrawingNumber = DrawingNum;
            No = no;
            InitializeComponent();
        }

        private void membersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void membersDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Item_Number")
            {
                e.Cancel = true;
            }
            

            if (e.Column.Header.ToString() == "ID")
            {
                e.Cancel = true;
            }

       
            if (e.Column.Header.ToString() == "Id")
            {
                e.Cancel = true;
            }

        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var wield2 = (Wield_Details)membersDataGrid.SelectedItem;
                Wield_Details shop = DbSetup.getOneWield(wield2.Weld_Number);
                UpdateWieldWindow1 update = new UpdateWieldWindow1(shop.Weld_Number);
                update.ShowDialog();
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private void membersDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var data = DbSetup.GetAllWields(DrawingNumber,No);
            membersDataGrid.ItemsSource = data;
            NumbersTxt.Text = data.Count.ToString();   

        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
