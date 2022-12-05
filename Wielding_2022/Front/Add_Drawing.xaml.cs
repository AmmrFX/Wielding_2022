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
using Backkk;

namespace Wielding_2022.Front
{
    /// <summary>
    /// Interaction logic for Add_Drawing.xaml
    /// </summary>
    public partial class Add_Drawing : Window
    {
        public Add_Drawing()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
         DbSetup.Add_Main(new Main_Tables()
            {
                Drawing_Number = txtDrawing.Text,
                Line_Class = txtLineClass.Text,
                Line_Number = txtLineNo.Text
            });
        }

        private void Add_Drawing_OnLoaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
