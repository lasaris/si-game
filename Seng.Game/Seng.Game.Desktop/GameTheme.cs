using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Seng.Game.Desktop
{
	public static class GameTheme
	{
		private static readonly Color BaseColor;
		private static readonly double Opacity;
		private static readonly List<SolidColorBrush> AllThemeColors;
		private static readonly List<SolidColorBrush> AllThemeBackgroundColors;

		static GameTheme()
		{
			BaseColor = Color.FromRgb(0, 102, 204);
			Opacity = 0.1;

			AllThemeColors = new List<SolidColorBrush>
			{
				new SolidColorBrush(BaseColor),
				new SolidColorBrush(Color.FromRgb(255, 87, 25)),
				new SolidColorBrush(Color.FromRgb(204, 0, 204)),
				new SolidColorBrush(Color.FromRgb(0, 102, 0))
			};

			AllThemeBackgroundColors = new List<SolidColorBrush>
			{
				new SolidColorBrush(BaseColor) { Opacity = Opacity },
				new SolidColorBrush(Color.FromRgb(255, 87, 25)) { Opacity = Opacity },
				new SolidColorBrush(Color.FromRgb(204, 0, 204)) { Opacity = Opacity },
				new SolidColorBrush(Color.FromRgb(0, 102, 0)) { Opacity = Opacity }
			};
		}

		public static SolidColorBrush GetBaseThemeColor() => new SolidColorBrush(BaseColor);
		public static SolidColorBrush GetBaseThemeBackgroundColor() => new SolidColorBrush(BaseColor) {Opacity = Opacity};

		public static void ChangeThemeColor()
		{
			var currentTheme = Application.Current.Resources["ThemeColor"] as SolidColorBrush;

			var theme = AllThemeColors.First(x => x.Color == currentTheme?.Color);
			var index = AllThemeColors.IndexOf(theme);

			bool lastColor = index == AllThemeColors.Count - 1;

			if (lastColor)
			{
				Application.Current.Resources["ThemeColor"] = AllThemeColors[0];
				Application.Current.Resources["ThemeBackgroundColor"] = AllThemeBackgroundColors[0];
			}
			else
			{
				Application.Current.Resources["ThemeColor"] = AllThemeColors[index + 1];
				Application.Current.Resources["ThemeBackgroundColor"] = AllThemeBackgroundColors[index + 1];
			}
		}
	}
}