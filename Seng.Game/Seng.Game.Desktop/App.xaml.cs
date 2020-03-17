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
			containerRegistry.RegisterForNavigation<PauseView>();
			containerRegistry.RegisterForNavigation<IntermissionModuleView>();
			containerRegistry.RegisterForNavigation<DesktopModuleView>();
			containerRegistry.RegisterForNavigation<EmailModuleView>();
			containerRegistry.RegisterForNavigation<BrowserModuleView>();

			containerRegistry.RegisterForNavigation<NewEmailView>();
			containerRegistry.RegisterForNavigation<DisplayEmailView>();
			containerRegistry.RegisterForNavigation<EmptyEmailView>();
			containerRegistry.RegisterForNavigation<SelectOptionView>();
		}

		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			Application.Current.Resources["ThemeColor"] = GameTheme.GetBaseThemeColor();
		}
	}
}