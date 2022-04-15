using System.Windows.Controls;

namespace _01Burliai.Tools.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxWithCaption.xaml
    /// </summary>
    public partial class TextBoxWithCaption : UserControl
    {

        public string Caption
        {
            get { return TbCaption.Text; }
            set { TbCaption.Text = value; }
        }

        public string Value
        {
            get { return TbBox.Text; }
        }

        public TextBoxWithCaption()
        {
            InitializeComponent();
        }
    }
}
