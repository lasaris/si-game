﻿using Prism.Events;
using Prism.Regions;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class BrowserModuleViewModel : BaseViewModel
	{
		public BrowserModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			regionManager.RegisterViewWithRegion(Regions.BrowserRegion, Regions.MinigameSelectionViewType);
		}
	}
}