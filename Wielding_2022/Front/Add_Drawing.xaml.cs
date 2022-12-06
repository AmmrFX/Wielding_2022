using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private Main_Tables _Main;
        private int _flag;
        //add=-1 update = -2
        public Add_Drawing( int Flag)
        {
           /* _Main = Main;*/
            _flag = Flag;
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (_flag == -1)
            {
                DbSetup.Add_Main(new Main_Tables()
                {
                    Drawing_Number = txtDrawing.Text,
                    Line_Class = txtLineClass.Text,
                    Line_Number = txtLineNo.Text
                });
            }
            if (_flag == -2)
            {
              /*  DbSetup.UpdateMain*/
            }

        }
    }
}
