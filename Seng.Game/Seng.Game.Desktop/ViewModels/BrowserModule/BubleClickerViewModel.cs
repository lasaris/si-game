using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Seng.Game.Desktop.ViewModels
{
    public class BubleClickerViewModel : BaseViewModel, INavigationAware
    {

        public DelegateCommand ReturnFromSearchingCommand { get; set; }
        public DelegateCommand ClickOnCanvas { get; set; }

        public BubleClickerViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
            : base(regionManager, eventAggregator, gameState)
        {
            ReturnFromSearchingCommand = new DelegateCommand(ReturnFromSearchingCommandExecute);
            ClickOnCanvas = new DelegateCommand(ClickOnCanvasExecute);
        }

        private void ReturnFromSearchingCommandExecute()
        {
            RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.MinigameSelectionView);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => false;
        public void OnNavigatedTo(NavigationContext navigationContext) { }
        public void OnNavigatedFrom(NavigationContext navigationContext) { }

        public void ClickOnCanvasExecute()
        {
            MessageBox.Show("Hello, world!");
        }
    }
}
