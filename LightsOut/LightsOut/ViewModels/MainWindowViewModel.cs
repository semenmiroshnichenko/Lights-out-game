using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LightsOutDomain.GameLogicCreator;
using System.Collections.ObjectModel;
using LightsOutDomain;
using System.Windows.Input;
using LightsOut.Common;
using System.Runtime.CompilerServices;
using LightsOutDomain.Types;

namespace LightsOut.ViewModels
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        public bool[,] GameField { get; private set; }
        public ICommand CellClickCommand { get; private set; }

        private IReadOnlyCollection<GameLogic> levels = null;
        private GameLogic currentLevel = null;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                throw new Exception("Default constructor is only to use in designer mode");
            }
            GameField = new bool[,] { { false, true, true, false }, 
                                      { false, true, true, false } ,
                                      { false, false, true, false },
                                      { false, true, false, false }};
            
        }
        public MainWindowViewModel(IHttpDownloader httpDownloader)
        {
            levels = GameLogicCreator.CreateFromUri(httpDownloader, @"file:///C:/Game/lights-out-levels.json");
            currentLevel = levels.First();
            GameField = currentLevel.GameField;

            CellClickCommand = new DelegateCommand(pos => OnCellClick(pos));
        }

        private void OnCellClick(object param)
        {
            var position = param as Position;
            if (position == null) return;
            currentLevel.ProcessToggle(position.X, position.Y);
            NotifyPropertyChanged("GameField");
        }
    }
}
