using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Backkk;

namespace Wielding_2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int PId { get; set; }

        public MainWindow()
        {
            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            InitializeComponent();
        }


        private void membersDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
          /*  var Data = DbSetup.GetAll();
            membersDataGrid.ItemsSource = Data.GroupBy(a => a.Drawing_Number);*/
        }

        private void membersDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            #region auto
            if (e.Column.Header.ToString() == "Item_Number")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Weld_Number")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Intitial_Production")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Heat_number_side_A/side_B")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Pipe/fitting_number_side_A/side_B")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Line_class")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Fit_up_inspection_QR_number")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Fit_up_date")
            {
                e.Cancel = true;
            }
         
            if (e.Column.Header.ToString() == "Spool_No.")
            {
                e.Cancel = true;
            }

            if (e.Column.Header.ToString() == "Id")
            {
                e.Cancel = true;
            }  

            if (e.Column.Header.ToString() == "Line_Number")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Material_Type_Side_A")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Material_Type_Side_B")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Material_Grade_Side_B")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Material_Grade_Side_A")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Pipe_fitting_number_side_A_side_B")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Weld_Type")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "Id")
            {
                e.Cancel = true;
            }
            #endregion

        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void membersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var wield2 = (ShopTest)membersDataGrid.SelectedItem;
                
               
                ShopTest shop = DbSetup.getOne(wield2.Drawing_Number);
                Wielding wielding = new Wielding(shop.Drawing_Number);
                wielding.Show();
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var data = DbSetup.GetAll();
            var getList = data.GroupBy(a => a.Drawing_Number).Select(g => new ShopTest
            {
                Drawing_Number = g.Key
            }).ToList();
            membersDataGrid.ItemsSource = getList;
            NumberTxt.Text =getList.Count.ToString();  
        }
    }
}
