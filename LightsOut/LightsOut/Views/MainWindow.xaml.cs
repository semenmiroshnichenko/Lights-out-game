using LightsOut.ViewModels;
using LightsOutDomain.Types;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var grid = ((DataGrid)sender);
            var rowNumber = grid.SelectedIndex;
            var columnNumber = grid.CurrentColumn.DisplayIndex;
            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
                viewModel.CellClickCommand.Execute(new Position(columnNumber, rowNumber));
        }
    }
}
