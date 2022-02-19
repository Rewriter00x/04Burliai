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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01Burliai.Tools.Controls
{
    /// <summary>
    /// Interaction logic for ResultBlock.xaml
    /// </summary>
    public partial class ResultBlock : UserControl
    {

        public string Text1
        {
            get { return TbRes1.Text; }
            set { TbRes1.Text = value; }
        }

        public string Text2
        {
            get { return TbRes2.Text; }
            set { TbRes2.Text = value; }
        }

        public string Text3
        {
            get { return TbRes3.Text; }
            set { TbRes3.Text = value; }
        }

        public ResultBlock()
        {
            InitializeComponent();
        }
    }
}
