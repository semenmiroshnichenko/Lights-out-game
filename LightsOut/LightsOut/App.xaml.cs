using LightsOutDomain;
using LightsOutDomain.GameLogicCreator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LightsOut
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new Views.MainWindow();
            var httpDownloader = new HttpDownloader();
            mainWindow.DataContext = new ViewModels.MainWindowViewModel(httpDownloader);
            mainWindow.Show();
        }

       
    }
}
