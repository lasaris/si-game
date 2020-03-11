using Seng.Game.Business.DTOs.Modules;

namespace Seng.Game.Desktop
{
	public class GameState
	{
		public IntermissionModuleDto IntermissionModule { get; set; }

		public EmailModuleDto EmailModule { get; set; }

		public GameState()
		{
			IntermissionModule = GameInitialize.IntermissionModuleGet();
			EmailModule = GameInitialize.EmailModuleGet();
		}
	}
}