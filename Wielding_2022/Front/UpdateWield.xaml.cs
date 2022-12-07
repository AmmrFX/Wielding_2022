using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Wielding_2022;

namespace Backkk
{
    /// <summary>
    /// Interaction logic for UpdateWieldWindow1.xaml
    /// </summary>
    public partial class UpdateWieldWindow1 : Window
    {
        private List<Wield_Details> Wield_DetailsList;

        //Add-1 Update -2
        private string _wieldNo = null;
        int AddORUpdate = 0;
        public UpdateWieldWindow1(string wieldNo, int AddOrUpdate)
        {
            InitializeComponent();
            _wieldNo = wieldNo;
            AddORUpdate = AddOrUpdate;
        }
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (AddORUpdate == -1)
            {
                DbSetup.Add_Wield(_wieldNo, AddorUpdate());
            }
            if (AddORUpdate == -2)
            {
                DbSetup.UpdateWield(_wieldNo, AddorUpdate());

            }
            DialogResult = true;
            this.Close();
        }
        private void Load()
        {
            LoadLineClass();
            LoadLineNumber();
            LoadPipe();
            LoadMTA();
            LoatMTb();
            LoadSpoolNo();
            LoadWieldType();

        }

        private void LoadWieldType()
        {
            throw new NotImplementedException();
        }

        private void LoadSpoolNo()
        {
            throw new NotImplementedException();
        }

        private void LoadMTA()
        {
            throw new NotImplementedException();
        }

        private void LoatMTb()
        {
            throw new NotImplementedException();
        }

        private void LoadPipe()
        {
            throw new NotImplementedException();
        }

        private void LoadLineNumber()
        {
            throw new NotImplementedException();
        }

        private void LoadLineClass()
        {
            var x= Wield_DetailsList.GroupBy(a => a.Line_Class).Select(g => new Main_Tables()
            {
                Line_Number = g.Key
            }).ToList();
        }

        private Wield_Details AddorUpdate()
        {
            var data = new Wielding_2022.Wield_Details
            {
                Weld_Number = Combo_wield.Text,
                Line_Number = Combo_Line_number.Text,
                Line_Class = Line_Class.Text,
                Material_T_Side_A = MTA_Combo.Text,
                Material_T_Side_B = Material_Type_B.Text,
                Spool_No = Spool_No.Text,
                Pipe_fitting_number_side_A_side_B = PIPE.Text,
                Weld_Type = Wield_type.Text
            };
            return data;
        }


        private void UpdateWieldWindow1_OnLoaded(object sender, RoutedEventArgs e)
        {
            Material_T_A.Text = "Material Type" + Environment.NewLine + " Side A";
            PIPE2.Text = "Pipe/fitting " + Environment.NewLine + " number side A/side B";
            if (AddORUpdate == -2)
            {
                FillBoxes();
            }
        }
        private void FillBoxes()
        {
            var shop = DbSetup.getOneWield(_wieldNo);
            Combo_wield.Text = shop.Weld_Number;
            Combo_Line_number.Text = shop.Line_Number;
            Line_Class.Text = shop.Line_Class;
            MTA_Combo.Text = shop.Material_T_Side_A;
            Material_Type_B.Text = shop.Material_T_Side_B;
            Spool_No.Text = shop.Spool_No;
            PIPE.Text = shop.Pipe_fitting_number_side_A_side_B;
            diameter.Text = shop.Diametere;
            Thickness.Text = shop.Thickness;
            Wield_type.Text = shop.Weld_Type;
        }
        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
