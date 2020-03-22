using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Seng.Game.Desktop
{
	public static class GameTheme
	{
		private static SolidColorBrush baseThemeColor;
		private static List<SolidColorBrush> allThemeColors;

		static GameTheme()
		{
			baseThemeColor = new SolidColorBrush(Color.FromRgb(0, 102, 204));

			allThemeColors = new List<SolidColorBrush>
			{
				baseThemeColor,
				new SolidColorBrush(Color.FromRgb(255, 87, 25)),
				new SolidColorBrush(Color.FromRgb(204, 0, 204)),
				new SolidColorBrush(Color.FromRgb(0, 102, 0))
			};
		}

		public static SolidColorBrush GetBaseThemeColor() => baseThemeColor;

		public static void ChangeThemeColor()
		{
			var currentTheme = Application.Current.Resources["ThemeColor"] as SolidColorBrush;

			var theme = allThemeColors.First(x => x.Color == currentTheme?.Color);
			var index = allThemeColors.IndexOf(theme);

			Application.Current.Resources["ThemeColor"] =
				index == allThemeColors.Count - 1 ? allThemeColors[0] : allThemeColors[index + 1];
		}
	}
}