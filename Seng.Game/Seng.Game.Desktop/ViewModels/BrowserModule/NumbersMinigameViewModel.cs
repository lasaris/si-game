using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Components.BrowserModule;
using Seng.Game.Desktop.Helpers.BrowserModule.SearchingMinigame;
using Seng.Game.Desktop.ViewModels.Base;
using Seng.Game.Desktop.Views;


using Prism.Mvvm;
using System.ComponentModel;

namespace Seng.Game.Desktop.ViewModels
{
    public class NumbersMinigameViewModel : BaseViewModel, INavigationAware, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Brush Number1Brush { get; set; } = Brushes.Gray;
        public Brush Number2Brush { get; set; } = Brushes.Gray;
        public Brush Number3Brush { get; set; } = Brushes.Gray;
        public Brush Number4Brush { get; set; } = Brushes.Gray;
        public Brush Number5Brush { get; set; } = Brushes.Gray;
        public Brush Number6Brush { get; set; } = Brushes.Gray;
        public Brush Number7Brush { get; set; } = Brushes.Gray;
        public Brush Number8Brush { get; set; } = Brushes.Gray;
        public Brush Number9Brush { get; set; } = Brushes.Gray;
        public Brush Number10Brush { get; set; } = Brushes.Gray;

        public List<Brush> BrushList { get; set; }

        public ObservableCollection<Button> ButtonList { get; set; }

        private int currentlyWanted = 1;
        private bool isFinishedSuccessfully = false;


        public DelegateCommand<Button> Number1OnButtonClick { get; set; }

        public DelegateCommand ReturnFromSearchingCommand { get; set; }

        private void ReturnFromSearchingCommandExecute()
        {
            RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.MinigameSelectionView);
        }


        public NumbersMinigameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
            : base(regionManager, eventAggregator, gameState)
        {
            ReturnFromSearchingCommand = new DelegateCommand(ReturnFromSearchingCommandExecute);

            BrushList = new List<Brush> { Number1Brush, Number2Brush, Number3Brush, Number4Brush, Number5Brush,
                Number6Brush, Number7Brush, Number8Brush, Number9Brush, Number10Brush };

            SettingColorToDefault();

            Number1OnButtonClick = new DelegateCommand<Button>(OnButtonClick1);

        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;
        public void OnNavigatedTo(NavigationContext navigationContext) { }
        public void OnNavigatedFrom(NavigationContext navigationContext) { }

        private void SettingColorToDefault()
        {
            for (int x = 0; x < BrushList.Count; x++)
            {
                ChangeToGreen($"Number{x + 1}Brush", Brushes.Gray);
                BrushList[x] = Brushes.Gray;
            }
            currentlyWanted = 1;
        }

        public void ChangeToGreen(string name, Brush brush)
        {
            var property = GetType().GetProperty(name);
            property.SetValue(this, brush);
            RaisePropertyChange(name);
        }

        private void OnButtonClick1(Button sender)
        {
            var currentlyPressed = Int32.Parse(sender.Name.Substring(1));
            if (BrushList[currentlyPressed - 1] == Brushes.Green || currentlyWanted != currentlyPressed)
            {
                SettingColorToDefault();
            }
            else
            {
                BrushList[currentlyPressed - 1] = Brushes.Green;
                ChangeToGreen($"Number{sender.Name.Substring(1)}Brush", Brushes.Green);
                RaisePropertyChange($"Number{sender.Name.Substring(1)}Brush");
                currentlyWanted++;
                if (currentlyPressed == 10)
                {
                    isFinishedSuccessfully = true;
                    ReturnFromSearchingCommandExecute();
                }
            }
        }
    }
}

