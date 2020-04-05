using Seng.Game.Business.DTOs.Modules;
using Seng.Game.Desktop.ViewModels;

namespace Seng.Game.Desktop
{
	public class GameState
	{
		public IntermissionModuleDto IntermissionModule { get; set; }

		public EmailModuleDto EmailModule { get; set; }

		public BrowserModuleDto BrowserModule { get; set; }

		public DesktopModuleDto DesktopModule { get; set; }

		public GameState()
		{
			IntermissionModule = GameInitialize.IntermissionModuleGet();
			EmailModule = GameInitialize.EmailModuleGet();
			BrowserModule = GameInitialize.BrowserModuleGet();
			DesktopModule = GameInitialize.DesktopModuleGet();
		}
	}
}