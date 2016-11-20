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
        public ICommand NextLevelCommand { get; private set; }

        public int MoveCounter
        {
            get { return moveCounter; }
            private set
            {
                if(value != moveCounter)
                {
                    moveCounter = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int WinCounter
        {
            get { return winCounter; }
            private set
            {
                if (value != winCounter)
                {
                    winCounter = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool CurrentLevelIsDone
        {
            get { return currentLevelIsDone; }
            private set
            {
                if (value != currentLevelIsDone)
                {
                    currentLevelIsDone = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private IEnumerator<GameLogic> levels = null;
        private GameLogic currentLevel = null;
        private int moveCounter;
        private int winCounter;
        private bool currentLevelIsDone = false;

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
            levels = GameLogicCreator.CreateFromUri(httpDownloader, Properties.Settings.Default.GameLevelsUri).GetEnumerator();
            levels.MoveNext();
            currentLevel = levels.Current;
            SubscribeToDomainEvents(currentLevel);

            GameField = currentLevel.GameField;

            CellClickCommand = new DelegateCommand(pos => OnCellClick(pos));
            NextLevelCommand = new DelegateCommand(o => OnGoToNextLevel());
        }

        private void SubscribeToDomainEvents(GameLogic gameLogic)
        {
            gameLogic.GameFieldChanged += OnGameFieldChanged;
            gameLogic.MoveCounterChanged += OnMoveCounterChanged;
            gameLogic.WonChanged += OnWonChanged;
        }

        private void UnsubscribeFromDomainEvents(GameLogic gameLogic)
        {
            gameLogic.GameFieldChanged -= OnGameFieldChanged;
            gameLogic.MoveCounterChanged -= OnMoveCounterChanged;
            gameLogic.WonChanged -= OnWonChanged;
        }

        private void OnGameFieldChanged(object sender, EventArgs args)
        {
            NotifyPropertyChanged("GameField");
        }

        private void OnMoveCounterChanged(object sender, MoveCounterEventArgs args)
        {
            MoveCounter = args.Value;
        }

        private void OnWonChanged(object sender, EventArgs args)
        {
            WinCounter++;
            CurrentLevelIsDone = true;
        }

        private void OnCellClick(object param)
        {
            var position = param as Position;
            if (position == null) return;
            if (currentLevel == null) return;
            currentLevel.ProcessToggle(position.X, position.Y);
        }

        private void OnGoToNextLevel()
        {
            CurrentLevelIsDone = false;

            UnsubscribeFromDomainEvents(currentLevel);

            if (!levels.MoveNext()) return;
            currentLevel = levels.Current;

            SubscribeToDomainEvents(currentLevel);

            GameField = currentLevel.GameField;
            NotifyPropertyChanged("GameField");
            MoveCounter = 0;
        }
    }
}
