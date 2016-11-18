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
            var gameLogicCreator = new GameLogicCreator();
            mainWindow.DataContext = new ViewModels.MainWindowViewModel(gameLogicCreator);
            mainWindow.Show();
        }

       
    }
}
