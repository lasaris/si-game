using System;
using Seng.Game.Desktop.Views;

namespace Seng.Game.Desktop
{
	public static class Regions
	{
		#region Region Names

		public static readonly string ApplicationRegion = "ApplicationRegion";

		public static readonly string MainRibbonRegion = "MainRibbonRegion";

		#endregion

		#region Region Views

		public static readonly string GameView = nameof(Views.GameView);
		public static readonly Type GameViewType = typeof(GameView);

		public static readonly string IntermissionModuleView = nameof(Views.IntermissionModuleView);
		public static readonly Type IntermissionModuleViewType = typeof(IntermissionModuleView);

		public static readonly string DesktopModuleView = nameof(Views.DesktopModuleView);

		#endregion
	}
}