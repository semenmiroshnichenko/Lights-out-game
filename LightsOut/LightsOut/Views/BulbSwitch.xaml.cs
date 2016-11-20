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

namespace LightsOut.Views
{
    /// <summary>
    /// Interaction logic for BulbSwitch.xaml
    /// </summary>
    public partial class BulbSwitch : UserControl
    {
        public BulbSwitch()
        {
            InitializeComponent();
        }

        public bool Status
        {
            get { return (bool)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(bool), typeof(BulbSwitch),new PropertyMetadata(false, new PropertyChangedCallback(OnStatusChanged)));

        private static void OnStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          
        }
    }
}
