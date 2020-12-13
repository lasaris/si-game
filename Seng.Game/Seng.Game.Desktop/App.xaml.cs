using Prism.Ioc;
using Seng.Game.Business;
using Seng.Game.Desktop.Views;
using System.IO;
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
			containerRegistry.RegisterForNavigation<NewEmailView>();
			containerRegistry.RegisterForNavigation<DisplayEmailView>();
			containerRegistry.RegisterForNavigation<EmptyEmailView>();
			containerRegistry.RegisterForNavigation<SelectOptionView>();

			containerRegistry.RegisterForNavigation<BrowserModuleView>();
			containerRegistry.RegisterForNavigation<MinigameSelectionView>();
			containerRegistry.RegisterForNavigation<SearchingMinigameView>();
			containerRegistry.RegisterForNavigation<UnllockManafloidsMinigameView>();
		}

		/// <summary>
		/// On startup sets base theme color and theme background color.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			Current.Resources["ThemeColor"] = GameTheme.GetBaseThemeColor();
			Current.Resources["ThemeBackgroundColor"] = GameTheme.GetBaseThemeBackgroundColor();

			//File.Copy(Configurations.DbPath, Configurations.DbResultsPath);
			File.Delete(Configurations.DbPath);
			File.Copy(Configurations.StaticDbPath, Configurations.DbPath);
		}
	}
}