using LightsOut.ViewModels;
using LightsOutDomain.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

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
            if (grid.SelectedIndex == -1 || grid.CurrentColumn == null) return;
            var rowNumber = grid.SelectedIndex;
            var columnNumber = grid.CurrentColumn.DisplayIndex;
            var viewModel = DataContext as MainWindowViewModel;
            if (viewModel != null)
                viewModel.CellClickCommand.Execute(new Position(columnNumber, rowNumber));
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();

            DataTemplate template = new DataTemplate();
            template.VisualTree = new FrameworkElementFactory(typeof(BulbSwitch));
            template.VisualTree.SetBinding(BulbSwitch.StatusProperty, new Binding((string)e.Column.Header));
            templateColumn.CellTemplate = template;

            e.Column = templateColumn;
        }
    }
}
