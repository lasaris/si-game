using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Seng.Game.Desktop
{
	/// <summary>
	/// Contains settings about color themes, that are used accross application.
	/// </summary>
	public static class GameTheme
	{
		/// <summary>
		/// Default theme color, used first after application start.
		/// </summary>
		private static readonly Color BaseColor;

		/// <summary>
		/// Opacity for background theme color.
		/// </summary>
		private static readonly double Opacity;

		/// <summary>
		/// Theme colors, which are rotated inside the application. First in list is base color. 
		/// </summary>
		private static readonly List<SolidColorBrush> AllThemeColors;

		/// <summary>
		/// Background theme colors, which are rotated inside the application.
		/// Contains same colors as <see cref="AllThemeColors"/> with opacity on them.
		/// </summary>
		private static readonly List<SolidColorBrush> AllThemeBackgroundColors;

		/// <summary>
		/// Initializes <see cref="GameTheme"/> class.
		/// </summary>
		static GameTheme()
		{
			BaseColor = Color.FromRgb(0, 102, 204);
			Opacity = 0.05;

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

		/// <summary>
		/// Returns base theme color.
		/// </summary>
		/// <returns><see cref="SolidColorBrush"/></returns>
		public static SolidColorBrush GetBaseThemeColor() => new SolidColorBrush(BaseColor);

		/// <summary>
		/// Returns base background color.
		/// </summary>
		/// <returns><see cref="SolidColorBrush"/></returns>
		public static SolidColorBrush GetBaseThemeBackgroundColor() => new SolidColorBrush(BaseColor) {Opacity = Opacity};


		/// <summary>
		/// Changes theme color across the application.
		/// Color is changed to the next one in <see cref="AllThemeColors"/> and <see cref="AllThemeBackgroundColors"/>.
		/// If current is the last one, first (default) theme is used.
		/// </summary>
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