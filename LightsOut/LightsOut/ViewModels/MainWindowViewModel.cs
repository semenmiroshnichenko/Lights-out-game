using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LightsOutDomain.GameLogicCreator;
using System.Collections.ObjectModel;

namespace LightsOut.ViewModels
{
    public class MainWindowViewModel
    {
        public bool[,] GameField { get; private set; }

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
        public MainWindowViewModel(GameLogicCreator gameCreator)
        {
            
        }
    }
}
