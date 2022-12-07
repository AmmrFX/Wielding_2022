using Backkk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wielding_2022.Front;

namespace Wielding_2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int PId { get; set; }
        private List<Main_Tables> MainList;
        public MainWindow()
        {
            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            MainList = DbSetup.GetAllMain();
            Login login = new Login();
            login.ShowDialog();
            InitializeComponent();
            Load();
        }

        private List<Main_Tables> _getList;


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

            if (e.Column.Header.ToString() == "ID")
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
                Select();
            }
            catch (Exception )
            {
            }
        }

        internal void Select()
        {
            Main_Tables selectedItem = membersDataGrid.SelectedItem as Main_Tables;
            if (selectedItem != null)
            {
                if (FilterComboBox.Text == "Drawing_Number")
                {
                    Main_Tables shop = DbSetup.getOne(selectedItem, 1);
                    Wielding wielding = new Wielding(shop, 1);
                    wielding.ShowDialog();
                }

                if (FilterComboBox.Text == "Line_Class")
                {
                    Main_Tables shop = DbSetup.getOne(selectedItem, 2);
                    Wielding wielding = new Wielding(shop, 2);
                    wielding.ShowDialog();
                }

                if (FilterComboBox.Text == "Line_Number")
                {
                    Main_Tables shop = DbSetup.getOne(selectedItem, 3);
                    Wielding wielding = new Wielding(shop, 3);
                    wielding.ShowDialog();
                }
            }
        }
        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Load()
        {

            FilterComboBox.Items.Add("Drawing_Number");
            FilterComboBox.Items.Add("Line_Class");
            FilterComboBox.Items.Add("Line_Number");
            FilterComboBox.SelectedIndex = 0;
            _getList = MainList.GroupBy(a => a.Drawing_Number).Select(g => new Main_Tables()
            {
                Drawing_Number = g.Key
                ,
            }).ToList();
            membersDataGrid.ItemsSource = _getList;
            NumberTxt.Text = "Total " + (string)FilterComboBox.SelectedValue + " is:" + _getList.Count.ToString();

        }

        private string Filter()
        {
            if ((string)FilterComboBox.SelectedValue == null)
            {
                FilterComboBox.SelectedIndex = 1;
            }
            if ((string)FilterComboBox.SelectedValue == "Line_Class")
            {
                LoadLineCLass();
            }
            if ((string)FilterComboBox.SelectedValue == "Line_Number")
            {
                LoadLineNo();
            }
            if ((string)FilterComboBox.SelectedValue == "Drawing_Number")
            {
                LoadDrawing();
            }
            return FilterComboBox.SelectedValue.ToString();
        }

        private void LoadDrawing()
        {
            _getList = MainList.GroupBy(a => a.Drawing_Number).Select(g => new Main_Tables()
            {
                Drawing_Number = g.Key,
            }).ToList();

        }

        private void LoadLineCLass()
        {
            _getList = MainList.GroupBy(a => a.Line_Class).Select(g => new Main_Tables()
            {
                Line_Class = g.Key,
            }).ToList();
        }

        private void LoadLineNo()
        {
            _getList = MainList.GroupBy(a => a.Line_Number).Select(g => new Main_Tables()
            {
                Line_Number = g.Key,
            }).ToList();
        }
        private void FilterComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            textBoxSearch.ClearValue(ItemsControl.ItemsSourceProperty);

            textBoxSearch.Items.Clear();
            string filter = Filter();
            textBoxSearch.ItemsSource = _getList;
            textBoxSearch.DisplayMemberPath = filter;
            textBoxSearch.SelectedValuePath = "ID";

        }

        private void TextBoxSearch_OnDropDownClosed(object sender, EventArgs e)
        {
            if ((string)FilterComboBox.SelectedValue == "Line_Class")
            {
                var data = _getList.Where(a =>
                    textBoxSearch.SelectionBoxItem != null && a.Line_Class == (string)textBoxSearch.Text).ToList();
                membersDataGrid.ItemsSource = data;
            }
            if ((string)FilterComboBox.SelectedValue == "Line_Number")
            {
                var data = _getList.Where(a =>
                    textBoxSearch.SelectionBoxItem != null && a.Line_Number == (string)textBoxSearch.Text).ToList();
                membersDataGrid.ItemsSource = data;
            }
            if ((string)FilterComboBox.SelectedValue == "Drawing_Number")
            {
                var data = _getList.Where(a =>
                     textBoxSearch.SelectionBoxItem != null && a.Drawing_Number == (string)textBoxSearch.Text).ToList();
                membersDataGrid.ItemsSource = data;
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Drawing add = new Add_Drawing(-1);
            add.ShowDialog();
            if (add.DialogResult == true)
            {
                Load();
            }
        }

        private void DrawingNumber_OnClick(object sender, RoutedEventArgs e)
        {
            FilterComboBox.SelectedIndex = 0;
            LoadDrawing();
            TextAdd.Text = "Add New Drawing Number";
            membersDataGrid.ItemsSource = _getList;
            NumberTxt.Text = "Total " + "Drawing Numbers" + ": " + _getList.Count.ToString();
        }

        private void LineNumber_OnClick(object sender, RoutedEventArgs e)
        {
            FilterComboBox.SelectedIndex =2;
            LoadLineNo();
            TextAdd.Text = "Add New Line Number";
            membersDataGrid.ItemsSource = _getList;
            NumberTxt.Text = "Total " + "Line Numbers" + ": " + _getList.Count.ToString();
        }

        private void LineClass_OnClick(object sender, RoutedEventArgs e)
        {
            FilterComboBox.SelectedIndex = 1;
            LoadLineCLass();
            TextAdd.Text = "Add New Line Class";
            membersDataGrid.ItemsSource = _getList;
            NumberTxt.Text = "Total " + "Line Classes" + ": " + _getList.Count.ToString();
        }
    }
}
