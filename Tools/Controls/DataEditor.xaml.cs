using _01Burliai.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _01Burliai.Tools.Controls
{
    /// <summary>
    /// Interaction logic for DataEditor.xaml
    /// </summary>
    public partial class DataEditor : UserControl
    {
        public IEnumerable DataGridItems
        {
            get { return (IEnumerable)GetValue(DataGridItemsProperty); }
            set { SetValue(DataGridItemsProperty, value); }
        }

        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        public ICommand FilterCommand
        {
            get { return (ICommand)GetValue(FilterCommandProperty); }
            set { SetValue(FilterCommandProperty, value); }
        }

        public static readonly DependencyProperty DataGridItemsProperty = DependencyProperty.Register(
                    "DataGridItems",
                    typeof(IEnumerable),
                    typeof(DataEditor),
                    new PropertyMetadata(null)
                    );

        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
                    "DeleteCommand",
                    typeof(ICommand),
                    typeof(DataEditor),
                    new PropertyMetadata(null)
                    );

        public static readonly DependencyProperty FilterCommandProperty = DependencyProperty.Register(
                    "FilterCommand",
                    typeof(ICommand),
                    typeof(DataEditor),
                    new PropertyMetadata(null)
                    );

        public DataEditor()
        {
            InitializeComponent();
        }
    }
}
