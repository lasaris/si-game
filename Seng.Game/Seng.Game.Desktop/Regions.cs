using System;
using Seng.Game.Desktop.Views;

namespace Seng.Game.Desktop
{
	/// <summary>
	/// Prism region names and region views for navigation between regions.
	/// </summary>
	public static class Regions
	{
		#region Region Names

		public static readonly string ApplicationRegion = "ApplicationRegion";

		public static readonly string ModuleRegion = "ModuleRegion";

		public static readonly string EmailRegion = "EmailRegion";

		public static readonly string BrowserRegion = "BrowserRegion";

		#endregion

		#region Region Views

		public static readonly string GameView = nameof(Views.GameView);
		public static readonly Type GameViewType = typeof(GameView);


		public static readonly string PauseView = nameof(Views.PauseView);
		public static readonly Type PauseViewType = typeof(PauseView);


		public static readonly string IntermissionModuleView = nameof(Views.IntermissionModuleView);
		public static readonly Type IntermissionModuleViewType = typeof(IntermissionModuleView);


		public static readonly string DesktopModuleView = nameof(Views.DesktopModuleView);
		public static readonly Type DesktopModuleViewType = typeof(DesktopModuleView);


		public static readonly string BrowserModuleView = nameof(Views.BrowserModuleView);
		public static readonly string MinigameSelectionView = nameof(Views.MinigameSelectionView);
		public static readonly Type MinigameSelectionViewType = typeof(MinigameSelectionView);
		public static readonly string SearchingMinigameView = nameof(Views.SearchingMinigameView);


		public static readonly string EmailModuleView = nameof(Views.EmailModuleView);
		public static readonly string NewEmailView = nameof(Views.NewEmailView);
		public static readonly string DisplayEmailView = nameof(Views.DisplayEmailView);
		public static readonly string EmptyEmailView = nameof(Views.EmptyEmailView);
		public static readonly Type EmptyEmailViewType = typeof(EmptyEmailView);
		public static readonly string SelectOptionView = nameof(Views.SelectOptionView);

		#endregion
	}
}