using Prism.Ioc;
using Seng.Game.Desktop.Views;
using System.Windows;

namespace Seng.Game.Desktop
{
	public partial class App
	{
		protected override Window CreateShell()
		{
			Container.Resolve<GameState>();

			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<GameState>();

			containerRegistry.RegisterForNavigation<GameView>();
			containerRegistry.RegisterForNavigation<IntermissionModuleView>();
			containerRegistry.RegisterForNavigation<DesktopModuleView>();
		}
	}
}