using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        public Wielding(Main_Tables DrawingNum, int no)
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
            var wield2 = (Wield_Details)membersDataGrid.SelectedItem;

            Delete_win delete_Win = new Delete_win("Wield ?");
            delete_Win.ShowDialog();
            if (delete_Win.DialogResult == true)
            {
                DbSetup.DeleteWield(wield2.Weld_Number);
            }

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
                UpdateWieldWindow1 update = new UpdateWieldWindow1(DbSetup.getOneWield(wield2.Weld_Number).Weld_Number, -2);
                update.ShowDialog();
                if (update.DialogResult == true)
                {
                    Load();
                }
            }
            catch (Exception )
            {
                // ignored
            }
        }

        private void Load()
        {
            var data = DbSetup.GetAllWields(DrawingNumber, No);
            membersDataGrid.ItemsSource = data;
            textBoxSearch.ItemsSource = data;
            LoadCombo();
            NumbersTxt.Text ="Total Wields: " +data.Count.ToString();
        }
        private void LoadCombo()
        {
            textBoxSearch.DisplayMemberPath = "Weld_Number";
            textBoxSearch.SelectedValuePath = "ID";
        }
        private void membersDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Load();

        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                UpdateWieldWindow1 update = new UpdateWieldWindow1(DrawingNumber.Drawing_Number ,- 1);
                update.ShowDialog();
                if (update.DialogResult == true)
                {
                    Load();
                }
            }
            catch (Exception )
            {
                // ignored
            }
        }
    }
}
